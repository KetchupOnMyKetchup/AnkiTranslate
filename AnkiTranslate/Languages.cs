using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkiTranslate
{
    public class Languages
    {
        public void Populate()
        {
            // initialize and populate new list string
            ConfigClass.Languages = new List<string>
            {
                // full list of choices here: msdn.microsoft.com/en-us/library/hh456380.aspx
                "ar",
                "bg",
                "ca",
                "zh-CHS",
                "zh-CHT",
                "cs",
                "da",
                "nl",
                "en", 
                "et",
                "fi",
                "fr",
                "es",
                "pl",
                "ru",
                "vi",
                // Last but not least..ah got some Klingon going on here!!! >.<
                "tlh"
            };
        }
    }
}
