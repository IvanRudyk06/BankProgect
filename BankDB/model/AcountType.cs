//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankDB
{
    using model;
    using System;
    using System.Collections.Generic;

    public partial class AcountType : ICloneable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AcountType()
        {
            this.Acount = new HashSet<Acount>();
        }

        public int IdType { get; set; }
        private string name;
        public string nameType {
            get
            {
                if (name != null)
                {
                    return name.Trim();
                }
                else   return name;
            }
            set
            {
                name = value;
            }
        }
        public float interestRate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acount> Acount { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return this.name.Trim() + " " + this.interestRate + "%";
        }
    }
}