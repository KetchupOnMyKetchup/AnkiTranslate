using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AnkiTranslate
{
    public class ConfigClass
    {
        public static string TextToTranslate { get; set; }
        public static string LanguageTranslatedFrom { get; set; }
        public static string TranslatedText { get; set; }
        public static string LanguageToTranslateTo { get; set; }

        public static List<string> Languages { get; set; }
    }
}
