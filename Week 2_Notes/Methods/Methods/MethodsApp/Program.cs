namespace MethodsApp;

public class Program
{
    static void Main(string[] args)
    {
        //var result = DoThis(10);
        var spartaPizza = OrderPizza(true, true, true, true);
        Console.WriteLine(spartaPizza);

        (string , string , int ) myTuple = ("Kai", "Chan", 60);

        Console.WriteLine(myTuple);
        Console.WriteLine(myTuple.Item1);

        (string title,int copies) = ("Lord of the Rings", 3);
        Console.WriteLine(title);
        Console.WriteLine(copies);
    }


    //// Optional parameters must appear after other parameters
    //public static int DoThis(int x, string y = "Sad")
    //{
        //Console.WriteLine($"I'm feeling {y}");
        //return x * x;
    //}



    // Method overload 
    public static int Add(int num1, int num2)
    {
        return num1 + num2;
    }

    public static int Add(int num1, int num2, int num3)
    {
        return num1 + num2 + num3;
    }



    public static string OrderPizza(bool pepperoni, bool chicken, bool jalapenos, bool kiwi)
    {
        var pizza = "Pizza with tomato sauce, cheese, ";
        if (pepperoni) pizza += "pepperoni, ";
        if (chicken) pizza += "chicken, ";
        if (jalapenos) pizza += "jalapenos, ";
        if (kiwi) pizza += "kiwi, ";

        return pizza.Remove(pizza.Length - 2, 2);

    }

}
