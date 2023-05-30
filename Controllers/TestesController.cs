using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace injecao_dependencia_atributos.Controllers;

[ApiController]
[Route("[controller]")]
public class TestesController : ControllerBase
{
    public TestesController()
    {
    }

    [HttpGet("com-atributos")]
    public IActionResult GetComAtributos([FromServices] ITeste teste)
    {
        return Ok(teste.NomeDoTeste());
    }

    [HttpGet("sem-atributos")]
    public IActionResult GetSemAtributos(ITeste teste)
    {
        return Ok(teste.NomeDoTeste());
    }

    [HttpPost("body")]
    public IActionResult GetBody(ParametroBody body)
    {
        return Ok(body);
    }

    [HttpPost("rota/{id_produto}")]
    public IActionResult GetBody(int id_produto, ParametroBody body)
    {
        return Ok(id_produto);
    }

    [HttpPost("query/{id_produto}")]
    public IActionResult GetBody(int id_produto, ParametroBody body, string query01, int query02)
    {
        return Ok(new { id_produto, body, query01, query02 });
    }
}

public class ParametroBody
{
    public string Nome { get; set; }
}

public interface ITeste
{
    string NomeDoTeste();
}

public class Teste : ITeste
{
    public string NomeDoTeste() => "Retornando string de teste";
}