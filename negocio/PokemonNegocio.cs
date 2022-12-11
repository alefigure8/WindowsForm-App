using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio;

namespace negocio
{
    public class PokemonNegocio
    {
        public List<dominio.Pokemon> Listar()
        {
            //Lista donde iremos guardando los datos
            List<dominio.Pokemon> lista = new List<dominio.Pokemon >();

            //Creamos la conexion
            AccesoDato datoSQL = new AccesoDato();

            try
            {
                datoSQL.setearQuery("select P.Id, P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion as Tipo, D.Descripcion as Debilidad from POKEMONS P, ELEMENTOS E, ELEMENTOS D where P.IdTipo = E.Id AND P.IdEvolucion = D.Id");
                datoSQL.ejecutarLectura();

                while (datoSQL.Reader.Read())
                {
                    dominio.Pokemon aux = new dominio.Pokemon();

                    if (!(datoSQL.Reader["Id"] is DBNull))
                        aux.Id = (int)datoSQL.Reader["Id"];

                    if (!(datoSQL.Reader["Numero"] is DBNull))
                        aux.Numero = (int)datoSQL.Reader["Numero"];
                    
                    if (!(datoSQL.Reader["Nombre"] is DBNull))
                        aux.Nombre = (string)datoSQL.Reader["Nombre"];
                    
                    if (!(datoSQL.Reader["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datoSQL.Reader["Descripcion"];
                    
                    if (!(datoSQL.Reader["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datoSQL.Reader["UrlImagen"];
                    
                    aux.Tipo = new Elemento();
                    aux.Tipo.Descripcion = (string)datoSQL.Reader["Tipo"];
                    
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)datoSQL.Reader["Debilidad"];
                    
                    lista.Add(aux);
                }


                return lista;

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
   
        public void Agregar(dominio.Pokemon pokemon)
        {
            AccesoDato datoSQL = new AccesoDato();

            try
            {
                datoSQL.setearQuery($"insert into POKEMONS (Numero, Nombre, Descripcion, UrlImagen, IdTipo, IdEvolucion, Activo) values({pokemon.Numero}, '{pokemon.Nombre}', '{pokemon.Descripcion}', '{pokemon.UrlImagen}', {pokemon.Tipo.Id}, {pokemon.Debilidad.Id},  1)");
                datoSQL.ejecutarEscritura();
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

        public int Modificar(dominio.Pokemon pokemon)
        {
            AccesoDato datoSQL = new AccesoDato();

            try
            {
                datoSQL.setearQuery($"update POKEMONS set Numero = {pokemon.Numero}, Nombre = '{pokemon.Nombre}', Descripcion = '{pokemon.Descripcion}', UrlImagen = '{pokemon.UrlImagen}', IdTipo = {pokemon.Tipo.Id}, IdEvolucion = {pokemon.Debilidad.Id} where Id = {pokemon.Id}");
                return datoSQL.ejecutarEscritura();
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
