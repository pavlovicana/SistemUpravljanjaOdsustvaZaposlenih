using Microsoft.CodeAnalysis.Classification;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Data
{
    //prvi entitet, reprezentacija tabele u bazi
    public class TipOdsustva
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Ime { get; set; }
        public int BrojDana { get; set; }






    }
}
