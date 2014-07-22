using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arquitetura.Domain.Interface;

namespace Arquitetura.Domain.Entity
{
    public class  Clientes : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Cep { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Nome { get; set; }
    }
}
