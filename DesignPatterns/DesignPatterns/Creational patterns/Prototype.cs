using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational_patterns
{
    //
    // Intent:
    //     Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.
    //     Co-opt one instance of a class for use as a breeder of all future instances.
    //     The new operator considered harmful.

    #region Person

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int IdNumber)
        {
            this.IdNumber = IdNumber;
        }
    }

    public class Person
    {
        public int Age;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person)MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person other = (Person)MemberwiseClone();
            other.IdInfo = new IdInfo(IdInfo.IdNumber);
            other.Name = Name;
            return other;
        }
    }

    #endregion

    #region Module

    // 1. The clone() contract
    public interface IPrototype
    {
        IPrototype Clone();
        string GetName();
        void Execute();
    }

    public class PrototypeModule
    {
        // 2. "registry" of prototypical objs
        private static readonly List<IPrototype> prototypes = new List<IPrototype>();

        // Adds a feature to the Prototype attribute of the PrototypesModule class
        // obj  The feature to be added to the Prototype attribute
        public static void AddPrototype(IPrototype p)
        {
            prototypes.Add(p);
        }

        public static IPrototype CreatePrototype(string name)
        {
            // 4. The "virtual ctor"
            foreach (IPrototype p in prototypes)
            {
                if (p.GetName().Equals(name))
                {
                    return p.Clone();
                }
            }
            Console.WriteLine($"    {name} doesn't exist");
            return null;
        }
    }

    // 5. Sign-up for the clone() contract.
    // Each class calls "new" on itself FOR the client.
    public class PrototypeAlpha : IPrototype
    {
        private readonly string Name = "Alpha Version";

        public IPrototype Clone()
        {
            return new PrototypeAlpha();
        }

        public void Execute()
        {
            Console.WriteLine($"    {Name} does something");
        }

        public string GetName()
        {
            return Name;
        }
    }

    public class PrototypeBeta : IPrototype
    {
        private readonly string Name = "Beta Version";

        public IPrototype Clone()
        {
            return new PrototypeBeta();
        }

        public void Execute()
        {
            Console.WriteLine($"    {Name} does something");
        }

        public string GetName()
        {
            return Name;
        }
    }

    public class ReleasePrototype : IPrototype
    {
        private readonly string Name = "Release Candidate";

        public IPrototype Clone()
        {
            return new ReleasePrototype();
        }

        public void Execute()
        {
            Console.WriteLine($"    {Name} does real work");
        }

        public string GetName()
        {
            return Name;
        }
    }

    #endregion
}
