namespace MyXF.Client.mobilebase.Helper
{
    public class GlobalSetting
    {
        private static readonly GlobalSetting _instance = new GlobalSetting();
        public static GlobalSetting Instance
        {
            get { return _instance; }
        }
        public string LoadingText { get { return "Loading.."; } }
        public string BaseEndpoint { get; set; }
        public bool UseNativeHttpHandler => false;
        public string ViewsPath { get; set; } = "Views";
        public string PagesPath { get; set; } = "Pages";
        public string ViewModelPath { get; set; } = "ViewModels";
    }
}
