using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Models
{
    public class Arquivos
    {
        [Key]
        public int idArquivo { get; set; }
        [NotMapped]
        public  IFormFile arquivo { get; set; }
        public string Arquivo { get; set; }
        public DateTime DH_Cadastro { get; set; }

        public int chamdosId { get; set; }
        public chamados Chamados { get; set; }



    }



}
