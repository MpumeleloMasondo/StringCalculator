using System;
using GenericLinkedList.Generic;

namespace GenericLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            GenericLinkedList<string> genericLinkedList = new GenericLinkedList<string>();

            genericLinkedList.Add("Item 1");
            genericLinkedList.Add("Item 2");
            genericLinkedList.Add("Item 4");
            
            genericLinkedList.PrintList(genericLinkedList.Head); 

            genericLinkedList.InsertAtPosition(3, "Item 3");
            genericLinkedList.InsertAtPosition(7, "Item 5");

            genericLinkedList.PrintList(genericLinkedList.Head); 

            genericLinkedList.RemoveAt(1);
            
            genericLinkedList.PrintList(genericLinkedList.Head);


        }
    }
}
