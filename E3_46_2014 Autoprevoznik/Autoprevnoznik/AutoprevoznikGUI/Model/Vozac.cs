//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoprevoznikGUI.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vozac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vozac()
        {
            this.Autobus = new HashSet<Autobu>();
        }
    
        public int mbr_r { get; set; }
        public Nullable<int> br_doz_voz { get; set; }
        public string kategorije { get; set; }
    
        public virtual Radnik Radnik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autobu> Autobus { get; set; }
    }
}
