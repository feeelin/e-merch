namespace EmerchAPI.Models;

public class Customer
{
    public Guid Id { get; set; }
    public string Nickname { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ThumbnailUrl { get; set; }
    public List<Product> Products { get; set; }
    public long ECoins { get; set; }
}