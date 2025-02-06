using Microsoft.AspNetCore.Identity;

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }    
        public DateOnly DatumRodjenja { get; set; }
    }
}
