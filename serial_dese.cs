using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serial
{
    class serial_dese
    {

        public static void Serialize()
        {
            Person p = new Person();
            p.City = new City();
            p.Name = "raj";
            p.Age = 22;
            p.City.Name = "Bangalore";
            p.City.Population = 12131234;
            var b = new BinaryFormatter();
            Stream fs = new FileStream(@"C:\Training\EuroTraining\Files\newnewxml.txt", FileMode.Create, FileAccess.Write);
            //var serializer = new XmlSerializer(typeof(Person));
            //serializer.Serialize(fs, p);
            b.Serialize(fs, p);
            fs.Close();
            Console.WriteLine("object serialized");
            fs = new FileStream(@"C:\Training\EuroTraining\Files\newnewxml.txt", FileMode.Open, FileAccess.Read);
            //Person p1 = (Person)serializer.Deserialize(fs);
            Person p1 = (Person)b.Deserialize(fs);
            Console.WriteLine("deserialized object");
            Console.WriteLine(p1.Name);
            Console.WriteLine(p1.Age);
            Console.WriteLine(p1.City.Name);
            Console.WriteLine(p1.City.Population);
            //Console.WriteLine("deserialized object");
            //Console.WriteLine(p1.Name);
            //Console.WriteLine(p1.Age);
            //Console.WriteLine(p1.City.Name);
            //Console.WriteLine(p1.City.Population);

        }




        [Serializable]
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public City City { get; set; }

            public override string ToString()
            {
                StringBuilder str = new StringBuilder();

                str.AppendLine("Name: " + Name);
                str.AppendLine("Age: " + Age);
                str.AppendLine("City: " + City.Name);

                return str.ToString();
            }
        }

        [Serializable]
        public class City
        {
            public string Name { get; set; }
            public int Population { get; set; }
        }
    }
}

