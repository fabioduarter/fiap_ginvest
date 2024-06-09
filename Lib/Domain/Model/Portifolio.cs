using Domain.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace GINVEST.Domain.Bussines
{
    public class Portifolio
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }

        public required int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Ativo> Ativos { get; set; } = new List<Ativo>();

    }
}
