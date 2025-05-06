namespace _03_Iterator;

using System;
using System.Collections;

// Aggregate
interface IAggregate
{
    IIterator CreateIterator();
}

// ConcreteAggregate
class ConcreteAggregate : IAggregate
{
    private ArrayList items = new ArrayList();
    // private List<object> items = new List<object>();

    public void Add(object item)
    {
        items.Add(item);
    }

    public int Count
    {
        get { return items.Count; }
    }

    public object this[int index]
    {
        get { return items[index]; }
        set { items.Insert(index, value); }
    }

    public IIterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }
}

// Iterator
interface IIterator
{
    object First();
    object Next();
    bool IsDone();
    object CurrentItem();
}

// ConcreteIterator
class ConcreteIterator : IIterator
{
    private ConcreteAggregate aggregate;
    private int currentIndex = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        this.aggregate = aggregate;
    }

    public object First()
    {
        currentIndex = 0;
        return aggregate[currentIndex];
    }

    public object Next()
    {
        currentIndex++;
        return (currentIndex < aggregate.Count) ? aggregate[currentIndex] : null;
    }

    public bool IsDone()
    {
        return currentIndex >= aggregate.Count;
    }

    public object CurrentItem()
    {
        return aggregate[currentIndex];
    }
}

// Client
class Client
{
    static void Main()
    {
        ConcreteAggregate aggregate = new ConcreteAggregate();
        aggregate.Add("Item 1");
        aggregate.Add("Item 2");
        aggregate.Add("Item 3");

        IIterator iterator = aggregate.CreateIterator();

        Console.WriteLine("Iterating over the collection:");
        for (var item = iterator.First(); !iterator.IsDone(); item = iterator.Next())
        {
            Console.WriteLine(item);
        }
    }
}
