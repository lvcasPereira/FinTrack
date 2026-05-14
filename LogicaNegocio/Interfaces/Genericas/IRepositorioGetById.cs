namespace LogicaNegocio.Interfaces
{
    public interface IRepositorioGetById<T>
    {
        public T GetById(int id);
    }
}
