using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builders
{
    public class StringBuilder1
    {
        public static void Execute()
        {
            Console.WriteLine("\n##################### string builder #####################");

            var words = new[] { "fox", "wolf", "dog" };
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);
        }
    }
}
