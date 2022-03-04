using System;

namespace tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] players = { 'x', 'o' };
            int size = SetGameboardSize();
            char[,] gameBoard = new char[size, size];
            int[,] numericGameboard = CreateNumericGameboard(size);

            startGame(players, gameBoard, numericGameboard, size);


            

        }
        public static int SetGameboardSize()
        {
            Console.WriteLine("insert gameboard size");
            return int.Parse(Console.ReadLine());
        } 
        public static int[,] CreateNumericGameboard(int size)
        {
            int[,] numericBoard = new int[size, size];
            for (int i = 0; i<size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    numericBoard[j, i] = i + 1 + j * size;
                }
            }
            return numericBoard;
        }
        public static void PrintGameboard(char[,] array)
        {
            Console.WriteLine("-----------------");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("| {0} | ", array[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine("-----------------");

            }
        }
        public static int ChooseCell(int[,] numericGameBoard,char[,] gameBoard,int size)
        {
            bool notInserted = true;
            int chosenCell = 0;
            Console.WriteLine("choose from empty cells:");
            Console.WriteLine("-----------------");

            for (int i = 0; i < numericGameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < numericGameBoard.GetLength(1); j++)
                {

                    if (numericGameBoard[i, j] == -1)
                        Console.Write("| {0} | ", gameBoard[i, j]);

                    else
                        Console.Write("| {0} | ", numericGameBoard[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine("-----------------");

            }
            while (notInserted)
            {
                chosenCell = int.Parse(Console.ReadLine());
                if (chosenCell <= size*size && chosenCell > 0)
                    notInserted = false;
                else
                    Console.WriteLine("choose again :");
            }
            return chosenCell;
        }
        public static int[] findIndex(int[,] array, int chosenCell)
        {
            bool isContinue = true;
            int[] index = { -1,-1};
            for (int i = 0; i < array.GetLength(0) && isContinue; i++)
            {
                for (int j = 0; j < array.GetLength(1) && isContinue; j++)
                {
                    if (array[i, j] == chosenCell)
                    {
                        index[0] = i;
                        index[1] = j;
                        isContinue = false;
                    }
                }
            }
            
            return index;
        }

        public static void InsertToIndex(int[,] numericGameboard, char[,] gameBoard, int[] index, char player)
        {
            int index1 = index[0];
            int index2 = index[1];
            if (player == 'o')
                gameBoard[index1, index2] = 'O';
            else
                gameBoard[index1, index2] = 'X';

            numericGameboard[index1, index2] = -1;
        }

        public static void startGame(char[] players, char[,] gameBoard, int[,] numericGameboard,int size)
        {
            bool gameContinues = true;
            while (gameContinues)
            {
                for (int i = 0; i < 2; i++)
                {
                    int chosenCell = ChooseCell(numericGameboard,gameBoard, size);
                    int[] index = findIndex(numericGameboard, chosenCell);
                    if (index[0] != -1)
                        InsertToIndex(numericGameboard, gameBoard, index, players[i]);                    
                    PrintGameboard(gameBoard);
                }
            }
        }
    }
}
