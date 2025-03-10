namespace DeepLearningFromScratch
{
    public class NeuralNetwork
    {
        public NeuralNetwork(int layers, int[] layerSizes, Matrix[] weights)
        {
            if (layers < 2)
            {
                throw new ArgumentException("Neural network must have at least 2 layers. Only has " + layers.ToString() + " layers.");
            }
            if (layers != layerSizes.Length)
            {
                throw new ArgumentException("Neural network must declare the size of each of its layers. Has " + layers.ToString() + " layers, but only " + layerSizes.Length.ToString() + "sizes.");
            }
            if (layers - 1 != weights.Length)
            {
                throw new ArgumentException("Neural network must have one less weight matrix than layers. Has " + layers.ToString() + " layers, but only " + weights.Length.ToString() + "weight matrices");
            }

            for (int weightIndex = 0; weightIndex < weights.Length; weightIndex++)
            {
                if (weights[weightIndex].Rows != layerSizes[weightIndex]
                    && weights[weightIndex].Columns != layerSizes[weightIndex + 1])
                {
                    throw new ArgumentException("Weight matrices should have rows and columns that match their layers. Expected " + layerSizes[weightIndex].ToString() + "*" + layerSizes[weightIndex] + " matrix, but got " + weights[weightIndex].Rows.ToString() + " * " + weights[weightIndex].Columns.ToString() + ".");
                }
            }
        }
    }
}
