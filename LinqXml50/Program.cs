using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqXml50
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "input.xml";
            string ouput = "ouput.xml";

            XDocument d = XDocument.Load(input);

            d.Root.AddFirst(new XElement("total-time",
             d.Root.Elements()
             .Select(e => (TimeSpan?)e.Attribute("time") ??
             new TimeSpan(24, 0, 0))
             .Aggregate(TimeSpan.Zero, (a, e) => a + e)));

            d.Save(ouput);

            Process.Start(input);
            Process.Start(ouput);
        }
    }
}
