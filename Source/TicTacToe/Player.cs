using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private char _token;
        public char Token
        {
            get { return _token; }
            set { _token = value; }
        }
        
        // Constructor
        public Player(char token, string name)
        {
            _token = token;
            _name = name;
        }

        public int chooseCell() {
            int gridNumber;
            // only integer input is allowed
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out gridNumber);
            
            //user input can not parse to int or have a leading 0
            if (!result || input.StartsWith("0"))
            {
                return -1;
            }
            else
            {
                return gridNumber;
            }
        }

    }
}
