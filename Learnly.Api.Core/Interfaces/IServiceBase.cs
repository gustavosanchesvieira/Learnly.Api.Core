

using Learnly.Api.Core.Utils;

namespace Learnly.Api.Core.Interfaces
{
    public interface IServiceBase<T>
    {
        IList<T>? Get();
        T? GetById(int id);
        DefaultResponse Create(T obj);
        DefaultResponse Update(T obj);
        DefaultResponse Delete(int id);

    }
}
