namespace MVC.Models
{
    public class AbonamentModel
    {
        public int? IdUtilizator { get; set; }
        public string? UtilizatorDetails { get; set; }
        public int? IdHrana { get; set; }
        public string? HranaDetails { get; set; }
        public int? Frecventa { get; set; }
        public DateOnly? DataIncepere { get; set; }
        public DateOnly? DataSfarsit { get; set; }
    }
}
