Console.WriteLine("# Multithreading examples");
Console.WriteLine("## PLINQ");
PLINQ.RunExample(false);
PLINQ.RunExample(true);

Console.WriteLine("\n\nTPL Example 1");
await TPL.RunExample1();

Console.WriteLine("\n\nTPL Example 2");
await TPL.RunExample2();
