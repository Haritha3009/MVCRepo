using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.display("haritha");
        }
       public void display(string k)
        {
            Console.WriteLine(k);
            Console.ReadLine();
        }
    }
}
