using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Books
{
    public interface IBook
    {
        string ISBN { get; set; }
        string title { get; set; }
        string subject { get; set; }
        string publisher { get; set; }
        string language { get; set; }
        int numberOfPages { get; set; }
        List<string> Authors { get; set; }
    }
}
