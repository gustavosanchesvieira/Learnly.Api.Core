using Learnly.Api.Core.Data;
using Learnly.Api.Core.Data.Dtos.Lessons;
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
                    Sucess = true,
                    Message = "Horario de aula criado com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
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
                        Sucess = false,
                        Message = "Horario de aula não encontrado."
                    };
                }
                _dbContext.Remove(lesson);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "O horario de aula foi excluído com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
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
                        Sucess = false,
                        Message = "Horario de aula não encontrado."
                    };
                }
                _dbContext.Update(lesson);
                _dbContext.SaveChanges();
                return new DefaultResponse
                {
                    Sucess = true,
                    Message = "Horário de aula atualizado com sucesso!"
                };
            }
            catch (Exception f)
            {
                return new DefaultResponse
                {
                    Sucess = false,
                    Message = "Ocoreu um erro ao tentar atualizar o horário de aula: " + f.Message
                };
            }
        }

        public List<ReadLessonsDto> GetScheduledLessonsByStudent(int studentId)
        {
            try
            {
                var query = from lessons in _dbContext.Lessons
                            join subjects in _dbContext.Subjects on lessons.SubjectId equals subjects.Id
                            join matriculations in _dbContext.Matriculations on subjects.Id equals matriculations.SubjectId
                            where matriculations.StudentId == studentId
                            select new ReadLessonsDto
                            {
                                Id = lessons.Id,
                                DayWeek = lessons.DayWeek,
                                Scheduled = lessons.Scheduled,
                                SubjectName = subjects.Name
                            };
                return query.ToList();
            }
            catch (Exception f)
            {
                throw new Exception("Erro ao buscar horários das matérias: " + f.Message);
            }
        }

    }
}
