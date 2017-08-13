using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuNumber
    {
        internal int? value;
        internal int column;
        internal int row;
        internal List<int?> possibilities;
        internal bool correct = false;

        public SudokuNumber(int row, int column, int? value)
        {
            this.value = value;
            this.column = column;
            this.row = row;
        }
    }
}
