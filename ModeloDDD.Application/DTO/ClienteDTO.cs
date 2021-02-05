using System;

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