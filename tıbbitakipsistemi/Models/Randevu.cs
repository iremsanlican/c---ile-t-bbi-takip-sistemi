//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tıbbitakipsistemi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Randevu
    {
        public int ID { get; set; }
        public Nullable<int> KullaniciId { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string Hastane { get; set; }
        public string Bölüm { get; set; }
    
        public virtual Kullanici Kullanici { get; set; }
    }
}
