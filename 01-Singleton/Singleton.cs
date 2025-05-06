namespace _01_Singleton;

class Singleton
{
    private static Singleton instance = new Singleton();

    private Singleton() { }

    public static Singleton Instance => instance;
}

class Client
{
    static void Main()
    {
        // var s = new Singleton();

        var s1 = Singleton.Instance;

        var s2 = Singleton.Instance;

        if (s1 != s2)
            Console.WriteLine("Different");
        else
            Console.WriteLine("Same");
    }
}