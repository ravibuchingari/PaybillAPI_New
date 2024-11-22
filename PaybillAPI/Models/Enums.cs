namespace PaybillAPI.Models
{

    enum TransType
    {
        SALES_CASH, SALES_CREDIT, PURCHASE_CASH, PURCHASE_CREDIT, PAYMENT, RECEIPT, SALES_DELETED, PURCHASE_DELETED
    }

    enum PaymentMode
    {
        Cash, Card, UPI, Credit
    }
}
