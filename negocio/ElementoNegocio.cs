using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ElementoNegocio
    {
        
        public List<Elemento> Listar()
        {
            List<Elemento> Elementos = new List<Elemento>();
            AccesoDato datoSQL = new AccesoDato();
            
            try
            {
                datoSQL.setearQuery("select * from ELEMENTOS");
                datoSQL.ejecutarLectura();

                while (datoSQL.Reader.Read())
                {
                    Elemento aux = new Elemento();
                    aux.Id = (int)datoSQL.Reader["Id"];
                    aux.Descripcion = (string)datoSQL.Reader["Descripcion"];
                    Elementos.Add(aux);
                }

                return Elementos;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                datoSQL.cerrarConexión();
            }
        }
    }
}
