namespace DeepLearningFromScratch.Tests
{
    public class Tests
    {
        [TestCase(2, 2, (float[]) [0, 0, 7, 0], 2, 1, 7)]
        [TestCase(3, 3, (float[])[1, 2, 3, 4, 5, 6, 7, 8, 9], 3, 2, 8)]
        [TestCase(5, 5, (float[])[0, 0, 0, 0, 0,
                                  0, 0, 0, 0, 0,
                                  0, 0, 1, 0, 0,
                                  0, 0, 0, 0, 0,
                                  0, 0, 0, 0, 0,], 3, 3, 1)]
        public void Access_CanAccessNumbersInMatrix_ReturnsSeven(
            int rows,
            int columns,
            float[] testValues,
            int testRow,
            int testColumn,
            int expectedResult
            )
        {
            Matrix matrix = new(rows, columns, testValues);
            
            Assert.That(matrix.Access(testRow, testColumn), Is.EqualTo(expectedResult));
        }
    }
}