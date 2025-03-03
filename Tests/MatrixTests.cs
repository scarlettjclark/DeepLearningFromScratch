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
        public void Access_CanAccessNumbersInMatrix_ReturnsCorrectValue(
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

        [TestCase (3, 2, (float[]) [1, 2, 3, 4, 5, 6, 7])]
        [TestCase (0, 0, (float[]) [1])]
        [TestCase (1, 2, (float[]) [])]
        public void Matrix_CreatingAMatrixRequiresValuesEqualToItsSize_ThrowsArgumentException(
            int rows,
            int columns,
            float[] testValues)
        {
            Assert.Throws<ArgumentException>(() => new Matrix(rows, columns, testValues));
        }

        [Test]
        public void Multiply_CanOnlyMultiplyMatricesWithCompatibleSize_ThrowsArgumentException()
        {
            Matrix testMatrix1 = new(1, 1, [1]);
            Matrix testMatrix2 = new(2, 2, [1, 1, 1, 1]);

            Assert.Throws<ArgumentException>(() => Matrix.Multiply(testMatrix1, testMatrix2));
        }
        [Test]
        public void Equals_MatricesWithSameDimensionAndSameValuesAreEqual_ReturnsTrue()
        {
            Matrix testMatrix1 = new(2, 2, [1, 0, 1, 1]);
            Matrix testMatrix2 = new(2, 2, [1, 0, 1, 1]);
            Assert.That(testMatrix1.Equals(testMatrix2), Is.EqualTo(true));
        }

        [Test]
        public void Equals_MatricesWithDifferentDimensionsAreNotEqual_ReturnsFalse()
        {
            Matrix testMatrix1 = new(3, 2, [1, 0, 1, 1, 0, 1]);
            Matrix testMatrix2 = new(2, 3, [1, 0, 1, 1, 0, 1]);

            Assert.That(testMatrix1.Equals(testMatrix2), Is.EqualTo(false));
        }

        [Test]
        public void Equals_MatricesWithDifferentValuesAreNotEqual_ReturnsFalse()
        {
            Matrix testMatrix1 = new(3, 2, [1, 0, 1, 1, 0, 1]);
            Matrix testMatrix2 = new(3, 2, [1, 1, 0, 1, 0, 1]);

            Assert.That(testMatrix1.Equals(testMatrix2), Is.EqualTo(false));
        }

        [Test]
        public void Multiply_MultiplyingByTheIdentityMatrixReturnsTheSameMatrix_ReturnsCorrectMatrix()
        {
            Matrix matrix = new(2, 2, [1, 2, 3, 4]);
            Matrix identity = new(2, 2, [1, 0, 0, 1]);
            Matrix result = Matrix.Multiply(matrix, identity);

            Assert.That(result.Equals(matrix), Is.EqualTo(true));
        }

        [TestCase(2, 2, (float[]) [1, 2, 3, 4], 2, 2, (float[]) [1, 2, 3, 4], 2, 2, (float[]) [7, 10, 15, 22])]
        [TestCase(3, 2, (float[])[-1, 1, 1, -1, 1, 1], 2, 3, (float[])[1, -1, 1, -1, -1, -1], 3, 3, (float[])[-2, 0, -2, 2, 0, 2, 0, -2, 0])]
        [TestCase(1, 3, (float[])[0.5f, 0.25f, 0.125f,], 3, 1, (float[])[-0.5f, -0.25f, -0.125f], 1, 1, (float[])[-0.328125f])]
        public void Multiply_MultiplyingReturnsTheCorrectValues_ReturnsCorrectMatrix(
                int rows1,
                int columns1,
                float[] values1,
                int rows2,
                int columns2,
                float[] values2,
                int expectedRows,
                int expectedColumns,
                float[] expectedValues
            )
        {
            Matrix matrix1 = new(rows1, columns1, values1);
            Matrix matrix2 = new(rows2, columns2, values2);
            Matrix expectedResult = new(expectedRows, expectedColumns, expectedValues);

            Matrix result = Matrix.Multiply(matrix1, matrix2);
            Assert.That(result.Equals(expectedResult), Is.EqualTo(true));

        }

    }
}