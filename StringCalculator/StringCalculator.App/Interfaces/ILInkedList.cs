namespace StringCalculator.App.Interfaces
{
    public interface ILinkedList<T>
    {
        void Insert(T data, int position);
        void Delete(int position);
        void PrintList();
    }
}
