using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Xml.Serialization;

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

        /*
         Inputs are:            => input layer is size of nField + 2 + 3? (no need for alpha bc based on green value)
         * Value of every field    => /100
         * x, y pixel position     => ratio x/horizontalSize, y/verticalSize
         * pixel rgb values        => /255
        */
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


        public NNet LoadNNet(string path)
        {
            XmlSerializer serializerObj = new XmlSerializer(typeof(NNet));
            FileStream readFileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            NNet loadedNNet = (NNet)serializerObj.Deserialize(readFileStream);
            readFileStream.Close();
            return loadedNNet;
        }

        public void SaveNNet(NNet net, string path)
        {
            XmlSerializer serializerObj = new XmlSerializer(typeof(NNet));
            TextWriter writeFileStream = new StreamWriter(path);
            serializerObj.Serialize(writeFileStream, net);
            writeFileStream.Close();
        }

        public void TrainNNet()
        {

        }
    }
}