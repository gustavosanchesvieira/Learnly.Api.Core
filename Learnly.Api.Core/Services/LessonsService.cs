using Learnly.Api.Core.Data;
using Learnly.Api.Core.Interfaces;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Utils;

namespace Learnly.Api.Core.Services
{
    public class LessonsService : IServiceBase<Lessons>
    {
        private DataContext _dbContext;

        public LessonsService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DefaultResponse Create(Lessons obj)
        {
            try
            {
                _dbContext.Lessons.Add(obj);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucesso = true,
                    Message = "Horario de aula criado com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucesso = false,
                    Message = "Erro ao tentar criar horario de aula" + f.Message
                };
            }
        }

        public DefaultResponse Delete(int id)
        {
            try
            {
                var lesson = _dbContext.Lessons.FirstOrDefault(x => x.Id == id);
                if (lesson == null)
                {
                    return new DefaultResponse
                    {
                        Sucesso = false,
                        Message = "Horario de aula não encontrado."
                    };
                }
                _dbContext.Remove(lesson);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucesso = true,
                    Message = "O horario de aula foi excluído com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucesso = false,
                    Message = "Ocoreu um erro ao tentar excluir o horario de aula: " + f.Message
                };
            }
        }

        public IList<Lessons>? Get()
        {
            try
            {
                return _dbContext.Lessons.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Lessons? GetById(int id)
        {
            try
            {
                var lesson = _dbContext.Lessons.FirstOrDefault(x => x.Id == id);
                return lesson;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DefaultResponse Update(Lessons obj)
        {
            try
            {
                var lesson = _dbContext.Lessons.FirstOrDefault(x => x.Id == obj.Id);
                if (lesson == null)
                {
                    return new DefaultResponse
                    {
                        Sucesso = false,
                        Message = "Horario de aula não encontrado."
                    };
                }
                _dbContext.Update(lesson);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucesso = true,
                    Message = "Horário de aula atualizado com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucesso = false,
                    Message = "Ocoreu um erro ao tentar atualizar o horário de aula: " + f.Message
                };
            }
        }

    }
}
