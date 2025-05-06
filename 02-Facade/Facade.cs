namespace _02_Facade;

using System;

// Subsystem
class SubsystemA
{
    public void OperationA()
    {
        Console.WriteLine("SubsystemA: OperationA");
    }
}

// Subsystem
class SubsystemB
{
    public void OperationB()
    {
        Console.WriteLine("SubsystemB: OperationB");
    }
}

// Subsystem
class SubsystemC
{
    public void OperationC()
    {
        Console.WriteLine("SubsystemC: OperationC");
    }
}

// Facade
class Facade
{
    private SubsystemA subsystemA;
    private SubsystemB subsystemB;
    private SubsystemC subsystemC;

    public Facade()
    {
        subsystemA = new SubsystemA();
        subsystemB = new SubsystemB();
        subsystemC = new SubsystemC();
    }

    public void Operation()
    {
        Console.WriteLine("Facade: Operation");

        subsystemA.OperationA();
        subsystemB.OperationB();
        subsystemC.OperationC();
    }
}

// Client
class Client
{
    static void Main()
    {
        // Using the Facade to simplify the subsystem usage
        Facade facade = new Facade();
        facade.Operation();
    }
}
