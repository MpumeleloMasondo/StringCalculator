

namespace GenericLinkedList.Interface
{
    public interface IGenericLinkedList<T>
    {
     
        int Count { get; }
       
        bool Add(T element);
      
        bool RemoveAt(int index); 

        bool InsertAtPosition(
                        int index, T data);
     
    }
}
