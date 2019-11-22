using JetBrains.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Product
    {
        
        [Required]
        [RegularExpression(@"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$", ErrorMessage = "The Id you entered does not match the pattern : XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "You didn't enter a decimal!")]
        public decimal Price { get; set; }


        public Product([NotNull]Guid id, [NotNull]string name, [NotNull]decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

    }
}
