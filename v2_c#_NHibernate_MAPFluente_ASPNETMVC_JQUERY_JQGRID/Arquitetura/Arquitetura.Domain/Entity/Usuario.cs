using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arquitetura.Domain.Interface;

namespace Arquitetura.Domain.Entity
{
    public class Usuario : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string email { get; set; }
        public virtual string cargo { get; set; }
        public virtual string empresa { get; set; }
        public virtual string login { get; set; }
        public virtual string senha { get; set; }
        public virtual string nivel { get; set; }
        public virtual string CPF { get; set; }
    }
}
