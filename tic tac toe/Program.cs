    using System;

namespace tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }
        public static void StartGame()
        {
            char[,] board = InitBoard();
            string[,] players = GetPlayers();
            while (GameContinues())
            {
                for (int i = 0; i < 2; i++)
                {
                    PlayTurn(board, players, i);
                }
            }
            
            
        }
        public static void PlayTurn (char [,] board, string[,] players,int playerIndex)
        {
            bool isContinue = true;
            int dim = board.GetLength(0);
            while (isContinue)
            {
                Console.WriteLine("{0} ,please choose a cell :",players[0,playerIndex]);
                PrintBoard(board);
                int locationNum = int.Parse(Console.ReadLine());
                int i = GetI(locationNum, dim);
                int j = GetJ(locationNum, dim);
                if (IsValid(i, j, board))
                {
                    char[] playerIcon = players[1, playerIndex].ToCharArray();
                    board[i, j] = playerIcon[0];
                    isContinue = false;
                }
                else
                    Console.WriteLine("invalid input insert again!");
            }

        }
        public static bool IsValid(int i, int j, char[,] board)
        {
            int dim = board.GetLength(0);
            bool isValid = false;
            if (i < dim && j < dim && i>=0 && j>=0)
            {
                if (board[i, j] == 0)
                    isValid = true;
            }
            return isValid;   
        }
         public static int GetJ (int index , int dim)
        {
            int j = (index - 1) % dim;
            return j;
        }
        public static int GetI(int index, int dim)
        {
            int i = (index - 1) / dim;
            return i;
        }
        public static string[,] GetPlayers()
        {
            string[,] players = new string[2, 2];
            
            Console.WriteLine("insert name of P1 :");
            players[0, 0] = Console.ReadLine();
            Console.WriteLine("insert name of P2 :");
            players[0, 1] = Console.ReadLine();

            players[1, 0] = "X";
            players[1, 1] = "O";
            Console.WriteLine("{0}(X), {1}(O) welcome to tic tac toe ",players[0,0],players[0,1]);

            return players;
        }
        public static void PrintBoard(char[,] board)
        {
            int dim = board.GetLength(0);
            Console.WriteLine("----------------------------------------------");
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    if (board[i, j] == 0)
                    {
                        int num = GetNum(i, j, dim);
                        Console.Write("|{0}|\t", num);
                    }
                    else
                        Console.Write("|{0}|\t", board[i, j]);
                    
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------");

            }
        }
        public static char[,] InitBoard ()
        {
            Console.WriteLine("insert board dimension :");
            int dim = int.Parse(Console.ReadLine());
            char[,] gameboard = new char[dim,dim];
            return gameboard;
        }
        public static int GetNum(int i , int j, int dim)
        {
            int num = j + 1 + i * dim;
            return num;
        }

        public static bool GameContinues()
        {
            return true;
        }

        
    }
}
