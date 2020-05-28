using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FilmBuzz.Common.Model
{
    public partial class TBL_MOVIES
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Please enter value")]
        public string Name { get; set; }
        [Range(1500,5000)]
        public Nullable<int> YearofRelease { get; set; }
        public string Plot { get; set; }
        public byte[] Poster { get; set; }
        [Required(ErrorMessage = "Please select value")]
        public Nullable<int> ActorId { get; set; }
        [Required(ErrorMessage = "Please select value")]
        public int ProducerId { get; set; }

        public virtual TBL_PRODUCERS TBL_PRODUCERS { get; set; }
        public virtual TBL_ACTORS TBL_ACTORS { get; set; }

        public int[] ActorsId { get; set; }

        public string ProducerName { get; set; }

        public List<TBL_ACTORS> Actors { get; set; }

        public int[] SelectedValues { get; set; }
        public SelectList AllValues { get; set; }
        //public string ProducerName { get; set; }
        //public string ProducerSex { get; set; }
        //public string ProducerBio { get; set; }
        //public string ProducerDOB { get; set; }
    }
   
       
  
}
