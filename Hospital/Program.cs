using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            File.Download(ref hospital);
            Run.RunProgram(ref hospital);
        }
    }
}
