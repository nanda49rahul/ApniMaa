using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApniMaa.Globalization
{
    public class GlobalizationCulture
    {
        public static string GetResxValByKey(string key, string lang = "en-US")
        {
            string baseName = string.Empty;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            if (lang.Equals("fr-FR"))
                baseName = "ApniMaa.Globalization.fr-FR";
            if (lang.Equals("en-US"))
                baseName = "ApniMaa.Globalization.en-US";
            if (string.IsNullOrEmpty(baseName))
                return string.Empty;

            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(baseName, (new GlobalizationCulture()).GetType().Assembly);

            var entry =
                rm.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true)
                  .OfType<DictionaryEntry>()
                  .FirstOrDefault(e => e.Key.ToString() == key);

            var value = entry.Value.ToString();
            return value;

        }
    }
}
