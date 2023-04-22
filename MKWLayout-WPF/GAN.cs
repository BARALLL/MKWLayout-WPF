using System;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using Tensorflow.Contexts;

namespace MKWLayout_WPF
{
    public class GAN
    {
        MLContext context;
        IDataView data;
        EstimatorChain<ColumnConcatenatingTransformer> pipeline;
        TransformerChain<ColumnConcatenatingTransformer> model;

        public GAN()
        {
            context = new MLContext();
            data = context.Data.LoadFromTextFile<ImageData>("data.csv", separatorChar: ',');

            pipeline = context.Transforms.Conversion.MapValueToKey("Label")
                            .Append(context.Transforms.NormalizeMinMax("Features"))
                            .Append(context.Transforms.Concatenate("Features", "Features"))
                            .Append(context.Transforms.NormalizeMinMax("Features"))
                            .Append(context.Transforms.Concatenate("Features", "Features"))
                            .Append(context.Transforms.NormalizeMinMax("Features"))
                            .Append(context.Transforms.Concatenate("Features", "Features"))
                            .Append(context.Transforms.NormalizeMinMax("Features"))
                            .Append(context.Transforms.Concatenate("Features", "Features"))
                            .Append(context.Transforms.NormalizeMinMax("Features"))
                            .Append(context.Transforms.Concatenate("Features", "Features"))
                            .Append(context.Transforms.NormalizeMinMax("Features"))
                            .Append(context.Transforms.Concatenate("Features", "Features"))
                            .Append(context.Transforms.NormalizeMinMax("Features"))
                            .Append(context.Transforms.Concatenate("Features", "Features"))
                            .Append(context.Transforms.NormalizeMinMax("Features"))
                            .Append(context.Transforms.Concatenate("Features", "Features"))
                            .AppendCacheCheckpoint(context);

            model = pipeline.Fit(data);

            Func<float[], float[]> generator = features =>  // Create generator function
            {
                var engine = context.Model.CreatePredictionEngine<ImageData, ImagePrediction>(model); // Create a new prediction engine
                var input = new ImageData { Features = features };
                var output = engine.Predict(input);

                return output.Pixels; // Return the generated image
            };

            Func<float[], float> discriminator = pixels =>      // Create discriminator function
            {
                var engine = context.Model.CreatePredictionEngine<ImageData, ImagePrediction>(model);
                var input = new ImageData { Pixels = pixels };
                var output = engine.Predict(input);

                return output.Score;    //return predicted output score
            };
        }

        public void reTrainModel()
        {
            data = context.Data.LoadFromTextFile<ImageData>("data.csv", separatorChar: ',');    //reload data
            //model = pipeline.Fit(data, model);        //pipeline-algorithms are not re-trainable in current version of ML.NET
                                                        //retrain everything?
            model = pipeline.Fit(data);
        }


        public void saveModel(String fileName)
        {
            string[] words = fileName.Split('.');
            if (words[words.Length - 1] != "zip") { fileName += "zip";  }
            context.Model.Save(model, data.Schema, fileName);
        }

        public void loadModel(String filePath)
        {
            DataViewSchema modelSchema;
            ITransformer loadedModel = context.Model.Load(filePath, out modelSchema);

            if (loadedModel != null) { model = loadedModel as TransformerChain<ColumnConcatenatingTransformer>; }
        }
    }

    public class ImageData
    {
        [LoadColumn(0)]
        public float Label;

        [LoadColumn(1, 784)]
        [VectorType(784)]
        public float[] Pixels;

        [LoadColumn(785, 814)]
        [VectorType(30)]
        public float[] Features;
    }

    public class ImagePrediction
    {
        [ColumnName("Score")]
        public float Score;

        [ColumnName("Pixels")]
        public float[] Pixels;
    }
}


/*
 Roadmap:
    UI:
    Overall:
    buttons, labels... should stay consistent even when the window is resized

    ** Menus
    * database
        2 columns : vertical panel on the left
                            buttons: add image folder/add 1 image, remove images (work like rm image on phone (selection of every img you want to rm))
                                     add feature, remove feature            on the same line
                                    clear database: prompt are you sure

                                    add/rm img show a re-train model to include img button 
                                    add/rm feature prompt are you sure? you will have to train the model entirely again
                            
                            list of features under buttons

                    image collection on the right

                    clicking on an image update value fields on features and show button rm image (will rm this one only)
 
    * Model
        create new / save / load / train model buttons on the middle left
        generated img on the left, with a add to database button underneath it
        when save or load button is clicked, open a windows explorer tab
        when add to db button clicked, prompt re-train ?

    GAN:
        modify ImageData and ImagePrediction class to be a list of feature (add/rm) and
        to allow different image size
    
 */