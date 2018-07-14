using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TicTacToe.startGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught unhandled exception: {0}", ex.Message);
                Console.ReadLine();
                throw;
            }
        }
    }
}
