using System;
using System.Threading.Tasks;
using Hermes.Identity.Command;
using Hermes.Identity.Dto;
using Hermes.Identity.Query;
using Hermes.Identity.Query.User;
using Hermes.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Identity.Controllers
{
    public class IdentityController : ControllerBase
    {
        private readonly IUserService userService;
        public IdentityController(IUserService userService, ICommandDispacher commandDispacher, IQueryDispacher queryDispacher) : base(commandDispacher, queryDispacher)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Json(await QueryAsync<BrowseUser, UserDto>(new BrowseUser(id)));
        }
    }
}