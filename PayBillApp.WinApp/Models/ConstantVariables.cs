using System;

namespace PayBillApp.WinApp.Models
{
    internal class ConstantVariables
    {
        internal static readonly string LOGO_NAME = "_logo.png";
        internal static readonly string SQLITE_DATABASE = "PaybillData.sqlite";
        internal static string SQLITE_CONNECTION_STRING;
        internal static readonly string SQLITE_ITEMS_TABLE = "Items";
        internal static readonly string WEB_API_URL = "http://paybillapp.in/api/WinAPI/"; //http://192.168.0.4/paybill, http://localhost:3539
        internal static readonly string WIN_QRCODE_BASIC_AUTH = "$TlpsMassZdadDaoSddFeeVaAAoioNeNuDDDfFFsopeCCdmfMw";
        internal static readonly string MESSAGE_TITLE = "PayBill";
        internal static string JWT_TOKEN, CLIENT_NAME, USER_ID, DISPLAY_NAME, SECURITY_KEY, MACHINE_UNIQUE_ID;
        internal static int CLIENT_ID, WIN_QRCODE_ID;
        internal static readonly string DROPDONWLIST_TEXT = "---------------";
        internal static readonly string DROPDONWLIST_TEXT_PARAM = "-----{0}-----";
        internal static readonly string DROPDONWLIST_TEXT_NOTAPPLICABLE = "-----Not Applicable-----";
        internal static string REPORT_ADDRESS;
        internal static string CLIENT_GSTIN;
        internal static DateTime SERVER_DATE;
        internal static bool IS_ADMIN, ADD_ITEM_ON_BARCODE_SCAN, IS_PRINT_LOCAL_LANGUAGE, IS_QRCODE_ON_INVOICE;
        internal static string LOGO_URL, INVOICE_TITLE, INVOICE_TERMS;
    }
}
