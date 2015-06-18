using System.Collections.Generic;

namespace AnkiTranslate
{
    public class Languages
    {
        // full list of supported languages here: msdn.microsoft.com/en-us/library/hh456380.aspx
        public void Populate()
        {
            var en = new ConfigClass.ComboboxItem { Text = "English", Value = "en" };
            var es = new ConfigClass.ComboboxItem { Text = "Spanish", Value = "es" };
            var bg = new ConfigClass.ComboboxItem { Text = "Bulgarian", Value = "bg" };
            var cn = new ConfigClass.ComboboxItem { Text = "Chinese", Value = "zh-CHS" };
            var tlh = new ConfigClass.ComboboxItem { Text = "Klingon", Value = "tlh" };

            ConfigClass.Languages = new List<ConfigClass.ComboboxItem> {en, es, bg, cn, tlh};
        }
    }
}
