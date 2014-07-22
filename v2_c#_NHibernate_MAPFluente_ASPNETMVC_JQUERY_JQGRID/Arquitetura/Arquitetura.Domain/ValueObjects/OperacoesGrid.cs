using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using System.Runtime.Serialization.Json;

namespace Arquitetura.Domain.ValueObjects
{
    public class OperacoesGrid<T>
    {
        #region Configura pesquisa
        /// <summary>
        /// Método que configura a pesquisa de acordo com os prametros passado
        /// </summary>
        /// <param name="param">parametros da grid</param>
        /// <param name="listaEntidades">Entidade utilizada na pesquisa</param>
        /// <returns></returns>
        public List<T> configuraPesquisa(GridParam param, List<T> listaEntidades)
        {
            List<T> lstEntidades = listaEntidades;

            List<T> lstOPEntidades = new List<T>();

            Filters filtroMultiseach = new Filters();

            var sb = new StringBuilder();

            if (param._search)
            {
                var operador = new Func<string, string, string>((op, valor) =>
                {
                    int saida;
                    bool isNum = Int32.TryParse(valor, out saida);
                    switch (op)
                    {
                        case "ne":
                            return isNum ? string.Format(" <>{0}", valor.ToUpper()) : string.Format(".ToUpper() <>\"{0}\"", valor.ToUpper());
                        case "cn":
                            return isNum ? string.Format(".ToUpper().Contains({0})", valor.ToUpper()) : string.Format(".ToUpper().Contains(\"{0}\")", valor.ToUpper());
                            
                       case "lt":
                            return isNum ? string.Format(" < {0}", valor) : string.Format(".ToUpper() <\"{0}\"", valor.ToUpper());

                        case "le":
                            return isNum ? string.Format(" <= {0}", valor) : string.Format(".ToUpper() <=\"{0}\"", valor.ToUpper());

                        case "gt":
                            return isNum ? string.Format(" > {0}", valor) : string.Format(".ToUpper() >\"{0}\"", valor.ToUpper());

                        case "ge":
                            return isNum ? string.Format(" >= {0}", valor) : string.Format(".ToUpper() >=\"{0}\"", valor.ToUpper());
                 
                        default:
                            return isNum ? string.Format(" = {0}", valor.ToUpper()) : string.Format(".ToUpper() = \"{0}\"", valor.ToUpper());
                    }
                });

                string operacao = "";

                if (param.filters != "")
                {
                    filtroMultiseach = Create(param.filters);
                    var tel = "";
                    foreach (Rule item in filtroMultiseach.rules)
                    {
                        if (item.field == "Telefone1")
                        {
                            tel = item.data.Replace("(", "").Replace(")", "").Replace("-", "").ToString();
                            item.data = tel;
                        }
                        //else if (item.field == "DataInscricao")
                        //{
                        //    item.data = item.data.Substring(6, 4) + "-" + item.data.Substring(3, 2) + "-" + item.data.Substring(0, 2);
                        //}
                        else if (item.field == "Data")
                        {
                            item.data = item.data.Substring(6, 4) + "-" + item.data.Substring(3, 2) + "-" + item.data.Substring(0, 2);
                        }
                        //else if (item.field == "dt_Inclusao")
                        //{
                        //    item.data = item.data.Substring(6, 4) + "-" + item.data.Substring(3, 2) + "-" + item.data.Substring(0, 2);
                        //}
                        //else if (item.field == "dt_alteracao")
                        //{
                        //    item.data = item.data.Substring(6, 4) + "-" + item.data.Substring(3, 2) + "-" + item.data.Substring(0, 2);
                        //}
                        if (item.field == "Telefone")
                        {
                            tel = item.data.Replace("(", "").Replace(")", "").Replace("-", "").ToString();
                            item.data = tel;
                        }
                        if (item.field == "DataInscricaoDia_")
                        {
                            item.field = "DataInscricaoDia";
                        }
                        //else 
                        //{
                        //    tel = item.data.Replace("(", "").Replace(")", "").Replace("-", "").ToString();
                        //    item.data = tel;
                        //}



                        sb.Append(item.field);
                        sb.Append(operador(item.op, item.data));
                        sb.Append(" " + filtroMultiseach.groupOp + " ");
                    }

                    int condMultisearch = 0;

                    if (filtroMultiseach.groupOp == "OR")
                    {
                        condMultisearch = 3;
                    }
                    else
                    {
                        condMultisearch = 5;
                    }

                    int totalCaracteres = sb.Length;

                    operacao = sb.Remove(totalCaracteres - condMultisearch, condMultisearch).ToString();
                }
                else
                {
                    sb.Append(param.searchField);
                    sb.Append(operador(param.searchOper, param.searchString));
                    operacao = sb.ToString();
                }

                lstOPEntidades = pesquisaOrdena(lstEntidades, operacao, param);

            }
            else
            {
                lstOPEntidades = pesquisaOrdena(lstEntidades, sb.ToString(), param);
            }

            return lstOPEntidades;
        }
        #endregion

        #region pesquisa e ordena
        /// <summary>
        /// Metodo que ordena e pequisa de acordo com parametros passado  
        /// </summary>
        /// <param name="entidade">lista da entidade trabalhada</param>
        /// <param name="operacao">dados para o where</param>
        /// <param name="param">parametros para montar o order by</param>
        /// <returns></returns>
        public List<T> pesquisaOrdena(List<T> entidade, string operacao, GridParam param)
        {
            try
            {
                List<T> retEntidade;

                string ordem = param.sidx + " " + param.sord;

                /// Verifica se tem pesquisa ou não se o where vai ser preciso 
                if (operacao != "")
                {

                    var query = entidade.AsQueryable()
                            .Where(operacao)
                                   .OrderBy(ordem);

                    retEntidade = query.ToList();

                }
                else
                {
                    var query = entidade.AsQueryable()
                            .OrderBy(ordem);

                    retEntidade = query.ToList();
                }

                return retEntidade;
            }
            catch (ParseException pEx)
            {
                throw pEx;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Filtros multisearch
        /// <summary>
        /// Serializa os filtros quando usa a pesquisa com varios criterios
        /// </summary>
        /// <param name="jsonData">string com os filtros </param>
        /// <returns></returns>
        public static Filters Create(string jsonData)
        {
            try
            {
                var serializer =
                  new DataContractJsonSerializer(typeof(Filters));
                System.IO.StringReader reader =
                  new System.IO.StringReader(jsonData);
                System.IO.MemoryStream ms =
                  new System.IO.MemoryStream(
                  Encoding.UTF8.GetBytes(jsonData));
                return serializer.ReadObject(ms) as Filters;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
