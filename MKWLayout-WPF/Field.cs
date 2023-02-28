using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MKWLayout_WPF
{
    class Field
    {
        public int fieldValue; // { get; set; }
        public string fieldName;        //static ?
        public bool enabled { get; set; }
        protected TextBox textBox = new TextBox();
        protected CheckBox checkBox = new CheckBox();
        protected Slider slider = new Slider();
        
        public Field(int value, string name)
        {
            fieldValue = value;
            fieldName = name;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox != null)
            {
                fieldName = textBox.Text;

            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox != null && checkBox.IsChecked != null)
            {
                enabled = (bool)checkBox.IsChecked;
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            if (slider != null)
            {
                fieldValue = (int)slider.Value;
            }
        }
    }
}
