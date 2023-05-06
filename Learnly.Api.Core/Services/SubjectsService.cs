using AutoMapper;
using Learnly.Api.Core.Data;
using Learnly.Api.Core.Interfaces;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Utils;
using Microsoft.EntityFrameworkCore;

namespace Learnly.Api.Core.Services
{
    public class SubjectsService : IServiceBase<Subjects>
    {
        private DataContext _dbContext;
        private IMapper _mapper;

        public SubjectsService(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public DefaultResponse Create(Subjects obj)
        {
            try
            {
                _dbContext.Subjects.Add(obj);
                _dbContext.SaveChanges();

                return new DefaultResponse
                {
                    Sucesso = true,
                    Message = "Matéria criada com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucesso = false,
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
                        Sucesso = false,
                        Message = "A matéria não foi encontrada."
                    };
                }
                _dbContext.Remove(subject);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucesso = true,
                    Message = "A matéria foi excluída com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucesso = false,
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
                        Sucesso = false,
                        Message = "A matéria não foi encontrada."
                    };
                }

                _dbContext.Update(obj);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucesso = true,
                    Message = "A matéria foi atualizada com sucesso!"
                };

            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucesso = false,
                    Message = "Ocoreu um erro ao tentar atualizar a matéria: " + f.Message
                };
            }
        }
    }
}
