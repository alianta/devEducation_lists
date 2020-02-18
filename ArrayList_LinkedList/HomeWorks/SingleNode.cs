using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorks
{
    public class SingleNode
    {
        public int Value { get; set; }
        public SingleNode Next { get; set; }
        public SingleNode(int value)
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
        public SingleNode GetNext()
        {
            return next;
        }
        public void SetNext(SingleNode next)
        {
            this.next = next;
        }*/
    }
}
