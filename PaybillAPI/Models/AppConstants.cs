﻿namespace PaybillAPI.Models
{
    public class AppConstants
    {
        internal const string ACCESS_DENIED = "Access Denied";
        internal const string RESPONSE_SUCCESS = "RESPONSE_SUCCESS";
        internal const string SQL_DELETE_REFERENCE_MESSAGE = "You cannot delete the {0} because it was locked by other transaction!!";
        internal const string UNAUTHORIZED_ACCESS = "Unauthorized access. Please contact the service provider";
        internal const string ITEM_NOT_FOUND = "{0} is not found";
        internal const string ITEM_DELETED = "The {0} was deleted successfully.";
        public static readonly string[] API_AES_KEY_AND_IV = ["aptlADsyGEtotitNrGNGBeautyRaESpb", "rEPbyteH4377rfvi"];
        public static readonly string[] PAYBILL_API_AES_KEY_AND_IV = ["PgUpwEBhCapsVkScrLKEySGNSkEYPgDn", "NumPrtScnLockvhI"];
        
    }
}
