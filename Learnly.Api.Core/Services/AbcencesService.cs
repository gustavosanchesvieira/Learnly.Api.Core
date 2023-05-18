using Learnly.Api.Core.Data;
using Learnly.Api.Core.Interfaces;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Utils;

namespace Learnly.Api.Core.Services
{
    public class AbcencesService : IServiceBase<Abcences>
    {
        private DataContext _dbContext;

        public AbcencesService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DefaultResponse Create(Abcences obj)
        {
            try
            {
                _dbContext.Abcenses.Add(obj);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "Falta lançada com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Erro ao tentar lançar falta" + f.Message
                };
            }
        }

        public DefaultResponse Delete(int id)
        {
            try
            {
                var abcence = _dbContext.Abcenses.FirstOrDefault(x => x.Id == id);
                if (abcence == null)
                {
                    return new DefaultResponse
                    {
                        Sucess = false,
                        Message = "A fala não foi encontrada."
                    };
                }
                _dbContext.Remove(abcence);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "A falta foi excluída com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Ocoreu um erro ao tentar deletar a falta: " + f.Message
                };
            }
        }

        public IList<Abcences>? Get()
        {
            try
            {
                return _dbContext.Abcenses.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Abcences? GetById(int id)
        {
            try
            {
                var abcence = _dbContext.Abcenses.FirstOrDefault(x => x.Id == id);
                return abcence;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DefaultResponse Update(Abcences obj)
        {
            try
            {
                var abcence = _dbContext.Abcenses.FirstOrDefault(x => x.Id == obj.Id);
                if (abcence == null)
                {
                    return new DefaultResponse
                    {
                        Sucess = false,
                        Message = "A fala não foi encontrada."
                    };
                }
                _dbContext.Update(abcence);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "A falta foi atualizada com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Ocoreu um erro ao tentar atualizar a falta: " + f.Message
                };
            }
        }

        public Abcences? GetAbcenceSubjectByStudent(int studentId, int subjectId)
        {
            try
            {
                var abcence = _dbContext.Abcenses.FirstOrDefault(x => x.StudentId == studentId 
                && x.SubjectId == subjectId);
                return abcence;
            }
            catch (Exception f)
            {
                throw new Exception("Erro ao recuperar falta da matéria: " + f.Message);
            }
        }
    }
}
