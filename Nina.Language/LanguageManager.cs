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
        public LanguageManager(string language)
        {

        }
        private LanguageManager _Instance { get; set; }
        //public LanguageManager Instance
        //{
        //    get
        //    {
        //        return _Instance;
        //    }
        //    set
        //    {
        //        this._Instance = this.SetLanguage();
        //    }
        //}
        public LanguageManager GetLanguage(UIControlledApplication application)
        {
            string lang = application.ControlledApplication.Language.ToString();
            return new LanguageManager(lang);
        }
        public Dictionary<string,string> Dictionary { get; set; }
        public string GetWordByKey(Dictionary<string,string> dictionary, string key)
        {
            if (dictionary[key] != null) return dictionary[key];
            else return "";
        }

    }
}
