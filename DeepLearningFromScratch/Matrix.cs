using System.Data;

namespace DeepLearningFromScratch
{
    public class Matrix
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public float[] StoredValues { get; set; }
        public Matrix(int rows, int columns, float[] storedValues)
        {
            if (storedValues.Length != rows * columns)
            {
                throw new ArgumentException("Matrix must have values equal to rows * columns. Expected " + (columns * rows).ToString() + " but got " + storedValues.Length);

            }
            else
            {
                Rows = rows;
                Columns = columns;
                StoredValues = storedValues;
            }
        }
        
        public float Access(int row, int column)
        {
            int accessIndex = (row - 1) * Columns + (column - 1);
            return StoredValues[accessIndex];
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            if(matrix1.Columns != matrix2.Rows)
            {
                throw new ArgumentException("Matrices must have compatible sizes in order to multiply. Matrix 1 has " + matrix1.Rows.ToString() + " rows but Matrix 2 has only " + matrix2.Columns + " columns");
            }
            else
            {
                float[] outputValues = new float[matrix1.Rows * matrix2.Columns];
                for (int row = 1; row <= matrix1.Rows; row++)
                {
                    for (int column = 1; column <= matrix2.Columns; column++)
                    {
                        outputValues[(row - 1) * matrix2.Columns + (column - 1)] = 0;
                        for(int index = 1; index <= matrix1.Columns; index++)
                        {
                            outputValues[(row - 1) * matrix2.Columns + (column - 1)] += matrix1.Access(row, index) * matrix2.Access(index, column);
                        }
                    }
                }

                return new Matrix(matrix1.Rows, matrix2.Columns, outputValues);

            }
        }

        public bool Equals(Matrix other)
        {
            if (other.Rows ==  Rows && other.Columns == Columns)
            {
                bool result = true;
                for (int index = 0; index < StoredValues.Length; index++)
                {
                    result &= StoredValues[index] == other.StoredValues[index];
                }
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
