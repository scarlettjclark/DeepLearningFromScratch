namespace DeepLearningFromScratch
{
    public class NeuralNetwork
    {
        public NeuralNetwork(int layers, int[] layerSizes, Matrix[] weights)
        {
            if (layers != layerSizes.Length)
            {
                throw new ArgumentException("Neural network must declare the size of each of its layers. Has " + layers.ToString() + " layers, but only " + layerSizes.Length.ToString() + "sizes.");
            }
        }
    }
}
