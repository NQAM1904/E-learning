//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DACS
{
    using System;
    using System.Collections.Generic;
    
    public partial class DIEM
    {
        public int IDSTUDENT { get; set; }
        public Nullable<double> DIEMTB { get; set; }
        public Nullable<int> STCDAT { get; set; }
        public int IDDIEM { get; set; }
        public Nullable<double> TONGDIEM { get; set; }
        public int IDMONHOC { get; set; }
    
        public virtual MONHOC MONHOC { get; set; }
        public virtual STUDENT STUDENT { get; set; }
    }
}
