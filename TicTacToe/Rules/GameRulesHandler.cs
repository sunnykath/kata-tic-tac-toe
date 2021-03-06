using System.Linq;

namespace TicTacToe.Rules
{
    public class GameRulesHandler : IRules
    {
        public GameRulesHandler()
        {
        }
        
        public bool IsADuplicateMove(int[,] boardArray, Move moveToCheck)
        {
            var (coordX, coordY) = moveToCheck.GetCoord();
            return boardArray[coordX, coordY] != Constants.EmptyCellValue;
        }
        
        public bool HasDrawn(int[,] boardArray)
        {
            return boardArray.Cast<int>().All(cell => cell != 0);
        }
        
        public bool HasWon(int[,] boardArray)
        {
            return IsARowWin(boardArray) || IsAColumnWin(boardArray) || IsADiagonalWin(boardArray);
        }
        
        private bool IsARowWin(int[,] boardArray)
        {
            for (var i = 0; i < boardArray.GetLength(0); i++)
            {
                if (boardArray[i,0] != 0 && CheckEquivalence(boardArray[i, 0], boardArray[i, 1], boardArray[i, 2]) )
                {
                    return true;
                }
            }
            return false;
        }
        
        private bool IsAColumnWin(int[,] boardArray)
        {
            for (var i = 0; i < boardArray.GetLength(1); i++)
            {
                if (boardArray[0,i] != 0 && CheckEquivalence(boardArray[0,i], boardArray[1,i], boardArray[2,i]))
                {
                    return true;
                }
            }
            return false;
        }
        
        private bool IsADiagonalWin(int[,] boardArray)
        {
            return boardArray[1,1] != 0 && (CheckEquivalence(boardArray[1, 1], boardArray[2, 2],boardArray[0, 0]) 
                                            || CheckEquivalence(boardArray[1, 1], boardArray[2, 0], boardArray[0, 2]));
        }

        private bool CheckEquivalence(int a, int b, int c)
        {
            return (a == b) && (b == c);
        }

    }
}