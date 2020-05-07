

namespace GenericLinkedList.Interface
{
    public interface IGenericLinkedList<T>
    {
        /// <summary>
        /// Count property of list.
        /// </summary>
        /// <value>Number of elements in the list</value>
        int Count { get; }
        /// <summary> Add the specified element to the end of the list. </summary>
        /// <returns>
        /// Returns true if operation was successful. False if otherwise.
        /// </returns>
        /// <param name="element">Element to be added.</param>
        bool Add(T element);
        /// <summary>
        /// Remove the first instance of the specified element from the list. 
        /// </summary>
        /// <returns> True if operation was successful. False if otherwise</returns>
        /// <param name="element">Element to be removed from the list</param>
        bool RemoveAt(int index); 

        bool InsertAtPosition(
                        int index, T data);
        /// <summary>
        /// Clears all the elements inside the List and resets its Count property to 0.
        /// </summary>
        //void Clear();
        ///// <summary>
        ///// Checks to see if the specified element is present in the list. 
        ///// </summary>
        ///// <param name="element">Element.</param>
        ///// <returns> True if operation was successful. False if otherwise.</returns>
        //bool Contains(T element);

    }
}
