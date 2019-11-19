namespace DotNetAdvanced.CoAndContrVariance
{
    public interface ICovariant<out T>
    {
        T GetT();
    }

    public class Covariant<T> : ICovariant<T>
    {
        public T GetT()
        {
            return default(T);
        }
    }
}
