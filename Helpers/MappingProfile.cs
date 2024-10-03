using AutoMapper;
using MyPublicAPI.Models;

namespace MyPublicAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JournalDTO, Journal>()
                .ForMember(dest => dest.Debit, opt => opt.MapFrom(src => src.Items.Sum(item => item.Debit)))
                .ForMember(dest => dest.Credit, opt => opt.MapFrom(src => src.Items.Sum(item => item.Credit)));

            CreateMap<JournalDTO.JournalItem, Journal>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CompanyId, opt => opt.Ignore())
                .ForMember(dest => dest.Title, opt => opt.Ignore())
                .ForMember(dest => dest.VerificationNumber, opt => opt.Ignore())
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Account))
                .ForMember(dest => dest.Debit, opt => opt.MapFrom(src => src.Debit))
                .ForMember(dest => dest.Credit, opt => opt.MapFrom(src => src.Credit))
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account));
        }
    }
}