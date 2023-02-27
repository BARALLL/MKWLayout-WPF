using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MKWLayout_WPF
{
    class Data
    {
        private string imgPath { get; set; }
        private bool enabled { get; set; }
        public static List<Field> data = new List<Field>();

        public Data(string path, List<Field> dataFields) 
        {
            enabled = true;
            imgPath = path;
            data = dataFields;
        }

        public void setField(string nameField, int value)
        {
            foreach(Field field in data)
            {
                if(field.fieldName == nameField)
                {
                    field.fieldValue = value;
                    break;
                }

            }
        }
    }
}
