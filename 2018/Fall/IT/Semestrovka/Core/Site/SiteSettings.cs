using Semestrovka.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestrovka.Site
{
    class SiteSettings : IParserSettings
    {
        public string BaseUrl { get; set; }
        public string Prefix { get; set; }

        public SiteSettings(string BaseUrl, string Prefix)
        {
            this.BaseUrl = BaseUrl;
            this.Prefix = Prefix;
        }
    }
}
