using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Cell
    {
        private TOKEN _cellValue;
        public TOKEN CellValue
        {
            get { return _cellValue; }
            set { _cellValue = value; }
        }

        public Cell() {
            _cellValue = TOKEN.EMPTY;
        }

        public bool isEmpty() {
            if (_cellValue == TOKEN.EMPTY) {
                return true;
            }
            return false;
        }

        public void markField(Player player) {
            if (player.Token == 'X')
            {
                _cellValue = TOKEN.X;
            }
            else
            {
                _cellValue = TOKEN.O;
            }
        }
    }
}
