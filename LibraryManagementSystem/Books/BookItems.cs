using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class BookItems
    {
        private string barcode;
        private bool isRefrenceOnly;
        private DateTime borrowedDate;
        private DateTime dueDate;
        private float price;
        private BookFormat format;
        private BookStatus status;
        private DateTime dateOfPurchase;
        private DateTime publicationDate;
        private Rack placedAt;
    }
    public class Rack
    {
        private int number;
        private String locationIdentifier;
    }
}
