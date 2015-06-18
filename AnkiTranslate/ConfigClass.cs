using System.Collections.Generic;

namespace AnkiTranslate
{
    public class ConfigClass
    {
        public static string TextToTranslate { get; set; }
        public static string LanguageTranslatedFrom { get; set; }
        public static string TranslatedText { get; set; }
        public static string LanguageToTranslateTo { get; set; }

        public static List<ComboboxItem> Languages { get; set; }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }
    }
}
