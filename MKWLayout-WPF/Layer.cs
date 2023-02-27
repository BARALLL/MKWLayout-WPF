using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKWLayout_WPF
{
    public class Layer
    {
        int nInNodes, nOutNodes;
        double[,] weights;
        double[] biases;

        public Layer(int nInNodes, int nOutNodes)
        {
            this.nInNodes = nInNodes;
            this.nOutNodes = nOutNodes;
            this.weights = new double[nInNodes, nOutNodes];
            this.biases = new double[nOutNodes];
        }

        public double[] calcOutput(double[] inputs)
        {
            double[] outputs = new double[nOutNodes];
            for (int outN = 0; outN < nOutNodes; outN++)
            {
                for (int inN = 0; inN < nInNodes; inN++)
                    outputs[outN] += weights[inN, outN] * inputs[inN];
                outputs[outN] += biases[outN];
            }

            return outputs;
        }
    }
}
