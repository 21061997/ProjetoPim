﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Models
{
    public class chamados
    {
        [Key]
        public int idChamado { get; set; }
        public DateTime DH_Abertura { get; set; }
        public DateTime DH_Fechamento { get; set; }
        public String descricao { get; set; }
        [NotMapped]
        public string arquivo { get; set; }
        [NotMapped]
        public string  CaminhoArquivo { get ; set ; }
        [NotMapped]
        public IFormFile Arquivo { get; set; }
        public String Log { get; set; }
        public String comentario { get; set; }


        /*Fazendo a associação de categorias*/

        public int categoriasId { get; set; }
        public categorias categorias { get; set; }

        /*Fazendo a associação de comentarios*/

        public ICollection<comentarios> comentarios { get; set; }


        /*Fazendo a associação de grupos*/

        public int gruposId { get; set; }
        public grupos grupos { get; set; }


        /*Fazendo a associação de prioridades*/

        public int prioridadesId { get; set; }
        public prioridades prioridades { get; set; }


        /*Fazendo a associação de arquivos*/

        public ICollection<Arquivos> arquivos { get; set; }

        /*Fazendo a associação de logs*/

        public ICollection<logs> logs { get; set; } // Foi alteração no chamdosController, foi feito a referencia de log










    }
}
