using Learnly.Api.Core.Data;
using Learnly.Api.Core.Data.Dtos.User;
using Learnly.Api.Core.Interfaces;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Utils;

namespace Learnly.Api.Core.Services
{
    public class UserService : IServiceBase<User>
    {
        private DataContext _dbContext;

        public UserService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DefaultResponse Create(User obj)
        {
            try
            {
                _dbContext.Users.Add(obj);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "Usuário cadastrado com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Erro ao tentar cadastrar usuário" + f.Message
                };
            }
        }

        public DefaultResponse Delete(int id)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return new DefaultResponse
                    {
                        Sucess = false,
                        Message = "O usuário não foi encontrado."
                    };
                }
                _dbContext.Remove(user);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "A usuário foi excluído com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Ocoreu um erro ao tentar deletar o usuário: " + f.Message
                };
            }
        }

        public IList<User>? Get()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User? GetById(int id)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DefaultResponse Update(User obj)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.Id == obj.Id);
                if (user == null)
                {
                    return new DefaultResponse
                    {
                        Sucess = false,
                        Message = "A usuário não foi encontrado."
                    };
                }
                _dbContext.Update(user);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "A usuário foi atualizado com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Ocoreu um erro ao tentar atualizar o usuário: " + f.Message
                };
            }
        }

        public void CreateUserStudent(CreateUserDto dto)
        {
            try
            {
                var student = new Students
                {
                    Name = dto.Name,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    BirthDay = dto.BirthDay,
                    Cpf = dto.Cpf
                };

                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();

                var user = new User
                {
                    Password = dto.Password,
                    RA = "123456" ,
                    Student = student
                };

            }
            catch (Exception f)
            {
                throw new Exception("Erro ao tentar criar usuário estudante" + f.Message);
            }
        }
    }
}
