using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class LLAddTwoNumbers
    {
        public LLAddTwoNumbers()
        {

        }
        public ListNode addTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(-1);
            ListNode l3 = head;
            int carry = 0, x, y;
            while (l1 != null || l2 != null || carry > 0)
            {
                x = l1 == null ? 0 : l1.val;
                y = l2 == null ? 0 : l2.val;
                l3.next = new ListNode((x + y + carry) % 10);
                carry = (x + y + carry) / 10;
                l3 = l3.next;
                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
            }
            return head.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
