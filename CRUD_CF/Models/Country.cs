using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_CF
{
    public class Country
    {
        [Key]
        public int countryId { get; set; }
        public string countryName { get; set; }

        //public virtual ICollection<Contact> Contacts { get; set; }


    }
}