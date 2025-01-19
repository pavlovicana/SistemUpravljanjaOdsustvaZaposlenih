using System.ComponentModel.DataAnnotations;

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Models.TipOdsustva
{
    public class TipOdsustvaReadOnlyVM : BaseTipOdsustvaVM
    {
        public string Ime { get; set; } = string.Empty;
        [Display(Name = "Maximum allocation of days")]
        public int BrojDana { get; set; }
    }
}


