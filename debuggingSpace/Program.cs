using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;


namespace debuggingSpace
{

    public class Program
    {
        static void Main(string[] args)
        {
            Registration.RegistrarClient rc = new Registration.RegistrarClient();
           
            var response = rc.GetGames(GameInfo.GameStatus.AVAILABLE);


            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
