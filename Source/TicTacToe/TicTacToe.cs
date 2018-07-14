using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        public static void startGame() {
            /* 
             * prepare local variables
             */
            string playerXName = "";
            string playerOName = "";
            int moveCounter = 0;
            bool finished = false;
            Player currentPlayer;

            /*
             * Start the game
             */
            Console.WriteLine("Welcome to TicTacToe Game\n");
            GameBoard gameBoard = new GameBoard();

            //init player 1
            Console.WriteLine("\nEnter name for Player 1:");
            playerXName = Console.ReadLine().Trim();
            while (string.IsNullOrEmpty(playerXName)) {
                Console.WriteLine("Empty name, re-enter name for Player 1:");
                playerXName = Console.ReadLine().Trim();
            }
            Player playerX = new Player('X', playerXName);

            //init player 2
            Console.WriteLine("\nEnter name for Player 2:");
            playerOName = Console.ReadLine().Trim();
            while (string.IsNullOrEmpty(playerOName))
            {
                Console.WriteLine("Empty name, re-enter for Player 2:");
                playerOName = Console.ReadLine().Trim();
            }
            Player playerO = new Player('O', playerOName);

            //Init game board and set current player to player 1 
            gameBoard.printBoard();
            currentPlayer = playerX;

            /*
             * Take turn for players' input
             */
            while (!finished) {

                //wait for player's token been set on the board
                while (true)
                {
                    Console.WriteLine("{0}, choose a box to place an '{1}' into:", currentPlayer.Name, currentPlayer.Token);
                    int fieldNumber = currentPlayer.chooseCell();

                    //user input can not be negative value and can not exceed the max space of the board
                    if (fieldNumber <= 0 || fieldNumber > Math.Pow(gameBoard.Board_Size, 2))
                    {
                        Console.WriteLine("\ninvalid input\n");
                        continue;
                    }
                    //check if user can set their Token on the box
                    if (gameBoard.canPutToken(currentPlayer, fieldNumber))
                    {
                        gameBoard.printBoard();
                        //gameBoard.clearBoard();
                        moveCounter++;
                        break;
                    }
                    //means fieldNumber already been taken continue with the game
                    else
                    {
                        continue;
                    }
                }

                //check any win cases before change to next player
                if (Checker.checkWin(gameBoard))
                {
                    Console.WriteLine();
                    Console.WriteLine("Congratulation {0}! You have won.", currentPlayer.Name);
                    finished = true;
                    continue;
                }

                if (Checker.checkDraw(moveCounter, gameBoard)) {
                    Console.WriteLine();
                    Console.WriteLine("It's a draw.");
                    finished = true;
                    continue;
                }
                // change to next player
                currentPlayer = changePlayer(currentPlayer, playerX, playerO);
            }

            //exit the game
            Console.WriteLine("\nPress enter to close...");
            Console.ReadLine();
            System.Threading.Thread.Sleep(1000);
        }

        

        private static Player changePlayer(Player currentPlayer, Player playerX, Player playerO)
        {
            return currentPlayer == playerX ? playerO : playerX;
        }
    }
}
