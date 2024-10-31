namespace PaybillAPI.Models
{
    enum PaymentMode
    {
        Cash = 0, Credit = 1
    }

    enum TransType
    {
        SALES_CASH, SALES_CREDIT, PURCHASE_CASH, PURCHASE_CREDIT, PAYMENT, RECEIPT
    }
}
