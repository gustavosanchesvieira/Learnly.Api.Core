using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Learnly.Api.Core.Models
{
    public class Teacher
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo sobrenome é obrigatório")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Email { get; set; }
        
        [JsonIgnore]
        public List<Subjects> Subjects { get; set; }
    }
}
