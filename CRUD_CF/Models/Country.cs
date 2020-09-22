using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_CF
{
    public class Country
    {
        [Key]
        public int countryId { get; set; }

        [Required(ErrorMessage = "Country Name is required")]
        [DisplayName("Country Name")]
        public string countryName { get; set; }

        [DisplayName("Set Default")]
        public bool setDefault { get; set; }
        
    }
}