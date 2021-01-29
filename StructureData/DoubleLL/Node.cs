using System;
using System.Collections.Generic;
using System.Text;

namespace StructureData.DoubleLL
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(int value)
        {
            Value = value;
            Prev = null;
            Next = null;
        }
    }

}

