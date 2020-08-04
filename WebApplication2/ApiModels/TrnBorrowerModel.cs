using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ApiModels
{
    public class TrnBorrowerModel
    {
        public Int32 Id { get; set; }
        public Int32 BorrowNumber { get; set; }
        public Int32 BookNumber { get; set; }
        public String BorrowDate { get; set; }
        public Int32 ManualBorrowNumber { get; set; }
        public Int32 BorrowerId { get; set; }
        public Int32 LibraryCardId { get; set; }
        public String PreparedByUser { get; set; }
        public Int32 CreatedByUserId { get; set; }
        public String CreatedDate { get; set; }
        public Int32 UpdatedByUserId { get; set; }
        public String UpdatedDate { get; set; }
    }
}
