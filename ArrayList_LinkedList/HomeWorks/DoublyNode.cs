using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorks
{
    public class DoublyNode
    {
        public int Value { get; set; }
        public DoublyNode Next { get; set; }
        public DoublyNode Prev { get; set; }
        public DoublyNode(int value)
        {
            this.Value = value;
        }
       /* public int GetValue()
        {
            return value;
        }
        public void SetValue(int value)
        {
            this.value = value;
        }
        public DoublyNode GetNext()
        {
            return next;
        }
        public void SetNext(DoublyNode next)
        {
            this.next = next;
        }
        public DoublyNode GetPrev()
        {
            return prev;
        }
        public void SetPrev(DoublyNode prev)
        {
            this.prev = prev;
        }*/
    }
}
