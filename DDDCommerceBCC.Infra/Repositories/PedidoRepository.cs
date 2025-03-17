using DDDCommerceBCC.Domain.Models;
using DDDCommerceBCC.Infra.Data;
using DDDCommerceBCC.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDCommerceBCC.Infra.Repositories
{
    public class PedidoRepository(AppDbContext db) : BaseRepository<Pedido>(db), IPedidoRepository
    {
    }
}
