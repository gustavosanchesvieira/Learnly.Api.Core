using AutoMapper;
using Learnly.Api.Core.Data;
using Learnly.Api.Core.Data.Dtos.Subject;
using Learnly.Api.Core.Interfaces;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Utils;
using Microsoft.EntityFrameworkCore;

namespace Learnly.Api.Core.Services
{
    public class SubjectsService : IServiceBase<Subjects>
    {
        private DataContext _dbContext;

        public SubjectsService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DefaultResponse Create(Subjects obj)
        {
            try
            {
                _dbContext.Subjects.Add(obj);
                _dbContext.SaveChanges();

                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "Matéria criada com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Erro ao tentar criar matéria: " + f.Message,
                };
            }
        }

        public DefaultResponse Delete(int id)
        {
            try
            {
                var subject = _dbContext.Subjects.FirstOrDefault(x => x.Id == id);
                if (subject == null)
                {
                    return new DefaultResponse
                    {
                        Sucess = false,
                        Message = "A matéria não foi encontrada."
                    };
                }
                _dbContext.Remove(subject);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "A matéria foi excluída com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Ocoreu um erro ao tentar deletar a matéria: " + f.Message
                };
            }
        }

        public IList<Subjects>? Get()
        {
            try
            {
                return _dbContext.Subjects.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Subjects? GetById(int id)
        {
            try
            {
                var subject = _dbContext.Subjects.FirstOrDefault(x => x.Id == id);
                return subject;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DefaultResponse Update(Subjects obj)
        {
            try
            {
                var subject = _dbContext.Subjects.FirstOrDefault(x => x.Id == obj.Id);
                if (subject == null)
                {
                    return new DefaultResponse
                    {
                        Sucess = false,
                        Message = "A matéria não foi encontrada."
                    };
                }

                _dbContext.Update(obj);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "A matéria foi atualizada com sucesso!"
                };

            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Ocoreu um erro ao tentar atualizar a matéria: " + f.Message
                };
            }
        }

        public List<ReadSubjectDto> GetSubjectsByStudent(int studentId)
        {
            try
            {
                var query = from subjects in _dbContext.Subjects
                            join matriculations in _dbContext.Matriculations on subjects.Id equals matriculations.SubjectId
                            where matriculations.StudentId == studentId
                            select new ReadSubjectDto 
                            { 
                                Id = matriculations.SubjectId,
                                Name = subjects.Name
                            };

                return query.ToList();
            }
            catch (Exception f)
            {
                throw new Exception("Erro ao buscar matérias do aluno: " + f.Message);
            }
        }
    }
}
