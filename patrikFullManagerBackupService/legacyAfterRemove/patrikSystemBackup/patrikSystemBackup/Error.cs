using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patrikSystemBackup
{
    class Error
    {
               public static void error(int codeError, String error)
        {
            switch (codeError)
            {
                case 1:
                    Console.WriteLine("codigo : " + codeError + "\t error" + error);
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }
    }
}
