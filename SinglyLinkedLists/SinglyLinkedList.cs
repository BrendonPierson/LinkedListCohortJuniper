using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode firstNode;
        private SinglyLinkedListNode currentNode;
        private SinglyLinkedListNode lastNode;
        private SinglyLinkedListNode nextNode;

        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            //for (int i = 0; i < values.Length; i++)
            //{
            //    this[i] = values[i].ToString();
            //}
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get
            {
                if(firstNode == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if(i == 0)
                {
                    return firstNode.ToString();
                } else
                {
                    nextNode = firstNode.Next;
                    for (int n = 1; n < i; n++)
                    {
                        nextNode = nextNode.Next;
                        if (nextNode == null)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                    return nextNode.ToString();
                }
            }
            set { this[i] = value; }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            throw new NotImplementedException();

        }

        public void AddLast(string value)
        {
            if (firstNode == null)
            {
                firstNode = new SinglyLinkedListNode(value);
            } else if (currentNode == null)
            {
                currentNode = new SinglyLinkedListNode(value);
                firstNode.Next = currentNode;
            } else if(lastNode == null)
            {
                lastNode = new SinglyLinkedListNode(value);
                currentNode.Next = lastNode;
            } else
            {
                currentNode = lastNode;
                lastNode = new SinglyLinkedListNode(value);
                currentNode.Next = lastNode;
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            throw new NotImplementedException();
        }

        public string ElementAt(int index)
        {
            return this[index];
        }

        public string First()
        {
            if (null == firstNode)
            {
                return null;
            }
            return firstNode.Value;
        }

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            if(lastNode == null)
            {
                if(firstNode != null)
                {
                    return firstNode.ToString();
                }
                else
                {
                    return null;
                }
            } else
            {
                return lastNode.ToString();
            }
        }


        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            string list = "";
            if (firstNode != null)
            {
                list += firstNode.ToString();
            }
            else
            {
                return new string[] { };
            }

            while (nextNode != null)
            {
                list += "," + nextNode.ToString();
                nextNode = nextNode.Next;
            }
            return list.Split(',');
        }

        public override string ToString()
        {
            string list = "{";
            nextNode = firstNode;
            if(nextNode != null)
            {
                list += " \"" + nextNode.ToString() + "\"";
                nextNode = nextNode.Next;
            }
            while(nextNode != null)
            {
                list += ", \"" + nextNode.ToString() + "\"";
                nextNode = nextNode.Next;
            }
            list += " }";
            return list;
        }
    }
}
