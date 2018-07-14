using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameBoard
    {
        private int _gridSize;
        private int _board_size;

        public int Board_Size
        {
            get { return _board_size; }
            set { _board_size = value; }
        }

        private Cell[,] _board;

        public Cell[,] Board
        {
            get { return _board; }
            set { _board = value; }
        }
        

        // Constructor
        public GameBoard() {
            Console.WriteLine("Set board size for your game, size should set in range (3, 10)");
            while (true)
            {
                string input = Console.ReadLine();

                // TODO try parse
                if (int.TryParse(input, out _gridSize) && !input.StartsWith("0"))
                {
                    if (_gridSize < 3 || _gridSize >10)
                    {
                        Console.WriteLine("Board can not be set too big or too small, size should set in range (3, 10)");
                    }
                    else
                    {
                        Console.WriteLine("You choosed {0}x{0} grid size", _gridSize);
                        break;
                    }
                }
                else {
                    Console.WriteLine("Please fill in integer");
                }
            }
            initializeBoard(_gridSize);
        }

        // Initializer all board fileds to EMPTY
        private void initializeBoard(int gridSize)
        {
            _board_size = gridSize;
            _board = new Cell[_board_size, _board_size];
            for (int i = 0; i < _board_size; i++)
            {
                for (int j = 0; j < _board_size; j++)
                {
                    _board[i, j] = new Cell();
                }
            }
        }

        // re-darw board method
        internal void printBoard()
        {
            Console.WriteLine();
            int fieldNumber = 1;
            int gap = Math.Pow(_board_size, 2).ToString().Length;
            
            for (int i = 0; i < _board_size; i++)
            {
                for (int j = 0; j < _board_size; j++)
                {
                    if (_board[i, j].isEmpty())
                    {
                        Console.Write("".PadRight(gap));
                        Console.Write(fieldNumber.ToString().PadRight(gap+1));
                    }
                    else {
                        Console.Write("".PadRight(gap));
                        Console.Write(((char)_board[i, j].CellValue).ToString().PadRight(gap+1));
                    }

                    fieldNumber++;

                    if (j < _board_size - 1) {
                        Console.Write('|');
                    }
                }

                Console.WriteLine();
                //calculate total - need to draw
                Console.Write(new string('-', ((2 * gap + 2) * _board_size)-1));
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //clear all console inputs
        internal void clearBoard()
        {
            Console.Clear();
        }

        //can only set TOKEN when field is empty
        internal bool canPutToken(Player currentPlayer, int fieldNumber)
        {
            //calculate current fieldNumber locating on which 2d array item
            int xAxis = (fieldNumber - 1) / _board_size;
            int yAsix = (fieldNumber - 1) % _board_size;
            if (_board[xAxis, yAsix].isEmpty())
            {
                _board[xAxis, yAsix].markField(currentPlayer);
                return true;
            }
            else {
                Console.WriteLine("\nThis box has been taken, please try another one\n");
                return false;
            }
        }
    }
}
