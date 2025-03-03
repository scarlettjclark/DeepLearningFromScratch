namespace DeepLearningFromScratch
{
    public class Matrix(int rows, int columns, float[] storedValues)
    {
        public float Access(int row, int column)
        {
            int accessIndex = (row - 1) * columns + (column - 1);
            return storedValues[accessIndex];
        }
    }
}
