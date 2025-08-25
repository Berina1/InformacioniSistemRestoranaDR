using AutoMapper;
using Restoran.DTO;
using Restoran.Models;

namespace Restoran.API.MappingProfiles 
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Narudzba, NarudzbaDTO>()
                .ForMember(dest => dest.DetaljiNarudzbeDTO, opt => opt.MapFrom(src => src.DetaljiNarudzbe))
                .ReverseMap();

            CreateMap<DetaljiNarudzbeDTO, DetaljiNarudzbe>()
                .ForMember(dest => dest.NazivArtikla, opt => opt.Ignore());  

            CreateMap<NarudzbaPostDTO, Narudzba>()
                .ForMember(dest => dest.DetaljiNarudzbe, opt => opt.MapFrom(src => src.DetaljiNarudzbe));

            CreateMap<DetaljiNarudzbePostDTO, DetaljiNarudzbe>();


            CreateMap<Meni, MeniDTO>().ReverseMap();
            CreateMap<Racun, RacunDTO>().ReverseMap();
            CreateMap<Rezervacija, RezervacijaDTO>().ReverseMap();

            CreateMap<DetaljiNarudzbe, DetaljiNarudzbeDTO>()
    .ReverseMap();
            //dodala Berina
            //Racun GetById
            CreateMap<Racun, RacunDTO>()
                .ForMember(dest => dest.RacunID, opt => opt.MapFrom(src => src.RacunID))
                .ForMember(dest => dest.NarudzbaID, opt => opt.MapFrom(src => src.NarudzbaID))
                .ForMember(dest => dest.NacinPlacanja, opt => opt.MapFrom(src => src.NacinPlacanja))
                .ForMember(dest => dest.VrijemePlacanja, opt => opt.MapFrom(src => src.VrijemePlacanja))
                .ForMember(dest => dest.Ukupno, opt => opt.MapFrom(src => src.Ukupno))
                .ReverseMap();

            CreateMap<Racun, RacunDTO>()
           .ForMember(dest => dest.StavkeRacuna, opt => opt.MapFrom(src => src.StavkeRacuna))
           .ForMember(dest => dest.StatusNarudzbe, opt => opt.MapFrom(src => src.Narudzba.Status))
           .ReverseMap();

            // Mapping for StavkaRacuna to StavkaRacunaDTO
            //  CreateMap<StavkaRacuna, StavkaRacunaDTO>().ReverseMap();

            CreateMap<StavkaRacuna, StavkaRacunaDTO>()
                .ForMember(dest => dest.NazivArtikla, opt => opt.MapFrom(src => src.NazivArtikla))
                .ForMember(dest => dest.Cijena, opt => opt.MapFrom(src => src.Cijena))
                .ForMember(dest => dest.Ukupno, opt => opt.MapFrom(src => src.Ukupno));

        }
    }
}