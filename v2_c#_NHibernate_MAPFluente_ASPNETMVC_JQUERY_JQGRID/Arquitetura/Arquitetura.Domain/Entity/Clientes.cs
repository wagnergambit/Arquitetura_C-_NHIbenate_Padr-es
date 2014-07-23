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
        public virtual string nome { get; set; }
        public virtual string cep { get; set; }
        public virtual string logradouro { get; set; }
        public virtual string tipo { get; set; }
        public virtual string cidade { get; set; }
        public virtual string bairro { get; set; }
        public virtual string estado { get; set; }
    }
}
