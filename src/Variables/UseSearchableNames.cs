using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace CleanCodeDotNet.Variables
{
    public enum PersonAccess : int
    {
        ACCESS_READ = 1,
        ACCESS_CREATE = 2,
        ACCESS_UPDATE = 4,
        ACCESS_DELETE = 8
    }

    /// <summary>
    /// Reference at https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data
    /// </summary>
    [DataContract]
    internal class Person
    {
        [DataMember]
        internal string Name { get; set; }

        [DataMember]
        internal int Age { get; set; }

        [DataMember]
        internal PersonAccess PersonAccess { get; set; }
    }

    public class UseSearchableNames
    {
        public UseSearchableNames()
        {
            UseSearchableNames1();
            UseSearchableNames2();
        }

        private void UseSearchableNames1()
        {
            // Bad
            // What the heck is data for?
            var data = new { Name = "John", Age = 42 };

            var stream1 = new MemoryStream();
            DataContractJsonSerializer ser1 = new DataContractJsonSerializer(typeof(object));
            ser1.WriteObject(stream1, data);

            stream1.Position = 0;
            var sr1 = new StreamReader(stream1);
            Console.Write("JSON form of Data object: ");
            Console.WriteLine(sr1.ReadToEnd());

            // Good
            var person = new Person
            {
                Name = "John",
                Age = 42
            };

            var stream2 = new MemoryStream();
            DataContractJsonSerializer ser2 = new DataContractJsonSerializer(typeof(Person));
            ser2.WriteObject(stream2, data);

            stream2.Position = 0;
            StreamReader sr2 = new StreamReader(stream2);
            Console.Write("JSON form of Data object: ");
            Console.WriteLine(sr2.ReadToEnd());
        }

        private void UseSearchableNames2()
        {
            // Bad
            var data = new { Name = "John", Age = 42, PersonAccess = 4};

            // What the heck is 4 for?
            if (data.PersonAccess == 4)
            {
                // do edit ...
            }

            // Good
            var person = new Person
            {
                Name = "John",
                Age = 42,
                PersonAccess= PersonAccess.ACCESS_CREATE
            };
            if (person.PersonAccess == PersonAccess.ACCESS_UPDATE)
            {
                // do edit ...
            }
        }
    }
}
