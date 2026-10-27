using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarClientApp.Data
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