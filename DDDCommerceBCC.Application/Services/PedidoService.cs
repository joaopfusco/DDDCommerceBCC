using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using DDDCommerceBCC.Application.Interfaces;
using DDDCommerceBCC.Domain.Models;
using DDDCommerceBCC.Domain.DTOs;
using DDDCommerceBCC.Infra.Data;

namespace DDDCommerceBCC.Application.Services
{
    public class PedidoService(AppDbContext db) : BaseService<Pedido>(db), IPedidoService
    {
    }
}
