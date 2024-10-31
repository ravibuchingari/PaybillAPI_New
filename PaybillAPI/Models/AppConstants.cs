namespace PaybillAPI.Models
{
    public class AppConstants
    {
        internal const string ACCESS_DENIED = "Access Denied";
        internal const string RESPONSE_SUCCESS = "RESPONSE_SUCCESS";
        internal const string SQL_DELETE_REFERENCE_MESSAGE = "You cannot delete the {0} since it was locked by another transaction. To delete a {0}, first remove all related records.";
        internal const string UNAUTHORIZED_ACCESS = "Unauthorized access. Please contact the service provider";
        internal const string ITEM_NOT_FOUND = "{0} was not found. Please verify and try again!";
        internal const string ITEM_DELETED = "The {0} was deleted successfully.";
        public static readonly string[] API_AES_KEY_AND_IV = ["aptlADsyGEtotitNrGNGBeautyRaESpb", "rEPbyteH4377rfvi"];
        public static readonly string[] PAYBILL_API_AES_KEY_AND_IV = ["PgUpwEBhCapsVkScrLKEySGNSkEYPgDn", "NumPrtScnLockvhI"];

    }
}
