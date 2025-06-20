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
            //出现一下出错的时候需要修改face_recognition_models加载模型的源码pkg_resources这个模块已经被弃用了
            //Please install `face_recognition_models` with this command before using `face_recognition`:

            //pip install git + https://github.com/ageitgey/face_recognition_models
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
