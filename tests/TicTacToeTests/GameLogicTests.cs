using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using TicTacToeVideo;
using Xunit;

namespace TicTacToeTests
{
    public class GameLogicTests
    {
        [Fact]
        public void PlayerWins_EmptyBoard()
        {
            var emptyBoard = new String[,] { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            var sut = new GameLogic();
            var result = sut.PlayerWin(emptyBoard);
            Assert.False(result);
        }


        public static IEnumerable<object[]> HorizontalData = new List<object[]>{
           new object[]{ new string[,]{{"d","d","d"}, {"","",""}, {"","",""}} },
           new object[]{ new string[,]{{"",""," "}, {"b","b","b"}, {"","",""}} },
           new object[]{ new string[,]{{"",""," "}, {"","",""}, {"c","c","c"}} }
        };
        
        [Theory]
        [MemberData(nameof(HorizontalData))]
        public void PlayerWins_Row(string[,] board)
        {
            var sut = new GameLogic();
            var result = sut.PlayerWin(board);
            Assert.True(result);
        }

        public static IEnumerable<object[]> ColumnData = new List<object[]>{
           new object[]{ new string[,]{{"a","",""}, {"a","",""}, {"a","",""}} },
           new object[]{ new string[,]{{"","b"," "}, {"","b",""}, {"","b",""}} },
           new object[]{ new string[,]{{"","","c"}, {"","","c"}, {"","","c"}} }
        };

        [Theory]
        [MemberData(nameof(ColumnData))]
        public void PlayerWins_Column(string[,] board)
        {
            var sut = new GameLogic();
            var result = sut.PlayerWin(board);
            Assert.True(result);
        }

        public static IEnumerable<object[]> DiagData = new List<object[]>{
           new object[]{ new string[,]{{"x","",""}, {"","x",""}, {"a","","x"}} },
           new object[]{ new string[,]{{"","b","o"}, {"","o",""}, {"o","b",""}} },
        };

        [Theory]
        [MemberData(nameof(DiagData))]
        public void PlayerWins_Diagonal(string[,] board)
        {
            var sut = new GameLogic();
            var result = sut.PlayerWin(board);
            Assert.True(result);
        }

        [Fact]
        public void SetNextPlayer_Adjusts_Properly()
        {
            var sut = new GameLogic();
            Assert.Equal(GameLogic.X,sut.CurrentPlayer);

            sut.SetNextPlayer();
            Assert.Equal(GameLogic.O, sut.CurrentPlayer);

            sut.SetNextPlayer();
            Assert.Equal(GameLogic.X, sut.CurrentPlayer);
        }

    }
}
