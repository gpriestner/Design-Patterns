namespace _06_Observer;

using System;
using System.Collections.Generic;

// Subject: The subject that maintains a list of observers and notifies them of changes
public class Subject
{
    private List<IObserver> observers = new List<IObserver>();
    private int state;

    public int State
    {
        get { return state; }
        set
        {
            state = value;
            NotifyObservers();
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}

// Observer: The observer interface
public interface IObserver
{
    void Update();
}

// Concrete Observer 1
public class ConcreteObserverA : IObserver
{
    private readonly Subject subject;

    public ConcreteObserverA(Subject subject)
    {
        this.subject = subject;
        subject.Attach(this);
    }

    public void Update()
    {
        Console.WriteLine($"Observer A: Subject's state is now {subject.State}");
    }
}

// Concrete Observer 2
public class ConcreteObserverB : IObserver
{
    private readonly Subject subject;

    public ConcreteObserverB(Subject subject)
    {
        this.subject = subject;
        subject.Attach(this);
    }

    public void Update()
    {
        Console.WriteLine($"Observer B: Subject's state is now {subject.State}");
    }
}

class Client
{
    static void Main()
    {
        // Creating the subject
        Subject subject = new Subject();

        // Creating observers and attaching them to the subject
        ConcreteObserverA observerA = new ConcreteObserverA(subject);
        ConcreteObserverB observerB = new ConcreteObserverB(subject);

        // Modifying the subject's state, which will notify the observers
        subject.State = 5;
        subject.State = 10;

        // Detaching an observer
        subject.Detach(observerA);

        // Modifying the subject's state again
        subject.State = 15;
    }
}
