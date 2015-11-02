using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode firstNode;

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
                SinglyLinkedListNode nextNode;
                if (firstNode == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                nextNode = firstNode;
                if (i < 0)
                {
                    i = Count() + i;
                }
                for (int n = 0; n < i; n++)
                {
                    if (nextNode == null)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    nextNode = nextNode.Next;
                }
                return nextNode.ToString();
            }
            set
            {
                SinglyLinkedListNode nextNode;
                SinglyLinkedListNode replaceNode;
                if (i == 0 )
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
            SinglyLinkedListNode newFirstNode = new SinglyLinkedListNode(value);
            newFirstNode.Next = firstNode;
            firstNode = newFirstNode;
        }

        public void AddLast(string value)
        {
            SinglyLinkedListNode nextNode;
            if (firstNode == null)
            {
                firstNode = new SinglyLinkedListNode(value);
            }
            else
            {
                nextNode = firstNode;
                while(nextNode != null)
                {
                    if(nextNode.Next == null)
                    {
                        AddAfter(nextNode.Value, value);
                        break;
                    }
                    else
                    {
                        nextNode = nextNode.Next;
                    } 
                }
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            SinglyLinkedListNode nextNode;
            int count = 0;
            if(firstNode == null)
            {
                return count;
            }
            else
            {
                count += 1;
                nextNode = firstNode.Next;
                while(nextNode != null)
                {
                    count += 1;
                    nextNode = nextNode.Next;
                }
                return count;
            }
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
            SinglyLinkedListNode nextNode;
            if (firstNode == null)
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
            SinglyLinkedListNode nextNode;
            if (firstNode == null || firstNode.Next == null)
            {
                return true;
            } else
            {
                nextNode = firstNode;
                while( nextNode != null )
                {
                    if ( nextNode.Next != null && nextNode > nextNode.Next)
                    {
                        return false;
                    } else
                    {
                        nextNode = nextNode.Next;
                    }
                }
                return true; 
            }
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            if(firstNode == null)
            {
                return null;
            }
            return ElementAt(Count() - 1);
        }
        
        public void Remove(string value)
        {
            SinglyLinkedListNode nextNode;
            int index = IndexOf(value);
            if(index == -1)
            {
                // doesn't exist
            } else if (index == 0)
            {
                firstNode = firstNode.Next;
            } else 
            {
                nextNode = firstNode;
                for (int i = 0; i < (index - 1); i++)
                {
                    nextNode = nextNode.Next;
                }
                nextNode.Next = nextNode.Next.Next;
            }
        }

        public void Sort()
        {
            if(Count() > 1 && !IsSorted())
            {
                firstNode = MergeSort(firstNode);
            }
        }

        public SinglyLinkedListNode MergeSort(SinglyLinkedListNode first)
        {
            SinglyLinkedListNode head = first;
            SinglyLinkedListNode rHead;
            if(head == null || head.Next == null)
            {
                return head;
            }
            SinglyLinkedListNode lastNodeInLeftList = Split(head);
            rHead = lastNodeInLeftList.Next;
            // chop List
            lastNodeInLeftList.Next = null;
            
            return Combine(MergeSort(head), MergeSort(rHead));
        }

        public SinglyLinkedListNode Combine(SinglyLinkedListNode lHead, SinglyLinkedListNode rHead)
        {
            if (lHead == null)
            {
                return rHead;
            }
            if(rHead == null)
            {
                return lHead;
            }
            if(lHead < rHead)
            {
                lHead.Next = Combine(lHead.Next, rHead);
                return lHead;
            } else
            {
                rHead.Next = Combine(lHead, rHead.Next);
                return rHead;
            }
        }

        public SinglyLinkedListNode Split(SinglyLinkedListNode head)
        {
            // returns the last node in left list
            SinglyLinkedListNode slow;
            SinglyLinkedListNode fast;
            if(head == null || head.Next == null)
            {
                return head;
            } else
            {
                slow = head;
                fast = head.Next;
                while(fast != null)
                {
                    fast = fast.Next;
                    if(fast != null)
                    {
                        slow = slow.Next;
                        fast = fast.Next;
                    }
                }
                return slow;
            }
        }
       
        

        public string[] ToArray()
        {
            SinglyLinkedListNode nextNode;
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
            SinglyLinkedListNode nextNode;
            string left_br = "{";
            string right_br = "}";
            string space = " ";
            string comma = ",";
            string quote = "\"";
            StringBuilder s = new StringBuilder(left_br);
            
            nextNode = firstNode;
            while(nextNode != null)
            {
                s.Append(space);
                s.Append(quote);
                s.Append(nextNode.Value);
                s.Append(quote);
                if (nextNode.IsLast())
                {
                    break;
                } else
                {
                    s.Append(comma);
                }
                nextNode = nextNode.Next;
            }
            s.Append(space + right_br);
            return s.ToString();
        }
    }
}
