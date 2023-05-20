using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductList.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [DisplayName("Product Id")]
        public int Product_Id { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage ="Product Name Required")]
        [RegularExpression(@"^([a-zA-Z0-9.]+\s)*[a-zA-Z0-9.]+$",
         ErrorMessage = "Special Characters Not Allowed and/or Only Single Space Allowed Between Two Words")]
        [MaxLength(20)]
        public string Product_Name { get; set; }
        [DisplayName("Product Price(in ₹)")]
        [Required(ErrorMessage = "Product Price Required")]
        [Range(0, 9999999999, ErrorMessage = "Product Price must be between 1 and 9999999999.")]
        [RegularExpression(@"^([0-9.]+)$",
         ErrorMessage = "Only Numbers Allowed")]
        public decimal Product_Price { get; set; }
    }
}
