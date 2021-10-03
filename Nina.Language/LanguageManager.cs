using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;

namespace Nina.Language
{
    public class LanguageManager
    {
        public UIControlledApplication UIApp { get; set; }
        public LanguageManager (UIControlledApplication app)
        {
            this.UIApp = app;
        }
        public string LanguageName { get; set; }
        private Dictionary<string, string> _Instance { get; set; }
        public Dictionary<string, string> Instance
        {
            get
            {
                return _Instance;
            }
            set
            {
                this._Instance = this.GetLanguage();
            }
        }
        public Dictionary<string, string> GetLanguage()
        {
            this.LanguageName = this.UIApp.ControlledApplication.Language.ToString();
            return new Dictionary<string, string>();
        }
        public Dictionary<string,string> Dictionary { get; set; }
        public string GetWordByKey(string key)
        {
            if (this.Dictionary[key] != null) return this.Dictionary[key];
            else return "";
        }

    }
}
