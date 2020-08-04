using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ApiModels
{
    public class MstLibraryBookModel
    {
        public Int32 Id { get; set; }
        public Int32 BookNumber { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public String EditionNumber { get; set; }
        public String PlaceOfPublication { get; set; }
        public String CopyRightDate { get; set; }
        public String ISBN { get; set; }
        public Int32 CreatedByUserId { get; set; }
        public String CreatedBy { get; set; }
        public String CreatedDate { get; set; }
        public Int32 UpdatedByUserId { get; set; }
        public String UpdatedBy { get; set; }
        public String UpdatedDate { get; set; }
    }
}
