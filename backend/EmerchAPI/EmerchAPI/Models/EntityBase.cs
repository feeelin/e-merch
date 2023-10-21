namespace EmerchAPI.Models;

public class EntityBase
{
    public string Id { get; set; }
    public string CollectionId { get; set; }
    public string CollectionName { get; set; }
    // TODO: Change DateTime string format to match 2023-10-20 23:09:26.580Z
    public string Created { get; set; }
    public string Updated { get; set; }
    
}