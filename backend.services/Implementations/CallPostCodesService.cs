#region

using System.Net.Http.Json;
using AutoMapper;
using backend.domain.Models;
using backend.Services.DTO;
using backend.services.Interfaces;
using backend.Services.Models;
using Microsoft.Extensions.Options;

#endregion

namespace backend.services.Implementations;

public class CallPostCodes : ICallPostCodes
{
    private readonly PostCodeService.Config _postCode;
    private readonly IMapper _mapper;
    private readonly ICalculateDistanceInKm _calculateDistanceInKm;

    public CallPostCodes(IOptions<PostCodeService.Config> configuration,
        IMapper mapper,
        ICalculateDistanceInKm calculateDistanceInKm)
    {
        _postCode = configuration.Value;
        _mapper = mapper;
        _calculateDistanceInKm = calculateDistanceInKm;
    }

    public async Task<PostalCodes> ExecuteAsync(string postalCode)
    {
        var client = new HttpClient();
        var response = await client.GetFromJsonAsync<PostCodeService.Response>(
            $"{_postCode.BaseUrl}{_postCode.Path}{postalCode}"
        );
        var distanceInKM = _calculateDistanceInKm.Execute(response.Result.Latitude, response.Result.Longitude);

        var result = new PostalCodesDTO(postalCode, response.Result.Latitude, response.Result.Longitude, distanceInKM);

        return _mapper.Map<PostalCodes>(result);
    }
}