using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class RotateImage
    {
        public RotateImage()
        {

        }

        public void Rotate(int[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);

            //transpose matrix
            for (int i = 0; i< rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    int temp = matrix[j,i];
                    matrix[j,i] = matrix[i,j];
                    matrix[i,j] = temp;

                }
            }

            //reverse each row
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    int temp = matrix[i,j];
                    matrix[i,j] = matrix[i,rowCount - j - 1];
                    matrix[i,rowCount - j - 1] = temp;
                }

            }

        }
    }
}
