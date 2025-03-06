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
            if (layers - 1 != weights.Length)
            {
                throw new ArgumentException("Neural network must have one less weight matrix than layers. Has " + layers.ToString() + " layers, but only " + weights.Length.ToString() + "weight matrices");
            }
        }
    }
}
