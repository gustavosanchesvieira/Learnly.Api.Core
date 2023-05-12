using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Learnly.Api.Core.Models
{
    public class Teacher
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public List<Subjects> Subjects { get; set; }
    }
}
