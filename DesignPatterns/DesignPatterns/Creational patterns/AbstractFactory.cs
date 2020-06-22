using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational_patterns
{
    //
    // Intent:
    //     Provide an interface for creating families of related or dependent objects without specifying their concrete classes.
    //     A hierarchy that encapsulates: many possible "platforms", and the construction of a suite of "products".
    //     The new operator considered harmful.

    #region Creator 

    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();

        IAbstractProductB CreateProductB();

        IAbstractProductC CreateProductC();
    }

    class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }

        public IAbstractProductC CreateProductC()
        {
            return new ConcreteProductC1();
        }
    }

    class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }

        public IAbstractProductC CreateProductC()
        {
            return new ConcreteProductC2();
        }
    }

    public interface IAbstractProductA
    {
        string UsefulFunctionA();
    }

    public interface IAbstractProductB
    {
        string UsefulFunctionB();
    }

    public interface IAbstractProductC
    {
        string UsefulFunctionC();

        string AnotherUsefulFunctionB(IAbstractProductA collaborator);
    }

    class ConcreteProductA1 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "The result of the product A1";
        }
    }

    class ConcreteProductB1 : IAbstractProductB
    {
        public string UsefulFunctionB()
        {
            return "   The result of the product B1";
        }
    }

    class ConcreteProductC1 : IAbstractProductC
    {
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UsefulFunctionA();

            return $"   The result of the C1 collaborating with the ({result}).";
        }

        public string UsefulFunctionC()
        {
            return "   The result of the product C1.";
        }
    }

    class ConcreteProductA2 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "The result of the product A2";
        }
    }

    class ConcreteProductB2 : IAbstractProductB
    {
        public string UsefulFunctionB()
        {
            return "   The result of the product B2";
        }
    }

    class ConcreteProductC2 : IAbstractProductC
    {
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UsefulFunctionA();

            return $"   The result of the C2 collaborating with the ({result}).";
        }

        public string UsefulFunctionC()
        {
            return "   The result of the product C2.";
        }
    }

    class AbstractFactoryClient
    {
        public void Main()
        {
            // The client code can work with any concrete factory class.
            Console.WriteLine("\nClient: Testing client code with the first factory type...");
            ClientMethod(new ConcreteFactory1());

            Console.WriteLine("\nClient: Testing the same client code with the second factory type...");
            ClientMethod(new ConcreteFactory2());
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();
            var productC = factory.CreateProductC();

            Console.WriteLine(productB.UsefulFunctionB());
            Console.WriteLine(productC.UsefulFunctionC());
            Console.WriteLine(productC.AnotherUsefulFunctionB(productA));
        }
    }

    #endregion

    #region Phones

    /// <summary>  
    /// The 'AbstractFactory' interface.  
    /// </summary>  
    interface IMobilePhone
    {
        ISmartPhone GetSmartPhone();
        INormalPhone GetNormalPhone();
    }

    /// <summary>  
    /// The 'ConcreteFactory1' class.  
    /// </summary>  
    class Nokia : IMobilePhone
    {
        public ISmartPhone GetSmartPhone()
        {
            return new NokiaPixel();
        }

        public INormalPhone GetNormalPhone()
        {
            return new Nokia1600();
        }
    }

    /// <summary>  
    /// The 'ConcreteFactory2' class.  
    /// </summary>  
    class Samsung : IMobilePhone
    {
        public ISmartPhone GetSmartPhone()
        {
            return new SamsungGalaxy();
        }

        public INormalPhone GetNormalPhone()
        {
            return new SamsungGuru();
        }
    }

    /// <summary>  
    /// The 'AbstractProductA' interface  
    /// </summary>  
    interface ISmartPhone
    {
        string GetModelDetails();
    }

    /// <summary>  
    /// The 'AbstractProductB' interface  
    /// </summary>  
    interface INormalPhone
    {
        string GetModelDetails();
    }

    /// <summary>  
    /// The 'ProductA1' class  
    /// </summary>  
    class NokiaPixel : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "Model: Nokia Pixel\nRAM: 3GB\nCamera: 8MP\n";
        }
    }

    /// <summary>  
    /// The 'ProductA2' class  
    /// </summary>  
    class SamsungGalaxy : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Galaxy\nRAM: 2GB\nCamera: 13MP\n";
        }
    }

    /// <summary>  
    /// The 'ProductB1' class  
    /// </summary>  
    class Nokia1600 : INormalPhone
    {
        public string GetModelDetails()
        {
            return "Model: Nokia 1600\nRAM: NA\nCamera: NA\n";
        }
    }

    /// <summary>  
    /// The 'ProductB2' class  
    /// </summary>  
    class SamsungGuru : INormalPhone
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Guru\nRAM: NA\nCamera: NA\n";
        }
    }

    /// <summary>  
    /// The 'Client' class  
    /// </summary>  
    class MobileClient
    {
        readonly ISmartPhone smartPhone;
        readonly INormalPhone normalPhone;

        public MobileClient(IMobilePhone factory)
        {
            smartPhone = factory.GetSmartPhone();
            normalPhone = factory.GetNormalPhone();
        }

        public string GetSmartPhoneModelDetails()
        {
            return smartPhone.GetModelDetails();
        }

        public string GetNormalPhoneModelDetails()
        {
            return normalPhone.GetModelDetails();
        }
    }

    #endregion
}
