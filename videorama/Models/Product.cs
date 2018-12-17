using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Videorama.Models
{
    public class Product
    {
        private int idProduct;
        private string title;
        private string synopsis;
        private string picture;
        private List<Category> categories;
        private List<Person> casting;
        private DateTime releaseDate;
        private int stock;
        private decimal price;
        private Type typeP;

        [Display(Name = "Id produit")]
        public int IdProduct { get; set; }
        [Required]
        [Display(Name = "Titre")]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Synopsis")]
        public string Synopsis { get; set; }
        [Display(Name = "Affiche")]
        public string Picture { get; set; }
        [Display(Name = "Catégories")]
        public List<Category> Categories { get; set; }
        [Display(Name = "Casting")]
        public List<Person> Casting { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de sortie")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Stock")]
        public int Stock { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Nombre valide avec maximum 2 décimales")]
        [Display(Name = "Prix")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Type")]
        public Type TypeP { get; set; }

    }
}