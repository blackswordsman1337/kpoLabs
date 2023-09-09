namespace KPOLab2.Controller
{
    public interface IComparator<T>
    {
        int Compare(T x, T y);
    }
}
