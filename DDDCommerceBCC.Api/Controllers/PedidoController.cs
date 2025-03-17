using DDDCommerceBCC.Domain.DTOs;
using DDDCommerceBCC.Domain.Models;
using DDDCommerceBCC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Logging;
using System.Net;
using DDDCommerceBCC.Infra.Interfaces;

namespace DDDCommerceBCC.Api.Controllers
{
    //public class PedidoController(IPedidoService service, ILogger<PedidoController> logger) : BaseServiceController<Pedido>(service, logger)
    public class PedidoController(IPedidoRepository repository, ILogger<PedidoController> logger) : BaseRepositoryController<Pedido>(repository, logger)
    {
    }
}
