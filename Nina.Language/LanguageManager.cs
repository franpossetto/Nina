using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using System.IO;
using Newtonsoft.Json;
using static System.Environment;
using Nina.Ribbon;

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

        public string Path { get; set; }
        private List<ButtonInfo> _Instance { get; set; }
        public List<ButtonInfo> Instance
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
        public List<ButtonInfo> GetLanguage()
        {
            this.LanguageName = this.UIApp.ControlledApplication.Language.ToString();

            string path = $"{ GetFolderPath(SpecialFolder.CommonApplicationData) }/Autodesk/ApplicationPlugins/Nina.bundle/";

            switch (this.LanguageName)
            {
                case "English_USA":
                    this.Path = path + "English_USA.json";
                    break;
                case "English_GB":
                    this.Path = path + "English_GB.json";
                    break;
                case "Spanish":
                    this.Path = path + "Spanish.json";
                    break;

            }

            return JsonConvert.DeserializeObject<List<ButtonInfo>>(File.ReadAllText(this.Path));
        }
        public ButtonInfo GetButtonById(string key)
        {
            foreach(ButtonInfo btn in this.Instance) if (btn.Id == key) return btn;
            return new ButtonInfo();
        }

    }
}
