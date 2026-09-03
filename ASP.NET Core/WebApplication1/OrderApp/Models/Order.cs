using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace OrderApp.Models
{
    public class Order : IValidatableObject
    {
        [BindNever]
        public int? OrderNo { get; set; }
        //[Required]
        //[Display(Name = "Order Date")]
        public DateTime? OrderDate { get; set; } = null;
        //[Required]
        public double InvoicePrice { get; set; }
        //[Required]        
        public List<Product> Products { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var total = Products.Sum(p => p.Price * p.Quantity);
            if (total != InvoicePrice)
            {
                yield return new ValidationResult($"Invoice Price ({InvoicePrice}) must be equal to the total price of products ({total})", [nameof(InvoicePrice)]);
            }
            if (OrderDate == null || !DateTime.TryParse(OrderDate.ToString(), out _))
            {
                yield return new ValidationResult("Order Date can't be blank", [nameof(OrderDate)]);
            }
            if (Products == null || Products.Count == 0)
            {
                yield return new ValidationResult("Products list can't be empty", [nameof(Products)]);
            }
        }
    }
}
