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
            List<dominio.Pokemon> lista = new List<dominio.Pokemon>();

            //Creamos la conexion
            AccesoDato datoSQL = new AccesoDato();

            try
            {
                datoSQL.setearQuery("select P.Id, P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion as Tipo, P.IdTipo, D.Descripcion as Debilidad, P.IdEvolucion from POKEMONS P, ELEMENTOS E, ELEMENTOS D where P.IdTipo = E.Id AND P.IdEvolucion = D.Id AND P.Activo = 1");
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
                    aux.Tipo.Id = (int)datoSQL.Reader["IdTipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)datoSQL.Reader["Debilidad"];
                    aux.Debilidad.Id = (int)datoSQL.Reader["IdEvolucion"];

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

        public int Eliminar(int id)
        {
            AccesoDato datoSQL = new AccesoDato();
            
            try
            {
                datoSQL.setearQuery($"delete from POKEMONS where Id = {id}");
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

        public int EliminarLogica(int id)
        {
            AccesoDato datoSQL = new AccesoDato();

            try
            {
                datoSQL.setearQuery($"update POKEMONS set Activo = 0 where Id = {id}");
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

        public int Activar(string nombre)
        {
            AccesoDato datoSQL = new AccesoDato();

            try
            {
                datoSQL.setearQuery($"update POKEMONS set Activo = 1 where Nombre = '{nombre}'");
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

        public bool ExistePokemon(string nombre)
        {
            AccesoDato datoSQL = new AccesoDato();

            try
            {
                datoSQL.setearQuery($"select * from POKEMONS where Nombre = '{nombre}'");
                datoSQL.ejecutarLectura();

                if (datoSQL.Reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        public List<Pokemon> BusquedaAvanzada(string busqueda, string campo, string criterio)
        {
            List<dominio.Pokemon> lista = new List<dominio.Pokemon>();
            AccesoDato datoSQL = new AccesoDato();

            try
            {
                string filtro = "";

                switch (campo)
                {
                    case "Número":
                        if (criterio == "Mayor a")
                        {
                            filtro = $"Numero > {busqueda}";
                        }
                        else if(criterio == "Menor a")
                        {
                            filtro = $"Numero < {busqueda}";
                        }
                        else
                        {
                            filtro = $"Numero = {busqueda}";
                        }
                        break;
                    case "Nombre":
                        if (criterio == "Comienza con")
                        {
                            filtro = $"P.Nombre LIKE '{busqueda}%'";
                        }
                        else if (criterio == "Termina con")
                        {
                            filtro = $"P.Nombre LIKE '%{busqueda}'";
                        }
                        else
                        {
                            filtro = $"P.Nombre LIKE '%{busqueda}%'";
                        }
                        break;
                    case "Descripción":
                        if (criterio == "Comienza con")
                        {
                            filtro = $"P.Descripción LIKE '{busqueda}%'";
                        }
                        else if (criterio == "Termina con")
                        {
                            filtro = $"P.Descripción LIKE '%{busqueda}'";
                        }
                        else
                        {
                            filtro = $"P.Descripción LIKE '%{busqueda}%'";
                        }
                        break;
                    case "Tipo":
                        if (criterio == "Comienza con")
                        {
                            filtro = $"E.Descripcion LIKE '{busqueda}%'";
                        }
                        else if (criterio == "Termina con")
                        {
                            filtro = $"E.Descripcion LIKE '%{busqueda}'";
                        }
                        else
                        {
                            filtro = $"E.Descripcion LIKE '%{busqueda}%'";
                        }
                        break;
                    default:
                        return lista = null;
                }

                string consulta = $"select P.Id, P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion as Tipo, P.IdTipo, D.Descripcion as Debilidad, P.IdEvolucion from POKEMONS P, ELEMENTOS E, ELEMENTOS D where P.IdTipo = E.Id AND P.IdEvolucion = D.Id AND P.Activo = 1 AND {filtro}";
                datoSQL.setearQuery(consulta);
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
                    aux.Tipo.Id = (int)datoSQL.Reader["IdTipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)datoSQL.Reader["Debilidad"];
                    aux.Debilidad.Id = (int)datoSQL.Reader["IdEvolucion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
 }
