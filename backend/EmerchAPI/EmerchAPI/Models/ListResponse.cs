namespace EmerchAPI.Models;

public class ListResponse<T>
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public int TotalItems { get; set; }
    public List<T> Items { get; set; }
}