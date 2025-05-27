using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using repom.application.api.Base;
using repom.application.api.Controllers.Base;
using repom.application.api.Models;
using repom.application.Interface;
using repom.domain.core.Entity;
using Swashbuckle.AspNetCore.Annotations;

namespace repom.application.api.Controllers.Person;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class PersonController : ApiBaseController
{
    private IPersonAppService AppService => GetService<IPersonAppService>();
    private IMapper Mapper => GetService<IMapper>();

    [HttpPost]
    [SwaggerOperation(Summary = "Cria pessoa",
        Description = "Cria uma pessoa com endereco, telefone e cargo no sistema")]
    [SwaggerResponse(200, "Pessoa criada com sucesso.", typeof(SuccessResponse<BaseModelView<PersonViewModel>>))]
    [SwaggerResponse(400, "Não foi possível criar usuarios do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Post([FromBody] PersonViewModel model) => await AutoResult(async () =>
        new BaseModelView<bool>
        {
            Data = await AppService.CreateAsync(Mapper.Map<PersonEntity>(model)),
            Message = " Pessoa criada com sucesso",
            Success = true
        });

    [HttpGet]
    [SwaggerOperation(Summary = "Buscar todas as pessoa",
        Description = "Buscar todas as pessoas com endereco, telefone e cargo no sistema")]
    [SwaggerResponse(200, "Pessoa criada com sucesso.", typeof(SuccessResponse<BaseModelView<List<PersonViewModel>>>))]
    [SwaggerResponse(400, "Não foi possível criar usuarios do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Get() => await AutoResult(async () =>
        new BaseModelView<List<PersonViewModel>>
        {
            Data = Mapper.Map<List<PersonViewModel>>(await AppService.GetAll()),
            Message = "Lista de pessoas cadastradas.",
            Success = true
        });
}