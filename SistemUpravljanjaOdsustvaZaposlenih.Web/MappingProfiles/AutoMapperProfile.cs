using AutoMapper;
using SistemUpravljanjaOdsustvaZaposlenih.Web.Data;
using SistemUpravljanjaOdsustvaZaposlenih.Web.Models.TipOdsustva;

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<TipOdsustva, TipOdsustvaReadOnlyVM>();
            CreateMap<TipOdsustvaCreateVM, TipOdsustva>();
            CreateMap<TipOdsustvaEditVM, TipOdsustva>().ReverseMap();

        
        }
    }
}
