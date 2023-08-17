//In the name of Allah

using CityProto;
using Grpc.Core;
using GRPC.Extensions;
using GRPC.Models;

public class CityServiceImpl : CityService.CityServiceBase
{
    private readonly CityContext _context;

    public CityServiceImpl(CityContext context)
    {
        _context = context;
    }

    public override async Task<GetCityResponse> GetCity(GetCityRequest request, ServerCallContext context)
    {
        var city = await _context.Cities.FindAsync(request.Id);
        return new GetCityResponse { City = city.ToCityMessage() };
    }

    public override Task<GetCitiesResponse> GetCities(GetCitiesRequest request, ServerCallContext context)
    {
        var cities = _context.Cities.ToList();
        var response = new GetCitiesResponse { Cities = { cities.Select(city => city.ToCityMessage()) } };
        return Task.FromResult(response);
    }

    public override async Task<CreateCityResponse> CreateCity(CreateCityRequest request, ServerCallContext context)
    {
        var city = new City { Name = request.Name };
        _context.Cities.Add(city);
        await _context.SaveChangesAsync();
        return new CreateCityResponse { City = city.ToCityMessage() };
    }

    public override async Task<UpdateCityResponse> UpdateCity(UpdateCityRequest request, ServerCallContext context)
    {
        var city = await _context.Cities.FindAsync(request.Id);
        city.Name = request.Name;
        await _context.SaveChangesAsync();
        return new UpdateCityResponse { City = city.ToCityMessage() };
    }

    public override async Task<DeleteCityResponse> DeleteCity(DeleteCityRequest request, ServerCallContext context)
    {
        var city = await _context.Cities.FindAsync(request.Id);
        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();
        return new DeleteCityResponse();
    }
}