using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    
        public class CustomStringLocalizer : IStringLocalizer
        {
            Dictionary<string, Dictionary<string, string>> resources;
            // ключи ресурсов
            const string HEADER = "Header";
            const string MESSAGE = "Message";

            public CustomStringLocalizer()
            {
                // словарь для английского языка
                Dictionary<string, string> enDict = new Dictionary<string, string>
            {
                {HEADER, "Italy" },
                {MESSAGE, "Italy is a country in south Europe and a member of the European Union. " +
                "The Italian flag is green, white and red. " +
                "Italy is a democratic republic and is a founding member of the European Union. " +
                "Its President is Sergio Mattarella and its Prime Minister is Giuseppe Conte." 
              }
            };
                // словарь для русского языка
                Dictionary<string, string> ruDict = new Dictionary<string, string>
            {
                {HEADER, "Италия" },
                {MESSAGE, "Италия - страна на юге Европы и член Европейского Союза."+ 
                " Итальянский флаг - зеленый, белый и красный."+ 
                "Италия - демократическая республика и является одним из основателей Европейского Союза. "+
                "Его президент - Серджио Маттарелла, а премьер-министр - Джузеппе Конте." }
            };
                // словарь для немецкого языка
                Dictionary<string, string> ukrDict = new Dictionary<string, string>
            {
                {HEADER, "Італія" },
                {MESSAGE, "Італія - ​​країна на півдні Європи та член Європейського Союзу. "+
                " Прапор Італії - зелений, білий та червоний." +
                "Італія є демократичною республікою і є членом-засновником Європейського Союзу." +
                "Її президентом є Серхіо Маттарелла, а прем'єр-міністром - Джузеппе Конте." }
            };
                // создаем словарь ресурсов
                resources = new Dictionary<string, Dictionary<string, string>>
            {
                {"en", enDict },
                {"ru", ruDict },
                {"uk", ukrDict }
            };
            }
            // по ключу выбираем для текущей культуры нужный ресурс
            public LocalizedString this[string name]
            {
                get
                {
                    var currentCulture = CultureInfo.CurrentUICulture;
                    string val = "";
                    if (resources.ContainsKey(currentCulture.Name))
                    {
                        if (resources[currentCulture.Name].ContainsKey(name))
                        {
                            val = resources[currentCulture.Name][name];
                        }
                    }
                    return new LocalizedString(name, val);
                }
            }

            public LocalizedString this[string name, params object[] arguments] => throw new NotImplementedException();

            public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
            {
                throw new NotImplementedException();
            }

            public IStringLocalizer WithCulture(CultureInfo culture)
            {
                return this;
            }
        }
    
}
