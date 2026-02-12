using SiaeIntegracao.src.Domain.Entities;

namespace SiaeIntegracao.src.Domain.Dtos
{
    public class PfDocumentosDto
    {
        public long Id { get; set; }

        public DateOnly? DataPc { get; set; }

        public int? CodDocumento { get; set; }

        public decimal? Valor { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}

