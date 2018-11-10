using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Models
{
    public class logs
    {
        [Key]
        public int idLog { get; set; }
        public String Log { get; set; }




        public int chamdosId { get; set; }
        public chamados Chamados { get; set; }



    }
}
