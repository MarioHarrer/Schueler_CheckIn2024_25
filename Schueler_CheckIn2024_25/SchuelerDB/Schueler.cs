using System.ComponentModel.DataAnnotations;

namespace Schueler_CheckIn2024_25.SchuelerDB
{
    public class Schueler
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string schluessel {  get; set; }
        public string passwort { get; set; }
    }
}
