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
            // initialize new list string
            ConfigClass.Languages = new List<string>();

            // populate new list string
            ConfigClass.Languages.Add("bg");
            ConfigClass.Languages.Add("en");
            ConfigClass.Languages.Add("es");

        }
    }
}
