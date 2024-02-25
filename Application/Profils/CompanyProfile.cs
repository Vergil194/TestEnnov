using AutoMapper;
using Domain.Entities;
using System.Globalization;

namespace Application.Profils
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, Company>();

            CreateMap<CompanyInfoDto, Company>()
                .ForMember(dest => dest.SogcDate, 
                           opt => opt.MapFrom(src => DateTime.ParseExact(src.SogcDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.HeadOffice, 
                           opt => opt.MapFrom(src => src.HeadOffices != null && src.HeadOffices.Any()? src.HeadOffices.First().Name:"Not mentioned"))
                .ForMember(dest => dest.Legalform, 
                           opt => opt.MapFrom(src => $"{src.LegalForm.Uid}-{src.LegalForm.Name.En} ({src.LegalForm.ShortName.En})"))
                .ForMember(dest => dest.Adresses, opt => opt.MapFrom(src => 
                new CompanyAdresses
                {
                    CompanyUid = src.Uid,
                    Adress = $"{src.Address.Street}, {src.Address.City}"
                }));
        }
    }
}
