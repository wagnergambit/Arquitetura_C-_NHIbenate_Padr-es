using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arquitetura.Domain.Entity;
using FluentNHibernate.Mapping;

namespace Arquitetura.Repository.Mappings
{
    public class UsuarioMapFluent: ClassMap<Usuario>
    {
        public UsuarioMapFluent()
        {
            Id(l => l.Id);
            Map(l => l.cargo);
            Map(l => l.email);
            Map(l => l.nome);
            Map(l => l.empresa);
            Map(l => l.login);
            Map(l => l.senha);
            Map(l => l.nivel);
            Map(l => l.CPF);

        }
    }
}
