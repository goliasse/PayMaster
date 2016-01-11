using Paymaster.Model.Interfaces;

namespace Paymaster.DBServices
{
    public interface IDBService<T, U> where T : IIdAble<U>
    {
        T FindById(U recordId);
    }
}