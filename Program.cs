using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day19Assignment
{
    internal class Program
    {
        static void MyProperties(Source source,Destination destination)
        {
            PropertyInfo[] sourceProperties=typeof(Source).GetProperties();
            PropertyInfo[] destinationProperties=typeof(Destination).GetProperties();
            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                foreach (PropertyInfo destinationProperty in destinationProperties)
                {
                    if(sourceProperty.Name == destinationProperty.Name && sourceProperty.PropertyType==destinationProperty.PropertyType)
                    {
                        destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                        break;
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            Source source = new Source { Id=1,Name="SourceObject",Date=DateTime.Now,Description="This the source property"};
            Destination destination = new Destination { Id=0,Name="not assign",place="Not given",Distance=0};
            MyProperties(source, destination);
            Console.WriteLine("******** Property in Source *********");
            Console.WriteLine($"Date Time: {source.Date}");
            Console.WriteLine($"Description: {source.Description}");
            Console.WriteLine("******** Properties in Destination **********");
            Console.WriteLine($"Id: {destination.Id}");
            Console.WriteLine($"Name: {destination.Name}");
            Console.WriteLine($"Place: {destination.place}");
            Console.WriteLine($"Distance: {destination.Distance}");
            Console.ReadKey();


        }
    }
}
