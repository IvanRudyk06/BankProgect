

namespace BankDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Acount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Acount()
        {
            this.Operation = new HashSet<Operation>();
        }
    
        public int IdAcount { get; set; }
        public int IdClient { get; set; }
        public int IdType { get; set; }
        
        public DateTime DateOpen { get; set; }
        public DateTime DateClose { get; set; }

        public String DateOp
        {
            get
            {
                return DateOpen.Date.Day.ToString() + "." + DateOpen.Date.Month.ToString() + "." + DateOpen.Date.Year.ToString();
            }
        }

        public String DateCl
        {
            get
            {
                return DateClose.Date.Day.ToString() + "." + DateClose.Date.Month.ToString() + "." + DateClose.Date.Year.ToString();
            }
        }

        public int Sum { get; set; }
        public string Garantee { get; set; }
    
        public virtual AcountType AcountType { get; set; }
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operation { get; set; }

        public string NameClient
        {
            get
            {
                return Client.FirstName.Trim() + " " + Client.Name.Trim();
            }   
        }
    }
}
