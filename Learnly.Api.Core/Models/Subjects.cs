using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Learnly.Api.Core.Models
{
    public class Subjects
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkLoad { get; set; }
        public int AbcencesLimit { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        [JsonIgnore]
        public List<Matriculation> Matriculations { get; set; }
        [JsonIgnore]
        public List<Grades> Grades { get; set; }
    }
}
