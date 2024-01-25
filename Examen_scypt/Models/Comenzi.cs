using Microsoft.EntityFrameworkCore;

namespace Examen_scypt.Models
{
    public class Comenzi
    {
        public int ComenziId { get; set; }

        public List<ComenziProdus>? ComenziProdus { get; set; }

        public int UtilizatorId { get; set; }
        public Utilizator? Utilizator { get; set; }

    }
}
