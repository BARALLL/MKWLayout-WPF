using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MKWLayout_WPF
{
    public class NNet
    {
        List<String> imgDBPath = new List<String>();
        Layer[] layers;

        /// <summary>
        /// Summary description for Class1
        /// </summary>
        public NNet(int[] layerSizes)
        {
            layers = new Layer[layerSizes.Length - 1];
            for (int i = 0; i < layerSizes.Length; i++) 
                layers[i] = new Layer(layerSizes[i], layerSizes[i+1]);
        }

        double[] calcOutputs(double[] inputs)
        {
            foreach (Layer layer in layers)
                inputs = layer.calcOutput(inputs);  //output of current layer is input of next layer
            return inputs;  //becomes outputs
        }

        double sigmoid(double input)
        {
            return 255 / (1 + Math.Exp(-input));
        }


        public void LoadNNet()
        {

        }

        public void SaveNNet()
        {

        }

        public void TrainNNet()
        {

        }
    }
}
