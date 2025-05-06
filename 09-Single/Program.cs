namespace _09_Single;

class Singleton
{
    private static Singleton instance = null;
    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (instance == null) instance = new Singleton();
            return instance;
        }
    }
}

class Client
{
    static void Main()
    {
        var s1 = Singleton.Instance;

        var s2 = Singleton.Instance;

        if (s1 == s2)
            Console.WriteLine("Same");
        else
            Console.WriteLine("Different");
    }
}