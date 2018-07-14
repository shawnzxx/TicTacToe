using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Checker
    {
        // check win logic main entry
        static public bool checkWin(GameBoard gameBoard)
        {
            return (checkHorizontallyForWin(gameBoard) || checkVerticallyForWin(gameBoard) || checkDiagonallyForWin(gameBoard));
        }
        // check draw logic main entry
        static public bool checkDraw(int moveCounter, GameBoard gameBoard)
        {
            return moveCounter == Math.Pow(gameBoard.Board_Size, 2) ? true : false;
        }

        //check any 3 same TOKENS were set horizontally
        private static bool checkHorizontallyForWin(GameBoard gameBoard)
        {
            for (int j = 0; j + 2 < gameBoard.Board_Size; j++)
            {
                for (int i = 0; i < gameBoard.Board_Size; i++)
                {
                    if (check3InRow(gameBoard.Board[i, j].CellValue, gameBoard.Board[i, j + 1].CellValue, gameBoard.Board[i, j + 2].CellValue)) {
                        return true;
                    }
                }
            }
            return false;
        }

        //check any 3 same TOKENS were set vertically
        private static bool checkVerticallyForWin(GameBoard gameBoard)
        {
            for (int j = 0; j + 2 < gameBoard.Board_Size; j++)
            {
                for (int i = 0; i < gameBoard.Board_Size; i++)
                {
                    if (check3InRow(gameBoard.Board[j, i].CellValue, gameBoard.Board[j + 1, i].CellValue, gameBoard.Board[j + 2, i].CellValue)) {
                        return true;
                    }
                }
            }
            return false;
        }

        //check any 3 same TOKENS were set diagonally
        private static bool checkDiagonallyForWin(GameBoard gameBoard)
        {
            for (int i = 0; i + 2 < gameBoard.Board_Size; i++)
            {
                for (int j = 0; j + 2 < gameBoard.Board_Size; j++)
                {
                    if (check3InRow(gameBoard.Board[i, j].CellValue, gameBoard.Board[i + 1, j + 1].CellValue, gameBoard.Board[i + 2, j + 2].CellValue)) {
                        return true;
                    }
                }
            }
            for (int i = 0; i + 2 < gameBoard.Board_Size; i++)
            {
                for (int j = gameBoard.Board_Size - 1; j - 1 > 0; j--)
                {
                    if (check3InRow(gameBoard.Board[i, j].CellValue, gameBoard.Board[i + 1, j - 1].CellValue, gameBoard.Board[i + 2, j - 2].CellValue)) {
                        return true;
                    }
                }
            }
            return false;
        }

        //compare TOKENS value
        private static bool check3InRow(TOKEN s1, TOKEN s2, TOKEN s3)
        {
            return (s1 != TOKEN.EMPTY) && (s1 == s2) && (s2 == s3);
        }
    }
}
