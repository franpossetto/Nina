using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nina.Ribbon
{
    public partial class ButtonInfo
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("ButtonType")]
        public string ButtonType { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("LongDescription")]
        public string LongDescription { get; set; }

        [JsonProperty("ToolTipDescription")]
        public string ToolTipDescription { get; set; }

        
    }
}
