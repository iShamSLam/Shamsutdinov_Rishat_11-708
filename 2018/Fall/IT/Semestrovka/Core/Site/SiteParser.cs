using AngleSharp.Dom.Html;
using Semestrovka.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestrovka.Site
{
    class SiteParser : IParser<string[]>
    {     
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("td");

            foreach (var item in items)
            {             
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
