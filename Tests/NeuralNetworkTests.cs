using DeepLearningFromScratch;

namespace Tests
{
    internal class NeuralNetworkTests
    {
        [Test]
        public void NeuralNetwork_NeuralNetworkMustBeConstructedWithSpecifiedLayerSizes_ThrowsArgumentException()
        {
            Matrix weights = new(2, 2, [0.5f, 0.5f, 0.5f, 0.5f]);
            Assert.Throws<ArgumentException>(() => new NeuralNetwork(3, [2, 2], [weights]));

        }
        [Test]
        public void NeuralNetwork_NeuralNetworkMustHaveWeightMatricesEqualToNumberOfLayersMinusOne_ThrowsArgumentException()
        {
            Matrix[] weights = [new Matrix(2, 2, [0.5f, 0.5f, 0.5f, 0.5f]),
                                new Matrix (2, 2, [0.5f, 0.5f, 0.5f, 0.5f])];
            Assert.Throws<ArgumentException>(() => new NeuralNetwork(4, [2, 2, 2, 2], weights));
        }
        /*[Test]
        public void NeuralNetwork_NeuralNetworkMustBeConstructedWithCorrectlyShapedWeightMatrix_ThrowsArgumentException()
        {
            Matrix weights = new Matrix(0, 0, []);

            Assert.Throws<ArgumentException>(() => new NeuralNetwork(2, [16, 16], [weights]));
        }*/
    }
}
