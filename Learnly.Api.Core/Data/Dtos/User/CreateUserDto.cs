using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Learnly.Api.Core.Data.Dtos.User
{
    public class CreateUserDto
    {
        public int StudentId { get; set; }
        public string Password { get; set; }
    }
}
