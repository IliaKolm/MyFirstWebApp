using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApp.Data
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }
    }
}
