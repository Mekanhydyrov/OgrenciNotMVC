//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciNotMVC.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblNot
    {
        public int Notid { get; set; }
        public Nullable<byte> Dersid { get; set; }
        public Nullable<int> Ogrid { get; set; }
        public Nullable<byte> Viza { get; set; }
        public Nullable<byte> Final { get; set; }
        public Nullable<byte> But { get; set; }
        public Nullable<byte> Proje { get; set; }
        public Nullable<decimal> Ortalama { get; set; }
        public Nullable<bool> Durum { get; set; }
    
        public virtual TblDers TblDers { get; set; }
        public virtual TblOgrenci TblOgrenci { get; set; }
    }
}
