namespace EmerchAPI.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public int AvailableAmount { get; set; }
    public bool SaleDiscount { get; set; }
    public int DiscountAvailable { get; set; }
    public List<ProductContent> ProductContents { get; set; }
}