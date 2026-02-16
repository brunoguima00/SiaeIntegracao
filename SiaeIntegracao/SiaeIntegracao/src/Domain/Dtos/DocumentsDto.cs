using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SiaeIntegracao.src.Domain.Entities;

namespace SiaeIntegracao.src.Domain.Dtos
{
    public class DocumentsDto
    {
        public long Id { get; set; }
        public string Projeto { get; set; } = string.Empty;
        public DateOnly? DataPc { get; set; }

        public int? CodDocumento { get; set; }

        public string NomeDocumento { get; set; } = string.Empty;

        public decimal? Valor { get; set; }

        public string? Status { get; set; }    

        public DateOnly? DataDeposito { get; set; }
        public string? CodAgente { get; set; } = string.Empty;
        public int? IdTipoDoc { get; set; } 

    }
}
