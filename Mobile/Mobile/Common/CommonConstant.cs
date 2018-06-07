namespace Mobile.Common
{
    public class CommonConstant
    {
        public const string apiUrl = "http://vnrcwebapi.azurewebsites.net/api/v1/";

        public static string clientId = "b75cebe3-8517-4c7d-a123-20f788ddb0d8";
        public static string authority = "https://login.windows.net/common";
        public static string returnUri = "https://DevLoginAzure.azurewebsite.net";
        public static string graphResourceUri = "https://graph.windows.net";
        public const int USER_ACTIVE = 1;
        public const int USER_DEACTIVE = 0;
        public const int USER_DELETED = 2;
        public const string DefaultSecureKey = "VnrcViking";

        public const int PageSize = 10;

    }
    public class ApiStatusConstant
    {
        public const string SUCCESS = "SUCCESS";
        public const string FAIL = "FAIL";
        public const string LOST_CONNECTION = "LOST_CONNECTION";
    }
}
