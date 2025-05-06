namespace _04_Visitor;

using System;
using System.Collections.Generic;

// Element interface
interface IElement
{
    void Accept(IVisitor visitor);
}

// ConcreteElementA
class ConcreteElementA : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }

    public void OperationA()
    {
        Console.WriteLine("ConcreteElementA: OperationA");
    }
}

// ConcreteElementB
class ConcreteElementB : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementB(this);
    }

    public void OperationB()
    {
        Console.WriteLine("ConcreteElementB: OperationB");
    }
}

// Visitor interface
interface IVisitor
{
    void VisitConcreteElementA(ConcreteElementA elementA);
    void VisitConcreteElementB(ConcreteElementB elementB);
}

// ConcreteVisitor
class ConcreteVisitor : IVisitor
{
    public void VisitConcreteElementA(ConcreteElementA elementA)
    {
        Console.WriteLine("ConcreteVisitor: Visiting ConcreteElementA");
        elementA.OperationA();
    }

    public void VisitConcreteElementB(ConcreteElementB elementB)
    {
        Console.WriteLine("ConcreteVisitor: Visiting ConcreteElementB");
        elementB.OperationB();
    }
}

// ObjectStructure
class ObjectStructure
{
    private List<IElement> elements = new List<IElement>();

    public void Attach(IElement element)
    {
        elements.Add(element);
    }

    public void Detach(IElement element)
    {
        elements.Remove(element);
    }

    public void Accept(IVisitor visitor)
    {
        foreach (var element in elements)
        {
            element.Accept(visitor);
        }
    }
}

// Client
class Client
{
    static void Main()
    {
        ObjectStructure objectStructure = new ObjectStructure();
        objectStructure.Attach(new ConcreteElementA());
        objectStructure.Attach(new ConcreteElementB());

        ConcreteVisitor visitor = new ConcreteVisitor();

        objectStructure.Accept(visitor);
    }
}
