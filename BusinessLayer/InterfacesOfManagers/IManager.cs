using System.Linq.Expressions;
using EntityLayer.ResultModel;

namespace BusinessLayer.InterfacesOfManagers;

public interface IManager<T, Id>
{

    IDataResult<T> Add(T model); // ekleme için IResult değil IDataREsult kullandık. Çünkü eklenen verinin idsine ihtiyaç duyarsak geriye dönen datadan idyi alabiliriz.
    IResult Update(T model);
    IResult Delete(T model);
    IDataResult<ICollection<T>> GetAll(Expression<Func<T, bool>>? filter = null);
    IDataResult<T> GetByConditions(Expression<Func<T, bool>>? filter = null);
    IDataResult<T> GetById(Id id);

}