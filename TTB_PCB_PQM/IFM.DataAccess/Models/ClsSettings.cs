namespace IFM.DataAccess.Models
{
    public class ClsSettings
    {
        public string UserName { get; set; }
        public IfmLanguage UserLang { get; set; }

        public ClsSettings()
        {
            UserLang = IfmLanguage.En;
            UserName = string.Empty;
        }
    }
}
