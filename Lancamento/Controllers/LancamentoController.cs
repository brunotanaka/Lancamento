using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lancamento.Application.Models;
using Lancamento.Application.Validators;
using Lancamento.Domain.Interfaces.AppServices;
using Lancamento.Util;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lancamento.Controllers
{
    [Route("api/lancamento]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoAppService _lancamentoAppService;

        public LancamentoController(ILancamentoAppService lancamentoAppService)
        {
            _lancamentoAppService = lancamentoAppService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post([FromBody]LancamentoViewModel model)
        {
            try
            {
                var validator = new LancamentoValidator();
                var result = await validator.ValidateAsync(model);

                if (!result.IsValid)
                    return BadRequest(new ApiBadRequestResponse(result.Errors));

                var lancamento = await _lancamentoAppService.Add(model.ToEntity());

                return Created("Lancamento efetuado com sucesso.", new ApiCreatedResponse(lancamento));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
