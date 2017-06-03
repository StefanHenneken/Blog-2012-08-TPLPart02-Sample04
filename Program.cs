using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public struct TaskPara
        {
            public string Name;
            public int Age;
        }

        static void Main(string[] args)
        {
            new Program().Run();
        }
        public void Run()
        {
            Console.WriteLine("Run Start");
            TaskPara taskPara;
            taskPara.Name = "Karl";
            taskPara.Age = 30;
            Task<string> task1 = Task<string>.Factory.StartNew((para) =>
                {
                    Thread.SpinWait(100000000);
                    return string.Format("{0} is {1} years old.", ((TaskPara)para).Name, ((TaskPara)para).Age);
                }, taskPara);
            Console.WriteLine("Result: {0}", task1.Result);
            Console.WriteLine("Run End");
            Console.ReadLine();
        }
    }
}
