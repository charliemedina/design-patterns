using DesignPatterns.Creational_patterns;
using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    class Program
    {
        static void Main()
        {
            /********** Creationals Patterns **********/

            #region Singleton

            Console.WriteLine("**********    Singleton pattern   **********\n");
            var s1 = Singleton.GetSingleton();
            var s2 = Singleton.GetSingleton();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }

            #endregion

            #region Prototype

            Console.WriteLine("\n**********    Prototype pattern   **********\n");

            // Create an instance of Person and assign values to its fields.
            Person p1 = new Person
            {
                Age = 42,
                Name = "Sam",
                IdInfo = new IdInfo(6565)
            };

            // Perform a shallow copy of p1 and assign it to p2.
            Person p2 = p1.ShallowCopy();

            // Display values of p1, p2
            Console.WriteLine("Original values of p1 and p2:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);

            // Change the value of p1 properties and display the values of p1 and p2.
            p1.Age = 32;
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nValues of p1 and p2 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);

            // Make a deep copy of p1 and assign it to p3.
            Person p3 = p1.DeepCopy();
            // Change the members of the p1 class to new values to show the deep copy.
            p1.Name = "George";
            p1.Age = 39;
            p1.IdInfo.IdNumber = 8641;
            Console.WriteLine("\nValues of p1 and p3 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            Console.WriteLine("\nTest PrototypeModule");
            var protoNames = new[] { "Garbage", "Alpha Version", "Beta Version", "Nothing", "Release Candidate" };
            InitializePrototypes();

            List<IPrototype> prototypes = new List<IPrototype>();

            // 6. Client does not use "new"
            foreach (var protoName in protoNames)
            {
                IPrototype prototype = PrototypeModule.CreatePrototype(protoName);
                if (prototype != null)
                {
                    prototypes.Add(prototype);
                }
            }

            foreach (var p in prototypes)
            {
                p.Execute();
            }

            static void DisplayValues(Person p)
            {
                Console.WriteLine("      Name: {0:s}, Age: {1:d}", p.Name, p.Age);
                Console.WriteLine("      Value: {0:d}", p.IdInfo.IdNumber);
            }

            // 3. Populate the "registry"
            static void InitializePrototypes()
            {
                PrototypeModule.AddPrototype(new PrototypeAlpha());
                PrototypeModule.AddPrototype(new PrototypeBeta());
                PrototypeModule.AddPrototype(new ReleasePrototype());
            }

            #endregion

            #region Factory Method

            Console.WriteLine("\n**********    Factory Method pattern   **********");
            new FactoryMethodClient().Main();

            #endregion

            #region Abstract Factory 

            Console.WriteLine("\n**********    Abstract Factory pattern   **********");
            new AbstractFactoryClient().Main();

            IMobilePhone nokiaMobilePhone = new Nokia();
            MobileClient nokiaClient = new MobileClient(nokiaMobilePhone);

            Console.WriteLine("\nPhones Abtract Factorty");

            Console.WriteLine("\nNOKIA");
            Console.WriteLine(nokiaClient.GetSmartPhoneModelDetails());
            Console.WriteLine(nokiaClient.GetNormalPhoneModelDetails());

            Console.WriteLine("-----------------------");

            IMobilePhone samsungMobilePhone = new Samsung();
            MobileClient samsungClient = new MobileClient(samsungMobilePhone);

            Console.WriteLine("\nSAMSUNG");
            Console.WriteLine(samsungClient.GetSmartPhoneModelDetails());
            Console.WriteLine(samsungClient.GetNormalPhoneModelDetails());

            #endregion

            #region Builder

            Console.WriteLine("\n**********    Builder pattern   **********\n");

            // The client code creates a builder object, passes it to the
            // director and then initiates the construction process. The end
            // result is retrieved from the builder object.
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Standard basic product:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Standard full featured product:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            // Remember, the Builder pattern can be used without a Director
            // class.
            Console.WriteLine("Custom product:");
            builder.BuildPartA();
            builder.BuildPartC();
            Console.Write(builder.GetProduct().ListParts());

            #endregion
        }
    }
}
