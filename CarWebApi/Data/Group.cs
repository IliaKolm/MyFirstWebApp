using System.ComponentModel.DataAnnotations;

namespace CarWebApi.Data;

public class Group
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
}
