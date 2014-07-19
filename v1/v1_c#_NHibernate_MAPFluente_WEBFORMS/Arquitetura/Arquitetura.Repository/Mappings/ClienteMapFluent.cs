using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Arquitetura.Domain.Entity;
using NHibernate;

namespace Arquitetura.Repository.Mappings
{
    public class ClienteMapFluent : ClassMap<Clientes>
    {
        public ClienteMapFluent()
        {
            Id(l => l.Id);
            Map(l => l.Cep);
            Map(l => l.Nome);
            Map(l => l.Cidade);
        }
    }
}
