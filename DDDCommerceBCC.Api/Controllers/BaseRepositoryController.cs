using DDDCommerceBCC.Api.Extensions;
using DDDCommerceBCC.Domain.Models;
using DDDCommerceBCC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Logging;
using System.Net;
using DDDCommerceBCC.Infra.Interfaces;

namespace DDDCommerceBCC.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseRepositoryController<TModel>(IBaseRepository<TModel> repository, ILogger logger) : Controller where TModel : BaseModel
    {
        protected readonly IBaseRepository<TModel> _repository = repository;
        protected readonly ILogger _logger = logger;

        [HttpGet]
        public virtual IActionResult GetAll()
        {
            return TryExecute(() =>
            {
                return Ok(_repository.Get());
            });
        }

        [HttpGet("{id}")]
        public virtual IActionResult GetById(int id)
        {
            return TryExecute(() =>
            {
                return Ok(_repository.Get(id).FirstOrDefault());
            });
        }

        [HttpGet("odata")]
        public virtual IActionResult Get(ODataQueryOptions<TModel> queryOptions)
        {
            return TryExecute(() =>
            {
                var query = _repository.Get();
                var queryfilter = queryOptions.Filter?.ApplyTo(query, new ODataQuerySettings()) ?? query;

                return Ok(new
                {
                    _count = queryOptions.Count?.GetEntityCount(queryfilter),
                    value = queryOptions.ApplyTo(query)
                });
            });
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] TModel model)
        {
            return TryExecute(() =>
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _repository.Insert(model);
                return Ok(model);
            });
        }

        [HttpPut("{id}")]
        public virtual IActionResult Put(int id, TModel model)
        {
            return TryExecute(() =>
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                model.Id = id;
                _repository.Update(model);
                return Ok(model);
            });
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            return TryExecute(() =>
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _repository.Delete(id);
                return Ok(id);
            });
        }

        [NonAction]
        protected virtual IActionResult TryExecute(Func<IActionResult> execute)
        {
            try
            {
                return execute();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.InnerException);
                return BadRequest(ex);
            }
        }
    }
}
