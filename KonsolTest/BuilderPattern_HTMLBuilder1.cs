using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builders.BuilderPattern_HTMLBuilder1
{

    public class HTMLElement
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public List<HTMLElement> Elements { get; set; } = new List<HTMLElement>();
        public HTMLElement(string name,string content)
        {
            this.Name = name;
            this.Content = content;
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int tab = Elements.Count()>0?0:4;

            sb.AppendLine($"{new string(' ',tab)}<{Name}>");
            if (!string.IsNullOrWhiteSpace(Content))
            {
                sb.AppendLine($"{new string(' ',tab*2)}{Content}");
            }
            foreach (var element in Elements)
            {
                sb.AppendLine($"{new string(' ', tab)}{element.ToString()}");
            }
            sb.Append($"{new string(' ', tab)}</{Name}>");
            return sb.ToString();
        }
    }

    public class HTMLBuilder
    {
        private readonly HTMLElement _rootElement = new HTMLElement("HTML","");
        public HTMLBuilder(string rootName)
        {
            this._rootElement.Name = rootName;
            this._rootElement.Content = string.Empty;
        }

        public void AddChild(string childName, string childContent)
        {
            _rootElement.Elements.Add(new HTMLElement(childName, childContent));
        }

        override public string ToString()
        {
            return _rootElement.ToString();
        }
    }

    public class BuilderPattern_HTMLBuilder1
    {
        public static void Execute()
        {
            Console.WriteLine("##################### non-fluent builder pattern #####################");

            var builder = new HTMLBuilder("ul");
            builder.AddChild("li", "fox");
            builder.AddChild("li", "wolf");
            builder.AddChild("li", "dog");
            Console.WriteLine(builder.ToString());

        }
    }
}
