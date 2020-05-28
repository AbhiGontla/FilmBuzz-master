using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmBuzz.Common.Model
{

    public partial class TBL_ACTORS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ACTORS()
        {
            this.TBL_MOVIES = new HashSet<TBL_MOVIES>();
        }

        public int ActorId { get; set; }
        [Required(ErrorMessage = "Please insert a valid user name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please insert a valid Gender")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "Please select valid date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DOB { get; set; }

      
        public string Bio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MOVIES> TBL_MOVIES { get; set; }

        public List<TBL_MOVIES> _movieslist { get; set; }
    }

}
