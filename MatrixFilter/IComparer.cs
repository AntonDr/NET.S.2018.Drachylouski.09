namespace MatrixSortTools
{
    public interface IComparer<T>
    {
        bool Compare(T [] firstitem,T [] seconditem);
    }
}
