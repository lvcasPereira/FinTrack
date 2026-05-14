namespace LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICULogin<T_entrada, T_salida>
    {
        public T_salida Execute(T_entrada obj);
    }
}
