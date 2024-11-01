﻿namespace PaybillAPI.Models
{
    public class DashboardPref
    {
        public bool IsAutoEmail { get; set; }
        public bool IsBackupOnExit { get; set; }
        public bool IsDiscountEnabled { get; set; }
        public bool AddItemOnSelected { get; set; }
        public bool IsCreateContactOnParty { get; set; }
        public bool IsCompressBackup { get; set; }
        public bool IsShadowMenuButton { get; set; }
        public bool IsSettingsUpdated { get; set; }
        public bool IsAlertOnMinimumStock { get; set; }
        public bool IsAlertOnNegativeBalance { get; set; } = true;
    }
}
