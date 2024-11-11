using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Models.DTOs
{
    public class EnderecoDTO
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }

        public override string ToString()
        {
            return $"Rua : {Rua} - Bairro : {Bairro} - Numero: {Numero}";
        }

    }
}
