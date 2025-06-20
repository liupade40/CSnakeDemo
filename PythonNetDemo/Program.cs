using Python.Runtime;

namespace PythonNetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //出现以下出错的时候需要修改face_recognition_models加载模型的源码pkg_resources这个模块已经被弃用了
            //Please install `face_recognition_models` with this command before using `face_recognition`:

            //pip install git + https://github.com/ageitgey/face_recognition_models
            Runtime.PythonDLL = @"C:\Users\xxxx\AppData\Local\Programs\Python\Python312\python312.dll";
            PythonEngine.PythonHome = @"D:\repos\CSnakeDemo\PythonNetDemo\python\venv\Scripts\python.exe";
            PythonEngine.PythonPath = @"D:\repos\CSnakeDemo\PythonNetDemo\python;D:\repos\CSnakeDemo\PythonNetDemo\python\venv;D:\repos\CSnakeDemo\PythonNetDemo\python\venv\Lib;D:\repos\CSnakeDemo\PythonNetDemo\python\venv\Lib\site-packages;C:\Users\xxxx\AppData\Local\Programs\Python\Python312\Lib;C:\Users\xxxx\AppData\Local\Programs\Python\Python312\Lib\site-packages;C:\Users\xxxx\AppData\Local\Programs\Python\Python312\DLLs";
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                dynamic face = Py.Import("face");
                dynamic ss = face.detect_faces("2.png");
                Console.WriteLine(ss.ToString());
                foreach (dynamic item in ss)
                {

                    foreach (var item1 in item)
                    {
                        Console.WriteLine($"{item1}= {item[item1]}");
                    }
                }
            }
            AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", true);
            PythonEngine.Shutdown();
            AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", false);
            Console.ReadKey();
        }
        // 参考文章
        // https://www.cnblogs.com/gnix-a/p/18631116
        //https://blog.csdn.net/mingupup/article/details/144532671

        //        await Task.Run(() =>
        //{
        //            try
        //            {
        //                using (Py.GIL())
        //                {
        //                    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} python脚本准备执行");
        //                    dynamic asyncio = Py.Import("asyncio");  // 导入异步模块
        //                    dynamic pylab = Py.Import(scriptName);   // 导入模块（传入py文件名即可）
        //                    dynamic py = asyncio.run(pylab.main());  // 执行该py脚本的异步main函数
        //                    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} 执行python脚本成功，返回值：{py}");
        //                    result = (int)py == 0;
        //                }
        //            }
        //            catch (PythonException ex)
        //            {
        //                Console.WriteLine(ex.ToString());
        //            }
        //        });
        //我们将Python的异步编程模块："asyncio"导入后，调用 asyncio.run(pylab.main()); 将目标模块的main方法作为参数传入，这样我们才能在python脚本执行之后拿到执行结果，相当于C#同步调用异步方法，等待方法执行完毕（否则会直接返回！！！）。
    }
}
