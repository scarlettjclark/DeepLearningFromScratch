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
    }
}
