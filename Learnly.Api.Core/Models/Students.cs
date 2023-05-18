using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Learnly.Api.Core.Models
{
    public class Students
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public List<Matriculation> Matriculations { get; set; }
    }
}
