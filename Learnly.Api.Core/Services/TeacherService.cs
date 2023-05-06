using AutoMapper;
using Learnly.Api.Core.Data;
using Learnly.Api.Core.Interfaces;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Utils;
using Microsoft.EntityFrameworkCore;

namespace Learnly.Api.Core.Services
{
    public class TeacherService : IServiceBase<Teacher>
    {
        private DataContext _dbContext;
        private IMapper _mapper;

        public TeacherService(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public DefaultResponse Create(Teacher obj)
        {
            try
            {
                _dbContext.Teachers.Add(obj);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucesso = true,
                    Message = "Professor criado com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucesso = false,
                    Message = "Erro ao tentar criar professor" + f.Message
                };
            }
        }

        public DefaultResponse Delete(int id)
        {
            try
            {
                var teacher = _dbContext.Teachers.FirstOrDefault(x => x.Id == id);
                if (teacher == null)
                {
                    return new DefaultResponse
                    {
                        Sucesso = false,
                        Message = "Professor não encontrado."
                    };
                }
                _dbContext.Remove(teacher);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucesso = true,
                    Message = "Professor deletado com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucesso = false,
                    Message = "Erro ao tentar deletar professor" + f.Message
                };
            }
        }

        public IList<Teacher>? Get()
        {
            try
            {
                return _dbContext.Teachers.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Teacher? GetById(int id)
        {
            try
            {
                var teacher = _dbContext.Teachers.FirstOrDefault(x => x.Id == id);
                return teacher;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DefaultResponse Update(Teacher obj)
        {
            try
            {
                var teacher = _dbContext.Teachers.FirstOrDefault(x => x.Id == obj.Id);
                if (teacher == null)
                {
                    return new DefaultResponse
                    {
                        Sucesso = false,
                        Message = "Professor não encontrado."
                    };
                }
                _dbContext.Update(obj);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucesso = true,
                    Message = "Professor atualizado com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucesso = false,
                    Message = "Erro ao tentar deletar professor" + f.Message
                };
            }
        }
    }
}
