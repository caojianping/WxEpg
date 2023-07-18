using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WxEpg.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ids = new List<int>() { 10, 11, 12, 13 };
            Console.WriteLine(string.Join(",", ids.ToArray()));
            Console.ReadKey();
        }
    }
}
