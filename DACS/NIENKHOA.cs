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
    
    public partial class NIENKHOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NIENKHOA()
        {
            this.NGANHs = new HashSet<NGANH>();
        }
    
        public int IDNIENKHOA { get; set; }
        public string NAMENIENKHOA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NGANH> NGANHs { get; set; }
    }
}
