﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class MergeTwoSortedLists
    {
        public MergeTwoSortedLists()
        {

        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            //Edge Case
            if (l1 == null)
            {
                return l2;
            }else if (l2 == null)
            {
                return l1;

            }
            else if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
