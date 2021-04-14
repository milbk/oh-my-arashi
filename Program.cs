using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace oh_my_arashi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Oh-My-Arashi");
            Console.WriteLine("-------------------");
            var color = Console.ForegroundColor;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("当前还不支持在 Windows 环境下运行。");
                Console.WriteLine("Currently not support Windows.");
                Console.ForegroundColor = color;
                Console.WriteLine("-------------------");
                return;
            }

            if (getuid() != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("请使用 Root 权限或 Sudo 运行本程序。");
                Console.WriteLine("Please use Root permission or Sudo to run. ");
                Console.ForegroundColor = color;
                Console.WriteLine("-------------------");
                return;
            }

            var jsonStr = Regex.Replace(Encoding.UTF8.GetString(
                    new WebClient { Headers = { ["User-Agent"] = "Oh-My-Arashi/0.1" } }.DownloadData(
                        "https://api.github.com/repos/mili-tan/ArashiDNS.AOI/releases/latest")),
                @"[\u4e00-\u9fa5|\u3002|\uff0c]", "");
            var assets = JObject.Parse(jsonStr)["assets"];
            var downloadUrl = assets.FirstOrDefault()["browser_download_url"].ToString();
            Console.WriteLine(downloadUrl);
        }

        [DllImport("libc")]
        public static extern uint getuid();
    }
}
