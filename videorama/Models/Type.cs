using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videorama.Models
{
    public class Type
    {
        public int idType;
        public string typeName;

        public Type(string name, int id)
        {
            this.idType = id;
            this.typeName = name;
        }

        private int IdType { get; set; }
        private string TypeName { get; set; }
    }
}