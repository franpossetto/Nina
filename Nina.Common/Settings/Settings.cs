using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Nina.Common
{
    public class Settings
    {
        public static Preferences Preferences
        {
            get
            {
                if (_Preferences == null) Init();
                return _Preferences;
            }
            set
            {
                _Preferences = value;
                Save();
            }
        }
        private static Preferences _Preferences { get; set; }

        public static string Path { get; } = @"C:\Nina\nina_settings.json";


        public static void Init()
        {
            if (File.Exists(Path)) _Preferences = new Preferences(JsonConvert.DeserializeObject<Preferences>(File.ReadAllText(Path)));
            else Preferences = new Preferences();
        }
        public static void Save() => File.WriteAllText(Path, JsonConvert.SerializeObject(_Preferences));
    }
    
}

