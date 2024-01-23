
using System.ComponentModel.DataAnnotations;

public class Product
{
    private static int nextId = 1;

    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product Name is required.")]
    public string ProductName { get; set; }

    [MaxLength(100, ErrorMessage = "Product Description cannot exceed 100 characters.")]
    public string ProductDescription { get; set; }

    public Product()
    {
        ProductId = nextId++;
    }
}
