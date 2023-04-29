namespace SwagLabs_UI.source.main.utils
{
    internal class Variables
    {
        public const string GOOGLE_CHROME = "GC";
        public const string FIREFOX = "FF";
        public const string INTERNET_EXPLORER = "IE";
        public const string EDGE = "EG";


        /************************************************** CLUSTERS *******************************************************/
        public enum Clusters
        {
            Stage, Prod
        }

        public static readonly Dictionary<Clusters, string[][]> ClustersMap = CreateClustersMap();

        public static Dictionary<Clusters, string[][]> CreateClustersMap()
        {
            var map = new Dictionary<Clusters, string[][]>();
            map.Add(Clusters.Stage, new string[][]
            {
                new string[] { "https://www.saucedemo.com", "standard_user", "secret_sauce"},
                new string[] { "https://www.saucedemo.com", "locked_out_user", "secret_sauce"},
                new string[] { "https://www.saucedemo.com", "problem_user", "secret_sauce" }
            });
            return map;
        }

        public static readonly string[][] EnvSet = ClustersMap[Settings.CurrentCluster];


        /********************************************************************************************************/

        public static readonly string SWAGLABS_URL = EnvSet[0][0];

        public static readonly string MAIN_ACCOUNT = EnvSet[0][1];
        public static readonly string MAIN_PASSWORD = EnvSet[0][2];

        public static readonly string SECOND_ACCOUNT = EnvSet[1][1];
        public static readonly string SECOND_PASSWORD = EnvSet[1][2];

        public static readonly string NONEXISTENT_EMAIL = "nonexistingemail@domain.org";
        public static readonly string INCORRECT_PASSWORD = "NonExisting#123";
        
        public static readonly string FIRST_NAME = "Roma";
        public static readonly string LAST_NAME = "AQA";
        public static readonly string ZIP_CODE = "1231";

    }
}
