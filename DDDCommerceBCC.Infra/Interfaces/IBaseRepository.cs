using DDDCommerceBCC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDCommerceBCC.Infra.Interfaces
{
    public interface IBaseRepository<TModel> where TModel : BaseModel
    {
        IQueryable<TModel> Get(Expression<Func<TModel, bool>>? predicate = null);

        IQueryable<TModel> Get(int id);

        int Insert(TModel model);

        int Update(TModel model);

        int Delete(int id);
    }
}
