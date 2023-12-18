using System;

namespace Program
{
    class TicTacToe
    {
        static void Main()
        {

            // makes board
            char[,] Board = new char[3, 3]
            {
                {'-', '-', '-'},
                {'-', '-', '-'},
                {'-', '-', '-'}
            };

            bool run = true;

            // tile and instructions
            Console.WriteLine("\t\t\t\t Tic Tac Toe");
            Console.WriteLine("Use numbers 0-2.\nUp and down is a row and left and right is a column.");

            while (run)
            {
                Console.WriteLine();

                // x user input
                Console.Write("X Row: ");
                int xRow = int.Parse(Console.ReadLine());

                Console.Write("X Column: ");
                int xCol = int.Parse(Console.ReadLine());

                // checks invalid moves
                if (!(xRow <= 2) || !(xRow >= 0))
                {
                    Console.Write("Invalid turn! Both numbers must be between 0 and 2. Automatically setting both to 0.");
                    xRow = 0;
                    xCol = 0;
                }

                // checks winners
                bool xWinCheck = ThreeInARow(Board, 'X');
                if (xWinCheck == true)
                {
                    Console.Write("X wins!");
                    break;
                }

                bool oWinCheck = ThreeInARow(Board, 'O');
                if (oWinCheck == true)
                {
                    Console.Write("O wins!");
                    break;
                }

                Console.WriteLine();

                if (Board[xRow, xCol] == '-')
                {
                    Board[xRow, xCol] = 'X';
                }
                else
                {
                    Console.Write("\nThat spot has been taken! You miss your turn.\n");
                }

                boardPrinter(Board);

                // o user input
                Console.Write("O Row: ");
                int oRow = int.Parse(Console.ReadLine());

                Console.Write("O Column: ");
                int oCol = int.Parse(Console.ReadLine());


                // checks if invalid move
                if (!(oRow <= 2) || !(oRow >= 0))
                {
                    Console.Write("Invalid turn! Both numbers must be between 0 and 2. Automatically setting both to 0.");
                    oRow = 0;
                    oCol = 0;
                }


                // checks if spot is taken and changes board
                if (Board[oRow, oCol] == '-')
                {
                    Board[oRow, oCol] = 'O';
                }
                else
                {
                    Console.Write("\nThat spot has been taken! You miss your turn.\n");
                }

                // check if x wins
                xWinCheck = ThreeInARow(Board, 'X');
                if (xWinCheck == true)
                {
                    Console.Write("X wins!");
                    break;
                }

                // check if o wins
                oWinCheck = ThreeInARow(Board, 'O');
                if (oWinCheck == true)
                {
                    Console.Write("O wins!");
                    break;
                }

                Console.WriteLine();

                boardPrinter(Board);
            }
        }

        // prints the board to the console
        static void boardPrinter(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }

        // row checker
        static bool ThreeInARow(char[,] board, char symbol)
        {
            // Check rows
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1) - 2; j++)
                {
                    if (board[i, j] == symbol && board[i, j + 1] == symbol && board[i, j + 2] == symbol)
                    {
                        return true; // Found three in a row
                    }
                }
            }

            // Check columns
            for (int j = 0; j < board.GetLength(1); j++)
            {
                for (int i = 0; i < board.GetLength(0) - 2; i++)
                {
                    if (board[i, j] == symbol && board[i + 1, j] == symbol && board[i + 2, j] == symbol)
                    {
                        return true; // Found three in a column
                    }
                }
            }

            // Check diagonals
            for (int i = 0; i < board.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < board.GetLength(1) - 2; j++)
                {
                    // Check diagonal
                    if (board[i, j] == symbol && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == symbol)
                    {
                        return true; // Found three in a diagonal
                    }

                    // Check diagonal (top-right to bottom-left)
                    if (board[i, j + 2] == symbol && board[i + 1, j + 1] == symbol && board[i + 2, j] == symbol)
                    {
                        return true; // Found three in a diagonal
                    }
                }
            }

            return false; // No three in a row, column, or diagonal
        }
    }
}
