using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ApiModels
{
    public class MstLibraryCardModel
    {
        public Int32 Id { get; set; }
        public Int32 LibraryCardNumber { get; set; }
        public Int32 ManualLibraryCardNumber { get; set; }
        public Int32 BorrowerId { get; set; }
        public Boolean IsPrinted { get; set; }
        public Int32 LibraryInChargeUserId { get; set; }
        public String FootNote { get; set; }
        public Int32 CreatedByUserId { get; set; }
        public String CreatedDate { get; set; }
        public Int32 UpdatedByUserId { get; set; }
        public String UpdatedDate { get; set; }
    }
}
