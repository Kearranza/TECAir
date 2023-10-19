using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;

namespace ApiTecAir.Mappers;

public class AppMapperProfile: Profile
{
    public AppMapperProfile()
    {
        CreateMap<AeropuertoDto, Aeropuerto>();
        CreateMap<AvionDto, Avion>();
        CreateMap<CalendarioVueloDto, CalendarioVuelo>();
        CreateMap<ClienteDto, Cliente>();
        CreateMap<ColorDto, Color>();
        CreateMap<EscalaDto, Escala>();
        CreateMap<EstudianteDto, Estudiante>();
        CreateMap<FacturaDto, Factura>();
        CreateMap<MaletaDto, Maleta>();
        CreateMap<MapaAsientoDto, MapaAsiento>();
        CreateMap<PaseAbordarDto, PaseAbordar>();
        CreateMap<PromocionesDto, Promociones>();
        CreateMap<TarjetaCreditoDto, TarjetaCredito>();
        CreateMap<UsuarioDto, Usuario>();
        CreateMap<VuelosDto, Vuelos>();

    }
}