using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MKWLayout_WPF.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {

        private bool createWasClicked;
        private bool saveWasClicked;
        private bool trainWasClicked;

        public HomeView()
        {
            InitializeComponent();
            createWasClicked = true;
            saveWasClicked = false;
            trainWasClicked = false;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if(saveWasClicked == false || trainWasClicked == true)
            {
                HomeNotifyLabel.Content = "The model is not saved. Create new anyway?";
            }

            if (createWasClicked == false)
            {
                HomeNotifyLabel.Content = "New Model Created";
                HomeNotifyLabel.Content = "";
            }
            else
            {
                HomeNotifyLabel.Content = "New Model Already Created";
                HomeNotifyLabel.Content = "";
            }
            createWasClicked = true;
            saveWasClicked = false;
            trainWasClicked = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (saveWasClicked == false)
            {
                HomeNotifyLabel.Content = "Model Saved";
                HomeNotifyLabel.Content = "";
            }
            else
            {
                HomeNotifyLabel.Content = "New Model Already Created";
                HomeNotifyLabel.Content = "";
            }
            createWasClicked = false;
            saveWasClicked = true;
            trainWasClicked = false;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            HomeNotifyLabel.Content = "Model Loaded";
            HomeNotifyLabel.Content = "";

            createWasClicked = false;
            saveWasClicked = true;  //true because if loaded from file, it was saved before
            trainWasClicked = false;
        }

        private void TrainButton_Click(object sender, RoutedEventArgs e)
        {
            HomeNotifyLabel.Content = "Model currently Training...";
            HomeNotifyLabel.Content = "Model Trained";
            HomeNotifyLabel.Content = "";
            
            createWasClicked = false;
            saveWasClicked = false;
            trainWasClicked = true;
        }

    }
}
