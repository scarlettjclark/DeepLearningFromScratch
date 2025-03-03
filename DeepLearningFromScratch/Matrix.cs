using System.Data;

namespace DeepLearningFromScratch
{
    public class Matrix
    {
        readonly int _rows;
        readonly int _columns;
        readonly float[] _storedValues;
        public Matrix(int rows, int columns, float[] storedValues)
        {
            if (storedValues.Length != rows * columns)
            {
                throw new ArgumentException("Matrix must have values equal to rows * columns. Expected " + (columns * rows).ToString() + " but got " + storedValues.Length);

            }
            else
            {
                _rows = rows;
                _columns = columns;
                _storedValues = storedValues;
            }
        }
        
        public float Access(int row, int column)
        {
            int accessIndex = (row - 1) * _columns + (column - 1);
            return _storedValues[accessIndex];
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            if(matrix1._columns != matrix2._rows)
            {
                throw new ArgumentException("Matrices must have compatible sizes in order to multiply. Matrix 1 has " + matrix1._rows.ToString() + " rows but Matrix 2 has only " + matrix2._columns + " columns");
            }
            else
            {
                float[] outputValues = new float[matrix1._rows * matrix2._columns];
                for (int row = 1; row <= matrix1._rows; row++)
                {
                    for (int column = 1; column <= matrix2._columns; column++)
                    {
                        outputValues[(row - 1) * matrix2._columns + (column - 1)] = 0;
                        for(int index = 1; index <= matrix1._columns; index++)
                        {
                            outputValues[(row - 1) * matrix2._columns + (column - 1)] += matrix1.Access(row, index) * matrix2.Access(index, column);
                        }
                    }
                }

                return new Matrix(matrix1._rows, matrix2._columns, outputValues);

            }
        }

        public bool Equals(Matrix other)
        {
            if (other._rows ==  _rows && other._columns == _columns)
            {
                bool result = true;
                for (int index = 0; index < _storedValues.Length; index++)
                {
                    result &= _storedValues[index] == other._storedValues[index];
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
