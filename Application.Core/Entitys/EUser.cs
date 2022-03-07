using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Core.Entitys
{
    public class EUser
    {
        public int IdUser { get; set; }
        public int IdRol { get; set; }
      
        public string Name { get; set; }
      
        public string LastName { get; set; }
       
        public string Email { get; set; }
        public DateTime? date_of_birth { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string Image { get; set; }


        public string NameRol { get; set; }
    }
}
