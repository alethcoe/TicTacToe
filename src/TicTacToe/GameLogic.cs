using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeVideo
{
    public class GameLogic
    {
        public string CurrentPlayer { get; set; } = X;
        private const string X = "X";
        private const string O = "O";
        private string[,] Board = new string[3, 3];
        public string[,] CurrentBoard => Board;

        public void SetNextPlayer()
        {
            if(CurrentPlayer == X)
            {
                CurrentPlayer = O;
            }
            else
            {
                CurrentPlayer = X;
            }
        }

        public bool PlayerWin()
        {
           return PlayerWin(Board);
        }

        public bool PlayerWin(string[,] board)
        {
            //we want to check the horizontal row
            for (var i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(board[i, 0]))
                {
                    if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
                    {
                        return true;
                    }
                }
            }

            //we want to the columns
            for (var i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(board[0, i]))
                {
                    if (board[0, i] == board[1, i] && board[0, i] == board[2, i])
                    {
                        return true;
                    }
                }
            }

            //diagonal

            if (!String.IsNullOrWhiteSpace(board[1, 1]))
            {
                if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                {
                    return true;
                }

                if (board[0, 2] == board[1, 1] && board[1,1] == board[2, 0])
                {
                    return true;
                }
            }

            return false;
        }

        public void UpdateBoard(Position postion, string value)
        {
            Board[postion.x, postion.y] = value;
        }

    }
}
