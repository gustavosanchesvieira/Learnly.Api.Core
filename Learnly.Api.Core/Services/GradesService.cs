using Learnly.Api.Core.Data;
using Learnly.Api.Core.Interfaces;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Utils;

namespace Learnly.Api.Core.Services
{
    public class GradesService : IServiceBase<Grades>
    {
        private DataContext _dbContext;

        public GradesService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DefaultResponse Create(Grades obj)
        {
            try
            {
                _dbContext.Grades.Add(obj);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "Notas salvas com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Erro ao tentar salvar notas de aula" + f.Message
                };
            }
        }

        public DefaultResponse Delete(int id)
        {
            try
            {
                var grade = _dbContext.Grades.FirstOrDefault(x => x.Id == id);
                if (grade == null)
                {
                    return new DefaultResponse
                    {
                        Sucess = false,
                        Message = "Notas não encontradas."
                    };
                }
                _dbContext.Remove(grade);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "As notas foram excluidas com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Ocoreu um erro ao tentar excluir as notas: " + f.Message
                };
            }
        }

        public IList<Grades>? Get()
        {
            try
            {
                return _dbContext.Grades.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Grades? GetById(int id)
        {
            try
            {
                return _dbContext.Grades.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DefaultResponse Update(Grades obj)
        {
            try
            {
                var grade = _dbContext.Grades.FirstOrDefault(x => x.Id == obj.Id);
                if (grade == null)
                {
                    return new DefaultResponse
                    {
                        Sucess = false,
                        Message = "Notas não encontradas."
                    };
                }
                _dbContext.Update(grade);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "As notas foram atualizadas com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Ocoreu um erro ao tentar excluir as notas: " + f.Message
                };
            }
        }
    }
}
