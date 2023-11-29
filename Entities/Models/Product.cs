﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required(ErrorMessage = "ProductName is required")]
    public String? ProductName { get; set; } = String.Empty;
    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }
    public String? Summary { get; set; } = String.Empty;
    public String? ImageUrl { get; set; }
    public int? CategoryId { get; set; }        //Foreign Key
    public Category? Category { get; set; }     //Navigation Property
    public bool ShowCase { get; set; }
}