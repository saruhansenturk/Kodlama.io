﻿using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.HardDeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.SoftDeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
        CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, SoftDeleteProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, SoftDeleteProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, HardDeleteProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, HardDeleteProgrammingLanguageCommand>().ReverseMap();
    }
}