using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Arquitetura.Domain.Entity;

namespace Arquitetura.Repository.Mappings
{
    public class ClienteMapFluent : ClassMap<Clientes>
    {
        public ClienteMapFluent()
        {
            Id(l => l.Id);
            Map(l => l.nome);
            Map(l => l.cep);
            Map(l => l.logradouro);
            Map(l => l.tipo);
            Map(l => l.cidade);
            Map(l => l.bairro);
            Map(l => l.estado);
        }
    }
}
