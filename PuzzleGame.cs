using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class PuzzleGame
    {
        private int[,] board;
        private int emptyRow;
        private int emptyCol;

        public PuzzleGame()
        {
            board = new int[4, 4];
            InitializeBoard();
            ShuffleBoard();
        }

        private void InitializeBoard()
        {
            int num = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board[i, j] = (i == 3 && j == 3) ? 0 : num++;
                }

                emptyRow = 3;
                emptyCol = 3;
            }
        }

        public void ShuffleBoard()
        {
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int temp = board[i, j];
                    int newIndexI = rand.Next(4);
                    int newIndexJ = rand.Next(4);

                    board[i, j] = board[newIndexI, newIndexJ];
                    board[newIndexI, newIndexJ] = temp;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == 0)
                    {
                        emptyRow = i;
                        emptyCol = j;
                    }
                }
            }
        }

        public void Move()
        {
            Console.WriteLine("Введите вектор движения:\nW - вверх;\nD - вправо;\nA - влево;\nS - вниз");

            char choice;
            bool flag = true;

            do
            {
                choice = Char.ToLower(Console.ReadKey().KeyChar);

                int tmp;

                switch (choice)
                {
                    case 'w':
                        if (emptyRow != 0)
                        {
                            tmp = board[emptyRow - 1, emptyCol];
                            board[emptyRow - 1, emptyCol] = 0;
                            board[emptyRow, emptyCol] = tmp;
                            emptyRow -= 1;
                            flag = false;
                        }
                        else
                        {
                            Console.WriteLine("Движение вверх невозможно.");
                        }
                        break;
                    case 'a':
                        if (emptyCol != 0)
                        {
                            tmp = board[emptyRow, emptyCol - 1];
                            board[emptyRow, emptyCol - 1] = 0;
                            board[emptyRow, emptyCol] = tmp;
                            emptyCol -= 1;
                            flag = false;
                        }
                        else
                        {
                            Console.WriteLine("Движение влево невозможно");
                        }
                        break;

                    case 's':
                        if (emptyRow != 3)
                        {
                            tmp = board[emptyRow + 1, emptyCol];
                            board[emptyRow + 1, emptyCol] = 0;
                            board[emptyRow, emptyCol] = tmp;
                            emptyRow += 1;
                            flag = false;
                        }
                        else
                        {
                            Console.WriteLine("Движение вниз невозможно");
                        }
                        break;

                    case 'd':
                        if (emptyCol != 3)
                        {
                            tmp = board[emptyRow, emptyCol + 1];
                            board[emptyRow, emptyCol + 1] = 0;
                            board[emptyRow, emptyCol] = tmp;
                            emptyCol += 1;
                            flag = false;
                        }
                        else
                        {
                            Console.WriteLine("Движение вправо невозможно");
                        }
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод. Попробуйте еще раз.");
                        break;
                }
            } while (flag);
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == 0)
                        Console.Write(" _ \t");
                    else
                        Console.Write(board[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public bool CheckingForWin()
        {
            int num = 1;
            int result = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == num || board[i, j] == 0)
                    {
                        result++;
                    }
                    num++;
                }
            }
            if (result == 16)
                return true;
            else
                return false;
        }
    }
}
