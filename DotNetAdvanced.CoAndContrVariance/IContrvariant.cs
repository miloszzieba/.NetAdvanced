namespace DotNetAdvanced.CoAndContrVariance
{
    public interface IContrvariant<in T>
    {
        void SetT(T entity);
    }

    public class Contrvariant<T> : IContrvariant<T>
    {
        public void SetT(T entity)
        {

        }
    }
}
