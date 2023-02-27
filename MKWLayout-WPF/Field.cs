using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MKWLayout_WPF
{
    class Field
    {
        public int fieldValue; // { get; set; }
        public string fieldName;        //static ?
        public Field(int value, string name)
        {
            fieldValue = value;
            fieldName = name;
        }

    }
}
