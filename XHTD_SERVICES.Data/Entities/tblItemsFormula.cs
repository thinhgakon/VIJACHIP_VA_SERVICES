//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XHTD_SERVICES.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblItemsFormula
    {
        public int Id { get; set; }
        public string RefNumber { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public Nullable<double> RecoveryRating { get; set; }
        public string Note { get; set; }
        public int State { get; set; }
        public Nullable<System.DateTime> CreateDay { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> UpdateDay { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<int> ItemId { get; set; }
    }
}
