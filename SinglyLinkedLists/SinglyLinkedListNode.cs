using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Stretch Goals: Using Generics, which would include implementing GetType() http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.110).aspx
namespace SinglyLinkedLists
{
    public class SinglyLinkedListNode : IComparable
    {
        // Used by the visualizer.  Do not change.
        public static List<SinglyLinkedListNode> allNodes = new List<SinglyLinkedListNode>();

        // READ: http://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx
        private SinglyLinkedListNode next;
        public SinglyLinkedListNode Next
        {
            get { return this.next; }
            set { 
              if(value == this){
                throw new ArgumentException("can't set to this");
             } else {
                this.next = value;
              } 
            }            
        }

        public override bool Equals(object obj) {
          //SinglyLinkedListNode node = obj as SinglyLinkedListNode;
          //return node != null && this.Value.Equals(node.Value);

          return this.CompareTo(obj) == 0;
        }

        public override string ToString() {
            return this.value;
        }

        private string value;
        public string Value
        {
          get { return this.value; }
        }

        public static bool operator <(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) < 0;
        }

        public static bool operator >(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) > 0;
        }

        public SinglyLinkedListNode(string value)
        {
          this.value = value;
            // Used by the visualizer:
            allNodes.Add(this);
        }

        // READ: http://msdn.microsoft.com/en-us/library/system.icomparable.compareto.aspx
        public int CompareTo(Object obj)
        {
          SinglyLinkedListNode node = obj as SinglyLinkedListNode;
          return node == null ? 1 : this.Value.CompareTo(node.Value);

          //if (obj == null) return 1;
          
          //SinglyLinkedListNode OtherNode = obj as SinglyLinkedListNode;
          //if(OtherNode != null){
          //  return this.value.CompareTo(OtherNode.value);
          //} 
          //else {
          //  throw new ArgumentException("obj is not a SingleLinkedListNode");
          //}
        }

        public bool IsLast() {
          return this.next == null;
        }

    }
}
