//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LeaveRequest.WPF.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log
    {
        public int Id { get; set; }
        public Nullable<System.DateTimeOffset> Log_Date { get; set; }
        public Nullable<int> Employee_Id { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public System.DateTimeOffset DeleteDate { get; set; }
        public bool IsDelete { get; set; }
    }
}