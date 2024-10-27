namespace PaybillAPI.Models
{
    public class AppConstants
    {
        internal static readonly string ACCESS_DENIED = "Access Denied";
        internal static readonly string SUCCESS = "SUCCESS";
        internal static readonly string SQL_DELETE_REFERENCE_MESSAGE = "You cannot delete the {0} because it was locked by other transaction!!";
        internal static readonly string UNAUTHORIZED_ACCESS = "Unauthorized access. Please contact the service provider";
        public static readonly string[] API_AES_KEY_AND_IV = ["aptlADsyGEtotitNrGNGBeautyRaESpb", "rEPbyteH4377rfvi"];
        public static readonly string[] PAYBILL_API_AES_KEY_AND_IV = ["PgUpwEBhCapsVkScrLKEySGNSkEYPgDn", "NumPrtScnLockvhI"];
    }
}
