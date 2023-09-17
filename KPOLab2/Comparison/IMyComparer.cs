namespace Comparison
{
    public interface IMyComparer<T>
    {
        int MyCompare(T x, T y);
    }
}
