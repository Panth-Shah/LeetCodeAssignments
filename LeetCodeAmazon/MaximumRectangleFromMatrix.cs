using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class MaximumRectangleFromMatrix
    {
        public MaximumRectangleFromMatrix()
        {

        }

        public int MaximalRectangle(char[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return 0;
            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);
            int recrow = 0, reccolumn = 0, row = 0, column = 0;
            char[,] rec = new char[rowCount, columnCount];
            int recSize = rowCount ==1 && columnCount == 1 && matrix[rowCount - 1, columnCount - 1] == '1' ? 1 : 0;

            

            while (row <= rowCount - 1)
            {
                while (column <= columnCount - 1)
                {
                    if (matrix[row, column] == '1')
                    {
                        if (column != columnCount - 1 && matrix[row, column + 1] == '1')
                        {
                            rec[recrow, reccolumn] = '1';
                            recSize += 1;
                            column++;
                            reccolumn++;
                            continue;
                        }
                        rec[recrow, reccolumn] = '1';
                        recSize += 1;
                    }
                    else
                    {
                        rec[recrow, reccolumn] = '0';
                        if (column + 1 == columnCount - 1)
                        {
                            rec[recrow, reccolumn + 1] = '0';
                        }
                    }

                    column++;
                    reccolumn++;
                }
                row++; 
                recrow++;
                column = 0;
                reccolumn = 0;
            }
            row = 0;
            column = 0;

            while (column <= columnCount - 1)
            {
                while (row < rowCount - 1)
                {
                    if(rec[row, column] == '1')
                    {
                        if (row == 0 && rec[row + 1, column] == '0')
                        {
                            rec[row, column] = '0';
                            recSize -= 1;
                        }
                        else if(rec[row + 1, column] == '0' && rec[row - 1, column] == '0')
                        {
                            rec[row, column] = '0';
                            recSize -= 1;
                        }

                    }
                    row++;
                }
                row = 0;
                column++;
            }

            return recSize;
        }
    }
}
