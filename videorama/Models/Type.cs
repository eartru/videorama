using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Videorama.Models
{
    public class Type
    {
        private int idType;
        private string typeName;

        [Display(Name = "Id type")]
        public int IdType { get; set; }
        [Display(Name = "Type")]
        public string TypeName { get; set; }
    }
}