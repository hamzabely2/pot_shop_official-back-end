﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Model.Item
{
    public class ItemAdd
    {
        [Required(ErrorMessage = "Veuillez entrer un nom")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Veuillez entrer un desciption")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le prix")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Veuillez entrer la disponibilité de l'artcile")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Veuillez entrer la categoty")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Veuillez entrer une color")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le type de material")]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "Veuillez insere une image")]
        public IFormFile ImagesData { get; set; }

        [Required(ErrorMessage = "Veuillez entrer la hauteur")]
        public string Height { get; set; }

        [Required(ErrorMessage = "Veuillez entrer la largeur")]
        public string Width { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le poids")]
        public float Weight { get; set; }
    }
}
