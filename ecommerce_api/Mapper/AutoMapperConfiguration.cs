using AutoMapper;
using eCommerce.Models.DTO;
using eCommerce.Models.Table;

public class AutoMapperConfiguration
{
    public static Mapper Initialize()
    {
        var configuration = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Cliente, ClienteDTO>();
                cfg.CreateMap<ClienteDTO, Cliente>();
                cfg.CreateMap<Pessoa, PessoaDTO>();
                cfg.CreateMap<PessoaDTO, Pessoa>();
                cfg.CreateMap<PessoaFisica, PessoaFisicaDTO>();
                cfg.CreateMap<PessoaFisicaDTO, PessoaFisica>();
                cfg.CreateMap<PessoaJuridica, PessoaJuridicaDTO>();
                cfg.CreateMap<PessoaJuridicaDTO, PessoaJuridica>();
            }
        );

        var mapper = new Mapper(configuration);

        return mapper;

    }

}