namespace CRUD_ASP.NET_MVC_ADO.NET.Repositories.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> Lista();

        Task<bool> Guardar(T modelo);

        Task<bool> Editar(T modelo);

        Task<bool> Delete(int id);
    }
}