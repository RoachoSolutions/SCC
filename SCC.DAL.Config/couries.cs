//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SCC.DAL.Config
{
    using System;
    using System.Collections.Generic;
    
    public partial class couries
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public couries()
        {
            this.couriesconfig = new HashSet<couriesconfig>();
        }
    
        public int idcouries { get; set; }
        public string nombre { get; set; }
        public int estado { get; set; }
        public System.DateTime fechareg { get; set; }
        public System.DateTime fechamod { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<couriesconfig> couriesconfig { get; set; }
    }
}
