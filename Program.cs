using System;
using System.Net;
using System.Runtime.InteropServices;

namespace oh_my_arashi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Oh-My-Arashi");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WriteLine("当前还不支持在 Windows 环境下运行。");
                Console.WriteLine("Currently not support Windows.");
                return;
            }

            if (getuid() != 0)
            {
                Console.WriteLine("请使用 Root 权限或 Sudo 运行本程序。");
                Console.WriteLine("Please use Root permission or Sudo to run. ");
                return;
            }

            
        }

        [DllImport("libc")]
        public static extern uint getuid();
    }
}
