using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesFilmes.Modelo
{
    //                          Aula 51 - Criando Contexto 
    //                          Aula 53 - Entendo os itens gerados 
    //                          Aula 55 - Adicionando campo novo
    //                          Aula 57 - Data Anottations e Correções de Bugs 

    public class Filme
    {
        //(1-51) Criando um identificar que vai ficar na memória
        public int ID { get; set; }

        // (4-57) Definindo a quantidade de caracteres nos campos
        [StringLength(100, MinimumLength = 3)]
        [MaxLength(100, ErrorMessage = "errou")]

        public string Titulo { get; set; } = string.Empty;

        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }
        //(2-53)
        
        // (5-57) Quero aceitar somente texto
        [Required(ErrorMessage = "Digite o genero do filme")]
        // (6-57) Definindo a obrigatoriedade de preencher o campo genero
        [StringLength(30, MinimumLength = 3)]

        public string Genero { get; set; } = string.Empty;

        public decimal Preco { get; set; }
        // (7-57) Definindo o preço
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]

        // (8-57) Definindo o range
        [Range(0,5)]

        // (3-55) Quero inserir Pontos no filmes ou seja a classificação deles
        public int Pontos { get; set; } = 0;




    }
}
