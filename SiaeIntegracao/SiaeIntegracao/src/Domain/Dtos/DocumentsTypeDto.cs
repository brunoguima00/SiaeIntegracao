namespace SiaeIntegracao.src.Domain.Dtos
{
    public class DocumentsTypeDto
    {
        public int Id { get; set; }

        public int CodDocumento { get; set; }

        public string? NomeDocumento { get; set; }

        public string? TipoDocumento { get; set; }

        public string? Contabiliza { get; set; }

        public DateTime? DataCriacao { get; set; }

        public string? CodAgente { get; set; } = string.Empty;

        public string? Banco { get; set; } = string.Empty;

        public string? CodAgencia { get; set; } = string.Empty;

        public string? ContaCorrente { get; set; } = string.Empty;


    }
}
