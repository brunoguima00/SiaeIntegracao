namespace SiaeIntegracao.src.Domain.Dtos
{
    public class CapaPcOnlineDto
    {
        public long IdLancamento { get; set; }

        public string? IdeEmpresa { get; set; }

        public string? IdePojeto { get; set; }

        public DateOnly? DataPc { get; set; }

        public string? IdeFilial { get; set; }

        public long? IdeClasse { get; set; }

        public long? IdeLancamento { get; set; }

        public string NomeLancamento { get; set; } = string.Empty;

        public short? OrdemLancamento { get; set; }

        public int? Quantidade { get; set; }

        public double? Valor { get; set; }

        public string? Modalidade { get; set; }

        public short? IdeDocumento { get; set; }

        public string? UsuarioCriou { get; set; }

        public DateTime? DataCriacao { get; set; }

        public string? Importado { get; set; }

        public string Status { get; set; } = "Digitando";
    }
}
