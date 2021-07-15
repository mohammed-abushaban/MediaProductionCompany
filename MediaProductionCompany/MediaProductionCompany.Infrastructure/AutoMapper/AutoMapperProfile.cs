using AutoMapper;
using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.ViewModels;
using MediaProductionCompany.Data.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<UpdateProjectDto, ProjectDbEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));
            CreateMap<CategoryDbEntity, CategoryVM>();
            CreateMap<CountryDbEntity, CountryVM>().ForMember(x => x.Language, x => x.MapFrom(y => y.Language.Name));
            CreateMap<CountryDbEntity, CountryDetailsVM>().ForMember(x => x.Language, x => x.MapFrom(y => y.Language.Name));
            CreateMap<RegisterUserDto, UserDbEntity>();
            CreateMap<LanguageDbEntity, LanguageVM>();
            CreateMap<PortfolioDbEntity, PortfolioVM>();
            CreateMap<PortfolioTranslationDbEntity, PortfolioTranslationVM>().ForMember(x => x.Language, x => x.MapFrom(y => y.Language.Name))
                .ForMember(x => x.Category, x => x.MapFrom(y => y.Category.Name));

            CreateMap<CreateCategoryDto, CategoryDbEntity>();
            CreateMap<CreateCountryDto, CountryDbEntity>();
            CreateMap<CreateLanguageDto, LanguageDbEntity>();
            CreateMap<CreatePortfolioDto, PortfolioDbEntity>();
            CreateMap<CreatePortfolioTranslationDto, PortfolioTranslationDbEntity>().ForMember(x => x.Attachment, x => x.Ignore());

            CreateMap<UpdateCategoryDto, CategoryDbEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));
            CreateMap<UpdateCountryDto, CountryDbEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));
            CreateMap<UpdateLanguageDto, LanguageDbEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));
            CreateMap<UpdatePortfolioDto, PortfolioDbEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));
            CreateMap<UpdateUserDto, UserDbEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));
            CreateMap<UpdatePortfolioTranslationDto, PortfolioTranslationDbEntity>().ForMember(x => x.Attachment, x => x.Ignore()).ForAllMembers(opt => opt.Condition((src, dest, sourcrMember) => sourcrMember != null));



        }

    }
}
