using System.ComponentModel.DataAnnotations;

namespace CarWebApi.Data
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Password { get; set; }
    }
}