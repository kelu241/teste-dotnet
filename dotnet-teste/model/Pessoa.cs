using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model;

[Table("pessoa")]
public class Pessoa
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("nome")]
    public String Nome { get; set; } = String.Empty;
}
