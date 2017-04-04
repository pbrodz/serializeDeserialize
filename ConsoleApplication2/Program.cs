using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //deserialize Json into objects
            string json = @"{'t':'1339886','a':true}";
            MyData tmp = JsonConvert.DeserializeObject<MyData>(json);
            Console.WriteLine($"Original JSon string is: {json}");
            Console.WriteLine($"Serialized value of t is: {tmp.t} and a is: {tmp.a}");
            Console.WriteLine();

            //deserialize XML into objects
            string xmlString = "<Products><Product><Id>1</Id><Name>My XML product</Name></Product><Product><Id>2</Id><Name>My second product</Name></Product></Products>";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));
            StringReader stringReader = new StringReader(xmlString);
            List<Product> productList = (List<Product>)serializer.Deserialize(stringReader);
            Console.WriteLine($"The original XML string is: {xmlString}");
            foreach (var item in productList)
                Console.WriteLine($"List Item Id: {item.Id} and Name: {item.Name}");
            Console.WriteLine();

            //serialize objects into Json
            List<MyData> myNewData = new List<MyData> { new MyData() { t = "Kindle", a = true } };
            string JSonString = JsonConvert.SerializeObject(myNewData);
            foreach (var item in myNewData)
                Console.WriteLine($"List Item t is: {item.t} and a is: {item.a}");
            Console.WriteLine($"The serialized JSon is: {JSonString}");
            //serialize objects into Xml
            XmlSerializer x = new XmlSerializer(myNewData.GetType());
            Console.WriteLine("And into XML it is:");
            x.Serialize(Console.Out, myNewData);

            Console.ReadLine();
        }
    }
}
