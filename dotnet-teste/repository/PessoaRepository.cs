namespace pessoaRepository;

using dBContext;
using model;

public class PessoaRepository
{
    private AppDbContext _context;

    public PessoaRepository(AppDbContext context)
    {
        this._context = context;
    }

    public IEnumerable<Pessoa> getPessoas()
    {
        return _context.pessoas;
    }

    public Pessoa? getPessoa(long id)
    {
        Pessoa? pessoaEncontrada = _context.pessoas.Find(id);

        return pessoaEncontrada;
    }

    public Pessoa adicionaPessoa(Pessoa pessoa)
    {
        _context.pessoas.Add(pessoa);
        _context.SaveChanges();

        return pessoa;
    }

    public void deletaPessoa(long id)
    {
        Pessoa? pessoaEncontrada = _context.pessoas.Find(id);

        if (pessoaEncontrada != null)
        {
            _context.pessoas.Remove(pessoaEncontrada);

            _context.SaveChanges();
        }
    }

    public Pessoa atulizaPessoa(long id, Pessoa pessoa)
    {
        Pessoa? pessoaEncontrada = _context.pessoas.Find(id);

        if (pessoaEncontrada == null)
        {
            throw new KeyNotFoundException("Pessoa não localizada");
        }
        pessoaEncontrada.Nome = pessoa.Nome;
        _context.pessoas.Update(pessoaEncontrada);
        _context.SaveChanges();
        return pessoaEncontrada;
    }
}
