using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemUpravljanjaOdsustvaZaposlenih.Web.Data;
using SistemUpravljanjaOdsustvaZaposlenih.Web.Models.TipOdsustva;

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Services;
public class SistemOdsustvaServisi(ApplicationDbContext _context, IMapper _mapper) : ISistemOdsustvaServisi
{

    public async Task<List<TipOdsustvaReadOnlyVM>> IspisiSveAsync()
    {
        //var data = SELECT * FROM TipOsustva
        var data = await _context.TipOdsustva.ToListAsync();
        var viewData = _mapper.Map<List<TipOdsustvaReadOnlyVM>>(data);
        //convert the data model into view model
        /* var viewData = data.Select(q => new IndexVM
         {
             Id = q.Id,
             Ime = q.Ime,
             BrojDana = q.BrojDana
         });
         //return the view model to the view
         return View(viewData);
        */
        //Using AutoMapper
        return viewData;
    }
    public async Task<T?> IspisiAsync<T>(int id) where T : class
    {
        var data = await _context.TipOdsustva.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {
            return null;
        }
        var viewData = _mapper.Map<T>(data);
        return viewData;
    }
    public async Task Obrisi(int id)
    {
        var data = await _context.TipOdsustva.FirstOrDefaultAsync(x => x.Id == id);
        if (data != null)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

    }
    public async Task Edit(TipOdsustvaEditVM model)
    {
        var tipOdsustva = _mapper.Map<TipOdsustva>(model);
        _context.Update(tipOdsustva);
        await _context.SaveChangesAsync();

    }
    public async Task Create(TipOdsustvaCreateVM model)
    {
        var tipOdsustva = _mapper.Map<TipOdsustva>(model);
        _context.Add(tipOdsustva);
        await _context.SaveChangesAsync();
    }


    public bool TipOdsustvaExists(int id)
    {
        return _context.TipOdsustva.Any(e => e.Id == id);
    }

    public async Task<bool> ProveriDaLiTipOdsustvaPostoji(string ime)
    {
        var lowerCaseName = ime.ToLower();

        return await _context.TipOdsustva.AnyAsync(q => q.Ime.ToLower().Equals(lowerCaseName));
    }

    public async Task<bool> ProveriDaLiTipOdsustvaPostojiEdit(TipOdsustvaEditVM tipOdsustvaEditVM)
    {
        var lowerCaseName = tipOdsustvaEditVM.Ime.ToLower();

        return await _context.TipOdsustva.AnyAsync(q => q.Ime.ToLower().Equals(lowerCaseName) && q.Id != tipOdsustvaEditVM.Id);
    }
}

