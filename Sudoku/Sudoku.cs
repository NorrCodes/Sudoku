using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    class Sudoku
    {
        public List<SudokuNumber> entries = new List<SudokuNumber>();
		internal int errorCheck = 0;

        internal Sudoku()
		//Generates entries collection, and sets all the values to null
        {
            for(int row = 1; row<10; row++)
                //Setting all values to null
            {
                for(int col = 1; col<10; col++)
                {
                    entries.Add(new SudokuNumber(row, col, null));
                }
            }
        }      

        internal void GameSetup(int row, int column, int value)
		//Inserts numbers into the panel at the beginning of the game
        {
            entries[CurrentEntry(row, column)].value = value;
        }

		internal int? Increment(int row, int column)
		//Changes the value of the square when you click on it, MyEventHandler uses this method
		{
			int index = CurrentEntry(row, column);
			int? value = entries[index].value;

			if ( value == null )
			{
				entries[index].value = 1;
			}
			else if ( value == 9 )
			{
				entries[index].value = null;
			}
			else
			{
				entries[index].value++;
			}
			return entries[index].value;
		}

		internal List<int?> Scan (int row, int column)
		//Returns a List object of all the possibilities for a given square
		{
			SudokuNumber sd = entries[CurrentEntry(row, column)];

			List<int?> rowPossibilities = new List<int?> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			List<int?> columnPossibilities = new List<int?> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			List<int?> gridPossibilities = new List<int?> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			int? value = entries[CurrentEntry(row, column)].value;
			entries[CurrentEntry(row, column)].value = null;

			for (int i = 1; i<10; i++)
			{
				if ( entries[CurrentEntry(i, column)].correct )
				{
					rowPossibilities.Remove(entries[CurrentEntry(i, column)].value);
				}
				if ( entries[CurrentEntry(row, i)].correct )
				{
					columnPossibilities.Remove(entries[CurrentEntry(row, i)].value);
				}
			}

			int grid = GetGrid(row, column);
			int[] gridCorner = GetGridCorner(grid);

			for (int i = gridCorner[0]; i<(gridCorner[0]+3); i++)
			{
				for ( int j = gridCorner[1]; j < ( gridCorner[1] + 3 ); j++ )
				{
					if ( entries[CurrentEntry(i, j)].correct )
					{
						gridPossibilities.Remove(entries[CurrentEntry(i, j)].value);
					}
				}
			}
			entries[CurrentEntry(row, column)].value = value;

			sd.possibilities = rowPossibilities.Intersect(columnPossibilities.Intersect(gridPossibilities)).ToList();
			return sd.possibilities;
		}

		internal bool Check(int row, int column)
		{
			int i = CurrentEntry(row, column);
			if (Scan(row,column).Count==1)
			{
				entries[i].correct = ( Scan(row, column)[0] == entries[i].value ? true : false );
			}
			return entries[i].correct;
		}

		internal static int CurrentEntry(int row, int column)
		//Returns the index in the "entries" collection using the row and column number
		{
			return ( column - 1 ) + ( row - 1 ) * 9;
		}

		internal static int GetGrid(int row, int column)
		//Returns the grid number for the correspending row and column
		{
			return (int)( ( Math.Ceiling((double)row / 3) - 1 ) * 3 + Math.Ceiling((double)column / 3) );
		}

		internal static int[] GetGridCorner(int grid)
		{
			switch(grid)
			{
				case 1:
					return new int[] { 1, 1 };
				case 2:
					return new int[] { 1, 4 };
				case 3:
					return new int[] { 1, 7 };
				case 4:
					return new int[] { 4, 1 };
				case 5:
					return new int[] { 4, 4 };
				case 6:
					return new int[] { 4, 7 };
				case 7:
					return new int[] { 7, 1 };
				case 8:
					return new int[] { 7, 4 };
				case 9:
					return new int[] { 7, 7 };
				default:
					return new int[] { 1,1 };
			}
		}
    }
}
