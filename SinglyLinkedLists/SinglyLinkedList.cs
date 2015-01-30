using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists {
  public class SinglyLinkedList {

    private SinglyLinkedListNode firstNode;
    private SinglyLinkedListNode LastNode = null;

    // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
    public SinglyLinkedList(params object[] values) { 

      foreach(string item in values){
        this.AddLast(item);
      }
    }

    // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
    public string this[int i] {
      get {
        string[] listArray = this.ToArray();

        return listArray[i];
      }
      set {
        SinglyLinkedListNode currentNode = firstNode;
        int listCount = this.Count();
        for (int a = 0; a <= listCount; a++) {
          if (i == 0) {
            firstNode = new SinglyLinkedListNode(value);
          }
          if (a == (i-1)) {
            currentNode.Next = new SinglyLinkedListNode(value);
          } 
          else {
            currentNode = currentNode.Next;
          }
        }
      }
    }

    public void AddAfter(string existingValue, string value) {
      SinglyLinkedListNode currentNode = firstNode;
      SinglyLinkedListNode replacedNode;
      int index = 0;
      int totalItems = this.Count();

      while(currentNode != null){
        if (currentNode.Value == existingValue) {
          replacedNode = currentNode.Next;
          currentNode.Next = new SinglyLinkedListNode(value);
          currentNode.Next.Next = replacedNode;
          break;
        }
        else {
          index++;
          if (totalItems == index)
            throw new ArgumentException();
          currentNode = currentNode.Next;
        }
      }
    }
      //  if (currentNode.Value == existingValue) {
      //    if(currentNode.IsLast()) {
      //      currentNode.Next = new SinglyLinkedListNode(value);
      //      break;
      //    }
      //    else {
            
      //    }
      //  }
      //  else {
      //    currentNode = currentNode.Next;
      //  }
      //

    public void AddFirst(string value) {
      SinglyLinkedListNode replacedNode = null;
      if (firstNode == null) {
        firstNode = new SinglyLinkedListNode(value);
      }
      else {
        replacedNode = firstNode;
        firstNode = new SinglyLinkedListNode(value);
        firstNode.Next = replacedNode;
      }
    }

    public void AddLast(string value) {
      if (firstNode == null) {
        firstNode = new SinglyLinkedListNode(value);
      }
      else {

        SinglyLinkedListNode currentNode = firstNode;
        while (!currentNode.IsLast()) {
          currentNode = currentNode.Next;
        }
        currentNode.Next = new SinglyLinkedListNode(value);
        LastNode = currentNode.Next;
      }
    }

    // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
    public int Count() {
      int count = 0;
      if (firstNode != null) {
        SinglyLinkedListNode currentNode = firstNode;
        count = 1;
        while (currentNode.Next != null) {
          count += 1;
          currentNode = currentNode.Next;
        }
      }
      return count;
    }

    public string ElementAt(int index) {
      SinglyLinkedListNode currentNode = firstNode;

      if (firstNode == null)
        throw new ArgumentOutOfRangeException("no items in list");

      for (var a = 0; a < index; a++) {
        if (currentNode.IsLast())
          throw new ArgumentOutOfRangeException("no items at this index");

        currentNode = currentNode.Next;
      }

      return currentNode.Value;
    }

    public string First() {
      return firstNode != null ? firstNode.Value : null;
    }

    public int IndexOf(string value) {

      SinglyLinkedListNode currentNode = firstNode;
      int listCount = this.Count();

      if (listCount == 0)
        return -1;

        for (int i = 0; i <= listCount; i++) {
          if (currentNode.Value == value) {
            return i;
          }
          else {
            currentNode = currentNode.Next;
            if (i+1 == listCount) {
              return -1;
            }
          }
        }
      return -1;
    }

    public bool IsSorted() {
      int listCount = this.Count();
      SinglyLinkedListNode currentNode = firstNode;
      bool isSorted = true;

      if (firstNode == null) {
        return isSorted;
      }

      while (!currentNode.IsLast()) {
        if (currentNode > currentNode.Next) {
          return false;
        }
        currentNode = currentNode.Next;
       }
      return isSorted;
    }

    // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
    // HINT 2: I suggest writing a private helper method LastNode()
    // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
    public string Last() {
      if (LastNode == null && firstNode == null)
        return null;
      if (LastNode == null && firstNode != null)
        return firstNode.ToString();
      
      return LastNode.ToString();
    }

    public void Remove(string value) {
      int listCount = this.Count();
      SinglyLinkedListNode currentNode = firstNode;

      if (value == firstNode.Value) {
        firstNode = firstNode.Next;
      }

      while (currentNode.Next != null) {
        if (currentNode.Next.Value == value) {
          currentNode.Next = currentNode.Next.Next;
          break;
        }
        else {
          currentNode = currentNode.Next;
        }
      }
    }

    public void Sort() {

      if (firstNode == null || firstNode.Next == null)
        return;
      int listCount = this.Count();
      SinglyLinkedList newList = new SinglyLinkedList();

      while (newList.Count() < listCount || firstNode != null) {

        SinglyLinkedListNode lowest = firstNode;
        SinglyLinkedListNode comparee = firstNode;
        for (var i = 0; i <= this.Count(); i++) {
          if (comparee == null) {
            break;
          }

          if ( lowest > comparee && comparee != null) {
            lowest = comparee;
          }
          comparee = comparee.Next;
        }
        newList.AddLast(lowest.Value);
        this.Remove(lowest.Value);
        lowest = firstNode;
      }
      firstNode = newList.firstNode;
      firstNode.Next = newList.firstNode.Next;
    }

    public string[] ToArray(){
      int nodeCount = Count();
      string[] newArray = new string[nodeCount];
      SinglyLinkedListNode currentNode = firstNode;

      if (nodeCount != 0) {
        newArray[0] = currentNode.Value;
        for(int i = 1; i < nodeCount; i++){
          newArray[i] = currentNode.Next.Value;
          currentNode = currentNode.Next;
        }
        return newArray;
      }
      else {
        return new string[]{};
      }
    }


    public override string ToString() {
      StringBuilder list = new StringBuilder();
      var currentNode = firstNode;

      if (firstNode != null) {
        list.Append("{ ");
        list.Append("\"" + firstNode.Value + "\"");
        while (currentNode.Next != null) {
          list.Append(", ");
          list.Append("\"");
          list.Append(currentNode.Next.Value);
          list.Append("\"");
          currentNode = currentNode.Next;
        }
        list.Append(" }");
      }
      else {
        list.Append("{ }");
      }

      return list.ToString();
    }
  }
}
