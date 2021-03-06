using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MgMarmore.Business.Models
{
    public class Cliente : Entity
    {             
        public string Nome { get; set; }                     
        public string Email { get; set; } 
        public string Telefone { get; set; }       
        public Endereco Endereco { get; set; }
    }
}