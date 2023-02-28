using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MKWLayout_WPF
{
    class Data
    {
        public string imgPath { get; set; }
        public bool enabled { get; set; }
        protected CheckBox checkBox = new CheckBox();

        //public static List<Field> fields = new List<Field>();
        public static List<int> fieldValues = new List<int>();

        public Data(int nField)
        {
            enabled = true;
            imgPath = "";
            for (int i = 0; i < nField; i++)
                fieldValues.Add(0);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox != null && checkBox.IsChecked != null)
            {
                enabled = (bool)checkBox.IsChecked;
            }
        }

        /*  setField
        public void setField(string nameField, int value)
        {
            foreach(Field field in fields)
            {
                if(field.fieldName == nameField)
                {
                    field.fieldValue = value;
                    break;
                }

            }
        }
        */
    }
}
