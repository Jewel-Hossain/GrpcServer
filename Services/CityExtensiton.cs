//In the name of Allah

using CityProto;
using GRPC.Models;

namespace GRPC.Extensions;
public static class Extensions
{

    public static City ToCity(this CityMessage message)
    {
        return new City { Id = message.Id, Name = message.Name };
    }
    public static CityMessage ToCityMessage(this City city)
    {
        return new CityMessage
        {
            Id = city.Id,
            Name = city.Name
        };
    }

}//class