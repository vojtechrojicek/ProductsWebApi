using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsWebApi.Web.Contracts
{
#pragma warning disable 1591
    public class Product
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImgUri { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
#pragma warning restore 1591
}
