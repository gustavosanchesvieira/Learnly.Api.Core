using Learnly.Api.Core.Data;
using Learnly.Api.Core.Interfaces;
using Learnly.Api.Core.Models;
using Learnly.Api.Core.Utils;

namespace Learnly.Api.Core.Services
{
    public class MatriculationService : IServiceBase<Matriculation>
    {
        private DataContext _dbContext;
        public MatriculationService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DefaultResponse Create(Matriculation obj)
        {
            try
            {
                _dbContext.Matriculations.Add(obj);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "Matrícula lançada com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Erro ao tentar lançar matrícula" + f.Message
                };
            }
        }

        public DefaultResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Matriculation>? Get()
        {
            try
            {
                return _dbContext.Matriculations.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Matriculation? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DefaultResponse Update(Matriculation obj)
        {
            try
            {
                var matriculation = _dbContext.Matriculations.
                    FirstOrDefault(x => x.StudentId == obj.StudentId && x.SubjectId == obj.SubjectId);
                if (matriculation == null)
                {
                    return new DefaultResponse
                    {
                        Sucess = false,
                        Message = "A matrícula não foi encontrada."
                    };
                }
                _dbContext.Update(matriculation);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "A matrícula foi atualizada com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Ocoreu um erro ao tentar atualizar a matrícula: " + f.Message
                };
            }
        }
    }
}
