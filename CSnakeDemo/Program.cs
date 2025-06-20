using CSnakes.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;

namespace CSnakeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var builder = Host.CreateApplicationBuilder(args);
            var home = Path.Join(Environment.CurrentDirectory, ""); /* Path to your Python modules */
            builder.Services
                .WithPython()
                
                .WithHome(home)
               .WithVirtualEnvironment(Path.Join(home, ".venv"))
               .FromRedistributable()
    .WithPipInstaller(); // Download Python 3.12 and store it locally

            var app = builder.Build();

            var env = app.Services.GetRequiredService<IPythonEnvironment>();
            var ss = env.Face().DetectFaces("2.png");
            Console.WriteLine(ss.ToString()) ;
            foreach (var item in ss)
            {
                Console.WriteLine(item.ToString());
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1.Value+" "+item1.Key);
                }
            }

        }
       
    }

}
