using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode newFirstNode;
        private SinglyLinkedListNode firstNode;
        private SinglyLinkedListNode currentNode;
        private SinglyLinkedListNode lastNode;
        private SinglyLinkedListNode nextNode;
        private SinglyLinkedListNode replaceNode;

        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                AddLast(values[i].ToString());
            }
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
            set
            {
                if(i == 0 )
                {
                    firstNode = new SinglyLinkedListNode(value);
                } else
                {
                    int count = 1;
                    nextNode = firstNode;
                    while(count < i)
                    {
                        nextNode = nextNode.Next;
                        count++;
                    }
                    SinglyLinkedListNode nodeToBeReplace = nextNode.Next;
                    replaceNode = new SinglyLinkedListNode(value);
                    nextNode.Next = replaceNode;
                    replaceNode.Next = nodeToBeReplace.Next;
                }
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            SinglyLinkedListNode NodeToCheck = firstNode;
            SinglyLinkedListNode NodeToAdd = new SinglyLinkedListNode(value);
            while(true)
            {
                if(NodeToCheck == null)
                {
                    throw new ArgumentException("Value not contained in list");
                }
                if(NodeToCheck.Value == existingValue)
                {
                    NodeToAdd.Next = NodeToCheck.Next;
                    NodeToCheck.Next = NodeToAdd;
                    break;
                }
                NodeToCheck = NodeToCheck.Next;
            }
        }

        public void AddFirst(string value)
        {
           newFirstNode = new SinglyLinkedListNode(value);
            newFirstNode.Next = firstNode;
            firstNode = newFirstNode;
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
            if(firstNode == null)
            {
                return -1;
            }
            if(value == firstNode.ToString())
            {
                return 0;
            } else
            {
                int index = 1;
                nextNode = firstNode.Next;
                while(nextNode != null)
                {
                    if(nextNode.ToString() == value)
                    {
                         return index;
                    }
                    nextNode = nextNode.Next;
                    index++;
                }
            }
            return -1;
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
            if(IndexOf(value) == -1)
            {
                throw new ArgumentException();
            } else
            {
                // loop through for index
            }
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
                nextNode = firstNode.Next;
            }
            else
            {
                return new string[] { };
            }
            if(nextNode == null)
            {
                return new string[] { firstNode.ToString() };
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
