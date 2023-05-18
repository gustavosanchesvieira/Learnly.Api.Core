using AutoMapper;
using Learnly.Api.Core.Data;
using Learnly.Api.Core.Interfaces;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Utils;
using Microsoft.EntityFrameworkCore;

namespace Learnly.Api.Core.Services
{
    public class StudentsService : IServiceBase<Students>
    {
        private DataContext _dbContext;

        public StudentsService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DefaultResponse Create(Students obj)
        {
            try
            {
                _dbContext.Students.Add(obj);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "Aluno criado com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Erro ao tentar criar aluno" + f.Message
                };
            }
        }

        public DefaultResponse Delete(int id)
        {
            try
            {
                var student = _dbContext.Students.FirstOrDefault(x => x.Id == id);
                if (student == null)
                {
                    return new DefaultResponse
                    {
                        Sucess = false,
                        Message = "O aluno não foi encontrado."
                    };
                }
                _dbContext.Remove(student);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "O aluno foi excluído com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Ocoreu um erro ao tentar deletar o aluno: " + f.Message
                };
            }
        }

        public IList<Students>? Get()
        {
            try
            {
                return _dbContext.Students.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Students? GetById(int id)
        {
            try
            {
                var student = _dbContext.Students.FirstOrDefault(x => x.Id == id);
                return student;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DefaultResponse Update(Students obj)
        {
            try
            {
                var student = _dbContext.Subjects.FirstOrDefault(x => x.Id == obj.Id);
                if (student == null)
                {
                    return new DefaultResponse
                    {
                        Sucess = false,
                        Message = "O aluno não foi encontrado."
                    };
                }

                _dbContext.Update(obj);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "O aluno foi atualizada com sucesso!"
                };

            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Ocoreu um erro ao tentar atualizar o aluno: " + f.Message
                };
            }
        }
    }
}
