using AutoMapper;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DocumentModel, DocumentVM>().ReverseMap();
            CreateMap<AircraftModel, AircraftVM>().ReverseMap();
            CreateMap<FlightModel, FlightVM>()
                .ForMember(dest => dest.aircraft, opt => opt.MapFrom(src => src.aircraft))
                .ReverseMap();
            CreateMap<UserModel, UserVM>().ReverseMap();
            CreateMap<Document_Flight, DocumentFlightVM>()
                .ForMember(dest => dest.document, opt => opt.MapFrom(src => src.document))
                .ForMember(dest => dest.flight, opt => opt.MapFrom(src => src.flight))
                .ReverseMap();
            CreateMap<FlightDocServer, FlightDocServerVM>().ReverseMap();
            CreateMap<ServerDocument, ServerDocumentVM>()
                .ForMember(dest => dest.server, opt => opt.MapFrom(src => src.server))
                .ForMember(dest => dest.document, opt => opt.MapFrom(src => src.document))
                .ReverseMap();
            CreateMap<UserDocument, UserDocumentVM>()
                .ForMember(dest => dest.user, opt => opt.MapFrom(src => src.user))
                .ForMember(dest => dest.document, opt => opt.MapFrom(src => src.document))
                .ReverseMap();
        }
    }
}
