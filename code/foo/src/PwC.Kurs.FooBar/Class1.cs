using Microsoft.Extensions.Logging;

namespace PwC.Kurs.FooBar;

public record Foo(string Bar);

public class Kurs
{
   
    public string ActualFoo { get; set; }
    private string _hidden = "";


    public void DoStuff(string name)
    {
        ActualFoo = name;
    }
}

public class Dummy
{
    public void Test()
    {
        var kurs = new Kurs();
        kurs.DoStuff("foo");
      

        kurs.SayHello();
        
        Console.WriteLine(kurs.ActualFoo); // foobar
    }

}


public static class KursExtensions
{
    public static void SayHello(this Kurs kurs)
    {
        Console.WriteLine(kurs.ActualFoo); // foo
        kurs.ActualFoo = "foobar";
  
    }
}
