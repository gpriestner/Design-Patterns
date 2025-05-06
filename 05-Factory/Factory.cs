namespace _05_Factory;

using System;

// Product: Vehicle interface
public interface IVehicle
{
    void Drive();
}

// Concrete Product 1: Car
public class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a car");
    }
}

// Concrete Product 2: Motorcycle
public class Motorcycle : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Riding a motorcycle");
    }
}

// Creator: VehicleFactory interface
public interface IVehicleFactory
{
    IVehicle CreateVehicle();
}

// Concrete Creator 1: CarFactory
public class CarFactory : IVehicleFactory
{
    public IVehicle CreateVehicle()
    {
        // Additional logic can be added here before creating and returning the instance
        return new Car();
    }
}

// Concrete Creator 2: MotorcycleFactory
public class MotorcycleFactory : IVehicleFactory
{
    public IVehicle CreateVehicle()
    {
        // Additional logic can be added here before creating and returning the instance
        return new Motorcycle();
    }
}

class Client
{
    static void Main()
    {
        // Using the Factory Method pattern
        IVehicleFactory carFactory = new CarFactory();
        IVehicle car = carFactory.CreateVehicle();
        car.Drive();

        IVehicleFactory motorcycleFactory = new MotorcycleFactory();
        IVehicle motorcycle = motorcycleFactory.CreateVehicle();
        motorcycle.Drive();
    }
}
