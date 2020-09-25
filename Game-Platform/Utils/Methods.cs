using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Platform.Games.CosmosMemory.Utils
{
    public static class Methods
    {
        public static List<String> Shuffle(List<String> items)
        {
            var list = items;
            var rnd = new Random();

            var query =
                from i in list
                let r = rnd.Next()
                orderby r
                select i;

            return query.ToList();
        }


        public static List<String> SplitAndDuplicate(List<String> list, int n)
        {
            List<string> Splipted = new List<string>();
            for (int i = 0; i < n; i++)
            {
                Splipted.Add(list[i]);
                Splipted.Add(list[i]);
            }
            return Splipted;
        }

        public static string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
    }
}
