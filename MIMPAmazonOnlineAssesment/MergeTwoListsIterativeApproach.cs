using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class MergeTwoListsIterativeApproach
    {
        public MergeTwoListsIterativeApproach()
        {
            
        }
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            //Define an unchanging reference to node ahead of the returning node
            ListNode prehead = new ListNode(-1);

            ListNode prev = prehead; // pointing to current node
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    prev.next = l1; // assign prev.next to value of l1
                    l1 = l1.next; //increment l1 with l1.next
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next; // prev point to current node
            }

            //depending upon l1 and l2 length, one of the Lists will be non null,
            //so connect non null list to the end of the merge list

            prev.next = l1 == null ? l2 : l1;

            return prehead.next;

        }
    }
}
