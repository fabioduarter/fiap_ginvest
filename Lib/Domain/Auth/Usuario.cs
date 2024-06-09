using GINVEST.Domain.Bussines;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Auth
{
    public class Usuario
    {

        
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }

        public virtual ICollection<Portifolio> Portifolios { get; set; } = [];
    }
}
