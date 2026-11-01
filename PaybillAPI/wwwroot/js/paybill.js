// PayBill Global UI & POS Helper Library (Pure Light Mode)
const PayBillUI = {
    init() {
        // Always enforce clean Light Mode across the application
        this.setTheme('light');

        // Sidebar collapse state
        if (localStorage.getItem('pb_sidebar_collapsed') === 'true' && window.innerWidth >= 992) {
            document.body.classList.add('sidebar-collapsed');
        }

        // Keyboard shortcuts
        document.addEventListener('keydown', (e) => {
            if (e.key === 'F2') {
                e.preventDefault();
                window.location.href = '/Paybill/Sales/Create';
            } else if (e.key === 'F4') {
                e.preventDefault();
                window.location.href = '/Paybill/Purchase/Create';
            }
        });
    },

    toggleTheme() {
        this.setTheme('light');
    },

    setTheme() {
        document.documentElement.setAttribute('data-bs-theme', 'light');
        localStorage.setItem('pb_theme', 'light');
    },

    toggleSidebar() {
        if (window.innerWidth < 992) {
            document.body.classList.toggle('sidebar-mobile-open');
        } else {
            document.body.classList.toggle('sidebar-collapsed');
            localStorage.setItem('pb_sidebar_collapsed', document.body.classList.contains('sidebar-collapsed'));
        }
    },

    toast(message, type = 'success') {
        const container = document.getElementById('pbToastContainer');
        if (!container) return;
        const bgClass = type === 'success' ? 'text-bg-success' :
                        type === 'danger' || type === 'error' ? 'text-bg-danger' :
                        type === 'warning' ? 'text-bg-warning' : 'text-bg-primary';
        const icon = type === 'success' ? 'bi-check-circle-fill' :
                     type === 'danger' || type === 'error' ? 'bi-exclamation-octagon-fill' :
                     'bi-info-circle-fill';

        const el = document.createElement('div');
        el.className = `toast align-items-center ${bgClass} border-0 show mb-2 shadow rounded-3`;
        el.setAttribute('role', 'alert');
        el.innerHTML = `
            <div class="d-flex">
                <div class="toast-body d-flex align-items-center gap-2 fw-medium">
                    <i class="bi ${icon}"></i>
                    <span>${this.escapeHtml(message)}</span>
                </div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
            </div>`;
        container.appendChild(el);
        setTimeout(() => el.remove(), 4200);
    },

    confirm(title, message, onConfirm, requireRemarks = false) {
        const modalEl = document.getElementById('pbConfirmModal');
        if (!modalEl) {
            if (window.confirm(message)) onConfirm('');
            return;
        }
        document.getElementById('pbConfirmTitle').textContent = title || 'Confirm Action';
        document.getElementById('pbConfirmMessage').textContent = message || 'Are you sure you want to proceed?';
        const remarksWrap = document.getElementById('pbConfirmRemarksWrap');
        const remarksInput = document.getElementById('pbConfirmRemarks');
        remarksInput.value = '';
        if (requireRemarks) {
            remarksWrap.classList.remove('d-none');
        } else {
            remarksWrap.classList.add('d-none');
        }

        const btn = document.getElementById('pbConfirmOkBtn');
        const modal = bootstrap.Modal.getOrCreateInstance(modalEl);

        const newBtn = btn.cloneNode(true);
        btn.parentNode.replaceChild(newBtn, btn);
        newBtn.addEventListener('click', () => {
            const rem = remarksInput.value.trim();
            if (requireRemarks && !rem) {
                this.toast('Please enter mandatory remarks / reason.', 'warning');
                remarksInput.focus();
                return;
            }
            modal.hide();
            onConfirm(rem);
        });

        modal.show();
    },

    filterTable(inputId, tableId) {
        const input = document.getElementById(inputId);
        const table = document.getElementById(tableId);
        if (!input || !table) return;
        const q = input.value.toLowerCase().trim();
        const rows = table.querySelectorAll('tbody tr');
        rows.forEach(r => {
            if (r.classList.contains('no-filter')) return;
            const text = r.textContent.toLowerCase();
            r.style.display = text.includes(q) ? '' : 'none';
        });
    },

    exportTableToCsv(tableId, filename) {
        const table = document.getElementById(tableId);
        if (!table) return;
        const rows = Array.from(table.querySelectorAll('tr'));
        const csv = rows.map(row => {
            const cols = Array.from(row.querySelectorAll('th, td'))
                .filter(c => !c.classList.contains('no-export'));
            return cols.map(c => `"${(c.innerText || '').replace(/"/g, '""').trim()}"`).join(',');
        }).join('\n');

        const blob = new Blob(['\uFEFF' + csv], { type: 'text/csv;charset=utf-8;' });
        const link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = filename || 'paybill_export.csv';
        link.click();
    },

    formatCurrency(val) {
        const num = parseFloat(val) || 0;
        return '₹' + num.toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
    },

    escapeHtml(str) {
        if (!str) return '';
        return String(str)
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;');
    },

    showToast(message, type = 'success') {
        return this.toast(message, type);
    }
};

// Expose both casing aliases used across views
window.PayBillUI = PayBillUI;
window.PaybillUI = PayBillUI;

document.addEventListener('DOMContentLoaded', () => PayBillUI.init());
