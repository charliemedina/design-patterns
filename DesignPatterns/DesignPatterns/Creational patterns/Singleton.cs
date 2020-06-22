using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational_patterns
{
    //
    // Intent:
    //     Ensure a class has only one instance, and provide a global point of access to it.
    //     Encapsulated "just-in-time initialization" or "initialization on first use".
    public class Singleton
    {
        private Singleton()
        {
        }

        private static Singleton _instance;

        public static Singleton GetSingleton()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}
