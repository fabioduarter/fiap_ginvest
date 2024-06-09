using GINVEST.Domain.Business;
using GINVEST.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace GINVEST.Domain.Bussines
{
    public class Ativo
    {
        public int Id { get; set; }
        public TipoAtivoType TipoAtivo { get; set; }
        public string Nome { get; set; } = null!;
        public string Codigo { get; set; } = null!;

        public virtual ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
        
    }
}
