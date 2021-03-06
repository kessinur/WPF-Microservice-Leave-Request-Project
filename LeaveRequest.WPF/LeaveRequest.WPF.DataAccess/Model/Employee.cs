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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.TakeLeaves = new HashSet<TakeLeave>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Marriage { get; set; }
        public Nullable<int> Children_Total { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<int> Last_Year { get; set; }
        public Nullable<int> This_Year { get; set; }
        public Nullable<int> Manager_Id { get; set; }
        public string Religion { get; set; }
        public int Division_Id { get; set; }
        public int Position_Id { get; set; }
        public System.DateTimeOffset JoinDate { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public System.DateTimeOffset UpdateDate { get; set; }
        public System.DateTimeOffset DeleteDate { get; set; }
        public bool IsDelete { get; set; }
    
        public virtual Position Position { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TakeLeave> TakeLeaves { get; set; }
    }
}
