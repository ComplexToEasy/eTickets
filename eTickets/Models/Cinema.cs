using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTickets.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public  int Id { get; set; }
   
        [Display(Name ="Cinema Logo")]
        [Required(ErrorMessage ="Cinema logo is required")]
        public  string Logo { get; set; }
  
        [Required(ErrorMessage = "Cinema Name is required")]

        [Display(Name = "Name")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Cinema Descripiton is required")]

        [Display(Name = "Description")]
        public string Description { get; set; }
        //Relationship
        public List<Movie> Movies { get; set; }
    }
}