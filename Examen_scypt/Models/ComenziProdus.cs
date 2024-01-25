namespace Examen_scypt.Models
{
    public class ComenziProdus
    {
        public int ProdusId { get; set; }

        public Produs? Produs { get; set; }

        public int? ComenziId { get; set; }

        public Comenzi? Comenzi { get; set; }

    }
}
