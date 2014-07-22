using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arquitetura.Domain.Interface
{
    public interface IRepository<T> where T : IEntity
    {
        /// <summary>
        /// Retorna Objeto através do ID informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T BuscaPorID(long id);

        /// <summary>
        ///  Retorna Todas os Objetos da Entidade
        /// </summary>
        /// <returns></returns>
        IList<T> ListaTodos();

        /// <summary>
        /// Salva a Objeto (insert ou update)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Salva(T entity);

        /// <summary>
        /// Exclui um Objeto
        /// </summary>
        /// <param name="entity"></param>
        void Exclui(T entity);
    }
}
