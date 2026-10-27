using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWebApi.Data;

public class Car
{
    [Key]
    public int Id { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    [ForeignKey(nameof(Group))]

    public int GroupId { get; set; }

    public Group Group { get; set; }

    public string Password { get; set; }
}
