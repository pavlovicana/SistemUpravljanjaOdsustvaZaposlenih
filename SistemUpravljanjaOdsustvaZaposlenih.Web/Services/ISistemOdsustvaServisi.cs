using SistemUpravljanjaOdsustvaZaposlenih.Web.Models.TipOdsustva;

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Services
{

    //dodat je ISistemOdsustva interfejs jer klasa koja zavisi od druge klase, ne sme direktno da zavisi od implementacije, nego od ugovora, 
    //nivo apstrakcije
    public interface ISistemOdsustvaServisi
    {
        Task Create(TipOdsustvaCreateVM model);
        Task Edit(TipOdsustvaEditVM model);
        Task<T?> IspisiAsync<T>(int id) where T : class;
        Task<List<TipOdsustvaReadOnlyVM>> IspisiSveAsync();
        Task Obrisi(int id);
        Task<bool> ProveriDaLiTipOdsustvaPostoji(string ime);
        Task<bool> ProveriDaLiTipOdsustvaPostojiEdit(TipOdsustvaEditVM tipOdsustvaEditVM);
        bool TipOdsustvaExists(int id);
    }
}