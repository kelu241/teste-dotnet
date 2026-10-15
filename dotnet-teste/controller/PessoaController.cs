using Microsoft.AspNetCore.Mvc;
using model;
using pessoaRepository;

namespace controller;

[ApiController]
[Route("ola")]
public class PessoaController : ControllerBase
{
    private PessoaRepository _repository;

    public PessoaController(PessoaRepository repository)
    {
        this._repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pessoa>> getPessoas()
    {
        List<Pessoa> pessoas = _repository.getPessoas().ToList();
        return Ok(pessoas);
    }

    [HttpPost]
    public ActionResult<Pessoa> postPessoa(Pessoa pessoa)
    {
        _repository.adicionaPessoa(pessoa);
        return Ok(pessoa);
    }

    [HttpPut("/{id:long}")]
    public ActionResult<Pessoa> atualizaPessoa(long id, [FromBody] Pessoa pessoa)
    {
        Pessoa pessoaAtualizada = _repository.atulizaPessoa(id, pessoa);
        return Ok(pessoaAtualizada);
    }

    [HttpDelete("{id:long}")]
    public ActionResult deletePessoa(long id)
    {
        _repository.deletaPessoa(id);
        return Ok("Pessoa foi deletada com sucesso!!!");
    }
}
