#region

using AutoMapper;
using backend.domain.Models;
using backend.Services.DTO;

#endregion

namespace backend;

public class Mappers : Profile
{
    public Mappers()
    {
        Config();
    }

    public void Config()
    {
        CreateMap<PostalCodesDTO, PostalCodes>();
    }
}