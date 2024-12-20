namespace MVC.Models
{
    public class ComandaModel
    {
        public int? IdUtilizator { get; set; }
        public string? UtilizatorDetails { get; set; }
        public int? IdAbonament { get; set; }
        public string? AbonamentDetails { get; set; }
        public DateOnly? DataComenzii { get; set; }
        public decimal? Total { get; set; }
        public bool? Discount { get; set; }
    }
}
