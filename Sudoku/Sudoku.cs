using System;
using System.Collections.Generic;

namespace Sudoku
{
    class Sudoku
    {
        internal Dictionary<int, List<int>> rowPossibilities = new Dictionary<int, List<int>>();
        internal Dictionary<int, List<int>> columnPossibilities = new Dictionary<int, List<int>>();
        internal Dictionary<int, List<int>> gridPossibilities = new Dictionary<int, List<int>>();
        public List<SudokuNumber> entries = new List<SudokuNumber>();

        internal Sudoku()
        {
            for(int index = 1; index<10; index++)
                //Generates possibilities correspending to each row/column/grid
            {
                    rowPossibilities.Add(index, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                    //index == row #
                    columnPossibilities.Add(index, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9});
                    //index == column #
                    gridPossibilities.Add(index, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }); 
                    //index == grid # correspending to the alphabetical identifier used in button labels
            }

            for(int row = 1; row<10; row++)
                //Setting all values to null
            {
                for(int col = 1; col<10; col++)
                {
                    entries.Add(new SudokuNumber(row, col, null));
                }
            }
        }      
        
        public void updatePossibilities(int row, int column, int? newValue)
        {
            //Formula to attain grid number from row and column number
            int grid = (int)((Math.Ceiling((double)row / 3) - 1) * 3 + Math.Ceiling((double)column / 3));

            int? oldValue = entries[(column - 1) + (row - 1) * 9].value;

            if (newValue != null)
            //Removing the new value for the square from possibility lists
            {
                rowPossibilities[row].Remove((int)newValue);
                columnPossibilities[column].Remove((int)newValue);
                gridPossibilities[grid].Remove((int)newValue);
            }
            
            if(oldValue!=null)
            //Adding the old value back to the possibility lists if it had a value != null previously
            {
                rowPossibilities[row].Add((int)oldValue);
                columnPossibilities[column].Add((int)oldValue);
                gridPossibilities[grid].Add((int)oldValue);
            }
        }
    }
}
