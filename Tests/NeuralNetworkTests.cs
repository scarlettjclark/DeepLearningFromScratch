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
        [Test]
        public void NeuralNetwork_NeuralNetworkMustBeConstructedWithAtLeast2Layers_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new NeuralNetwork(1, [2], []));
        }
        [Test]
        public void NeuralNetwork_NeuralNetworkMustBeConstructedWithCorrectlyShapedWeightMatrix_ThrowsArgumentException()
        {
            Matrix weights = new(0, 0, []);

            Assert.Throws<ArgumentException>(() => new NeuralNetwork(2, [16, 16], [weights]));
        }
        [Test]
        public void Input_NeuralNetworkCalculatesCorrectly_ReturnsCorrectMatrix()
        {
            Matrix weights1 = new(2, 2, [0.25f, 0.25f, 0.25f, 0.25f]);
            Matrix weights2 = new(2, 2, [0.25f, 0.25f, 0.25f, 0.25f]);

            Matrix input = new(2, 1, [1f, 1f]);
            NeuralNetwork neuralNetwork = new(3, [2, 2, 2], [weights1, weights2]);
            Matrix actualOutput = neuralNetwork.Input(input);
            Matrix expectedOutput = new(2, 1, [0.25f, 0.25f]);

            Assert.That(expectedOutput.Equals(actualOutput), Is.EqualTo(true));
        }
    }
}
