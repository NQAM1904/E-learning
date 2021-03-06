﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DATHINHEntities : DbContext
    {
        public DATHINHEntities()
            : base("name=DATHINHEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BUOIHOC> BUOIHOCs { get; set; }
        public virtual DbSet<CAHOC> CAHOCs { get; set; }
        public virtual DbSet<COSO> COSOes { get; set; }
        public virtual DbSet<DANHMUCSK> DANHMUCSKs { get; set; }
        public virtual DbSet<DIEM> DIEMs { get; set; }
        public virtual DbSet<EVENT> EVENTS { get; set; }
        public virtual DbSet<HOCKY> HOCKies { get; set; }
        public virtual DbSet<LICHHOCTUAN> LICHHOCTUANs { get; set; }
        public virtual DbSet<MONHOC> MONHOCs { get; set; }
        public virtual DbSet<NAMHOC> NAMHOCs { get; set; }
        public virtual DbSet<NGANH> NGANHs { get; set; }
        public virtual DbSet<NIENKHOA> NIENKHOAs { get; set; }
        public virtual DbSet<PERMISSION> PERMISSIONs { get; set; }
        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<STUDENT> STUDENTs { get; set; }
        public virtual DbSet<TIETHOC> TIETHOCs { get; set; }
        public virtual DbSet<TKB> TKBs { get; set; }
        public virtual DbSet<USER> USERs { get; set; }
    
        public virtual ObjectResult<string> proc_CryptData(string data)
        {
            var dataParameter = data != null ?
                new ObjectParameter("Data", data) :
                new ObjectParameter("Data", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("proc_CryptData", dataParameter);
        }
    }
}
