using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
//using HelixToolkit.Wpf;
//using HelixToolkit.Wpf.SharpDX;



namespace MKWLayout_WPF
{
    class HeightmapModelConverter
    {
        Viewport3D viewport;
        public HeightmapModelConverter() 
        {
            //setup scene and camera
            viewport = new Viewport3D();
            var camera = new OrthographicCamera
            {
                Position = new Point3D(0, 100, 0),
                LookDirection = new Vector3D(0, -1, 0),
                UpDirection = new Vector3D(0, 0, 1),
            };
            viewport.Camera = camera;
        }
        /*
        public void modelToHeightmap()
        {
            string folderPath = "chemin_vers_le_dossier";

            // Parcourez tous les fichiers .obj du dossier
            foreach (string objFilePath in Directory.GetFiles(folderPath, "*.obj"))
            {

                // Chargez le modèle 3D à partir du fichier .obj
                var modelImporter = new ModelImporter();
                var model3D = modelImporter.Load(objFilePath);

                // Ajoutez le modèle 3D au groupe de modèles
                var modelGroup = new Model3DGroup();
                modelGroup.Children.Add(model3D);

                // Ajoutez le groupe de modèles à la scène
                var modelVisual3D = new ModelVisual3D();
                modelVisual3D.Content = modelGroup;
                viewport.Children.Add(modelVisual3D);

                // Récupérez l'image 2D à partir du viewport 3D
                var renderTargetBitmap = new RenderTargetBitmap(800, 600, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(viewport);

                // Récupérez les données de profondeur à partir du viewport 3D
                var depthBuffer = viewport.GetDepthBuffer();

                // Créez un WriteableBitmap pour stocker la heightmap
                var heightmapBitmap = new WriteableBitmap(800, 600, 96, 96, PixelFormats.Gray8, null);

                // Copiez les données de profondeur dans le WriteableBitmap en les convertissant en niveaux de gris
                for (int y = 0; y < heightmapBitmap.PixelHeight; y++)
                {
                    for (int x = 0; x < heightmapBitmap.PixelWidth; x++)
                    {
                        float depthValue = depthBuffer[x, y];
                        byte grayValue = (byte)(depthValue * 255);
                        if (pixelColor.A == 0)
                            heightmapBitmap.SetPixel(x, y, Color.FromArgb(255, 0, 255, 0));
                        else heightmapBitmap.SetPixel(x, y, grayValue);
                    }
                }

                // Enregistrez la heightmap en tant qu'image jpeg
                string outputFileName = Path.GetFileNameWithoutExtension(objFilePath) + "_heightmap.jpg";
                string outputPath = Path.Combine(folderPath, outputFileName);
                var jpgEncoder = new JpegBitmapEncoder();
                jpgEncoder.Frames.Add(BitmapFrame.Create(heightmapBitmap));
                using (var fileStream = new FileStream(outputPath, FileMode.Create))
                {
                    jpgEncoder.Save(fileStream);
                }

                // Supprimez le modèle 3D de la scène pour le prochain fichier .obj
                viewport.Children.Remove(modelVisual3D);
            }

            // https://www.phind.com/search?cache=c6ff5d11-ea38-44fc-9ce6-29759297fe59
        }
        */
    }
}