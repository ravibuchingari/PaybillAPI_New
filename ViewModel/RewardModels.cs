namespace Paybill.ViewModel
{
    public class RewardTransactionVM
    {
        public int RewardTransId { get; set; }
        public int PartyId { get; set; }
        public int SalesId { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public double PointsCredited { get; set; }
        public double PointsDebited { get; set; }
        public double MonetaryValue { get; set; }
        public string TransactionDate { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int RefTransId { get; set; }
        public int CreatedBy { get; set; }
        public string PartyName { get; set; } = string.Empty;
        public string PartyMobile { get; set; } = string.Empty;
        public string InvoiceNo { get; set; } = string.Empty;
        public double RunningBalance { get; set; }
        public string? ExpiryDate { get; set; }

        public string Mobile => PartyMobile;
        public string InvoiceNumber => InvoiceNo;
        public double InvoiceAmount => MonetaryValue;
        public double Points => PointsCredited > 0 ? PointsCredited : -PointsDebited;
    }

    public class RewardCustomerSummaryVM
    {
        public int PartyId { get; set; }
        public string PartyName { get; set; } = string.Empty;
        public string PartyMobile { get; set; } = string.Empty;
        public double AvailablePoints { get; set; }
        public double PointsValue { get; set; }
        public double TotalEarned { get; set; }
        public double TotalRedeemed { get; set; }
        public double TotalExpired { get; set; }
        public double TotalReversed { get; set; }
        public double TotalAdjusted { get; set; }
        public string? LastTransactionDate { get; set; }

        public string CustomerName => PartyName;
        public string Mobile => PartyMobile;
        public double TotalPointsEarned => TotalEarned;
        public double TotalPointsRedeemed => TotalRedeemed;
        public double TotalPointsExpired => TotalExpired;
        public double TotalPointsAdjusted => TotalAdjusted;
    }

    public class RewardOverallSummaryVM
    {
        public int TotalCustomersWithBalance { get; set; }
        public double TotalOutstandingPoints { get; set; }
        public double TotalOutstandingValue { get; set; }
        public double TotalPointsEarned { get; set; }
        public double TotalPointsRedeemed { get; set; }
        public double TotalPointsExpired { get; set; }
        public double TotalPointsReversedOrAdjusted { get; set; }

        public int TotalCustomersWithRewards => TotalCustomersWithBalance;
        public double TotalPointsAdjusted => TotalPointsReversedOrAdjusted;
        public double TotalAvailablePoints => TotalOutstandingPoints;
    }

    public class RewardRedemptionDetailVM
    {
        public int RewardTransId { get; set; }
        public int PartyId { get; set; }
        public string PartyName { get; set; } = string.Empty;
        public string PartyMobile { get; set; } = string.Empty;
        public int SalesId { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public string TransactionDate { get; set; } = string.Empty;
        public double PreDiscountAmount { get; set; }
        public double PointsRedeemed { get; set; }
        public double MonetaryValue { get; set; }
        public double RemainingPointsBalance { get; set; }
        public string Status { get; set; } = "SUCCESS";
        public double PointsEarned { get; set; }

        public string SalesDate => TransactionDate;
        public string InvoiceNumber => InvoiceNo;
        public string CustomerName => PartyName;
        public string CustomerPhone => PartyMobile;
        public double InvoiceAmount => PreDiscountAmount;
        public double PointsDiscount => MonetaryValue;
    }

    public class RewardAdjustmentRequestVM
    {
        public int PartyId { get; set; }
        public double Points { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int UserRowId { get; set; }
        public string SecurityKey { get; set; } = string.Empty;
    }
}

