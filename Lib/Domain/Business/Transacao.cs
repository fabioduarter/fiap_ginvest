using GINVEST.Domain.Bussines;
using GINVEST.Domain.Enum;

namespace GINVEST.Domain.Business
{
    public class Transacao
    {
        public int Id { get; set; }
        public int PortifolioId { get; set; }
        public int AtivoId { get; set; }
        public TipoTransacaoType TipoTransacao { get; set; }
        public float Quantidade { get; set; }
        public float Preco {  get; set; }
        public DateTime DataTransacao { get; set; }


        public virtual Ativo Ativo { get; set; } = null!;
        public virtual Portifolio Portifolio { get; set; } = null!;
    }
}
