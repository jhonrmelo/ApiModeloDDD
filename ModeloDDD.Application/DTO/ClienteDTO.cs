using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloDDD.Application.DTO
{
    public class ClienteDTO
    {
        public int? Id { get; set; }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
    }
}
