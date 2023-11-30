public class TPL
{
    //private static readonly object Lock = new object();  
    private static readonly SemaphoreSlim SemaphoreLock = new(5);


    public static Task RunExample1()
    {
        var tasks = new List<Task>();

        for (var i = 0; i < 10; i++)
        {
            var task = Task.Run(async () =>
            {
                //await SemaphoreLock.WaitAsync();

                Console.WriteLine($"Task {Task.CurrentId} starting...");
                Thread.Sleep(1000);
                Console.WriteLine($"Task {Task.CurrentId} finished.");

                //SemaphoreLock.Release();

            });
            tasks.Add(task);
        }
        return Task.WhenAll(tasks);
    }

    public static async Task RunExample2()
    {
        var initialTask = Task.Run(async () =>
        {
            // Perform some operation
            await Task.Delay(600);
            Console.WriteLine("Initial task running...");
            return 42; // returning some result
        });

        // Continuation tasks run only after the initial task is completed
        var continuation = initialTask.ContinueWith((antecedent) =>
        {
            // Extract result from the initial task
            var result = antecedent.Result;
            Console.WriteLine($"Initial task completed with result: {result}");

            // Example of parent-child relationship in tasks
            var task1 = Task.Factory.StartNew(async () =>
            {
                Console.WriteLine("Parent task 1 starting.");
                // Child tasks
                var childTasks = new Task[2];
                childTasks[0] = Task.Factory.StartNew(async () =>
                {
                    Console.WriteLine("Child task 1 starting");
                    await Task.Delay(Random.Shared.Next(1000, 2000));
                    Console.WriteLine("Child task 1 complete");
                }, TaskCreationOptions.AttachedToParent);
                childTasks[1] = Task.Factory.StartNew(async () =>
                {
                    Console.WriteLine("Child task 2 starting");
                    await Task.Delay(Random.Shared.Next(1000, 2000));
                    Console.WriteLine("Child task 2 complete");
                }, TaskCreationOptions.AttachedToParent);

                await Task.WhenAll(childTasks);
                Console.WriteLine("Parent task 1 completed.");
            }, TaskCreationOptions.AttachedToParent);

            var task2 = Task.Run(async () =>
            {
                Console.WriteLine("Task2 work starting");
                await Task.Delay(1000);
                Console.WriteLine("Task2 work done");
                /* Task 2 work */
            });
            var task3 = Task.Run(async () =>
            {
                Console.WriteLine("Task3 work starting");
                await Task.Delay(1800);
                Console.WriteLine("Task3 work done");
            });

            // Wait for all the continuation tasks to complete
            return Task.WhenAll(task1, task2, task3);

        }, TaskContinuationOptions.OnlyOnRanToCompletion);

        // Final task which runs after the continuation task
        var finalTask = continuation.ContinueWith(async (_) =>
        {
            await Task.Delay(300);
            Console.WriteLine("All tasks completed.");
        });

        try
        {
            await finalTask; // Wait for the final task to complete
        }
        catch (AggregateException ae)
        {
            ae.Handle((x) =>
            {
                if (x is InvalidOperationException) // Specific exception handling
                {
                    Console.WriteLine($"Exception caught: {x.Message}");
                    return true;
                }
                return false; // Other exceptions are not handled here
            });
        }
    }

}