using System.ComponentModel.DataAnnotations;

namespace RS1_api_seminarski_proba.Modul1.Models
{
    public class Brend
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
    }
}
