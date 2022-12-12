using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using Pokemon;

namespace PokemonApp
{
    public partial class Form1 : Form
    {
        private List<dominio.Pokemon> lista;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            ComboBoxes();
        }

        public void cargar()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            lista = negocio.Listar();

            try
            {
                dgvPokemon.DataSource = lista;
                dgvPokemon.Columns["UrlImagen"].Visible = false;
                dgvPokemon.Columns["Id"].Visible = false;
                LoadImage(lista[0].UrlImagen);
                pbPokemon.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ComboBoxes()
        {
            List<String>Campos = new List<String>() { "Número", "Nombre", "Descripcion", "Tipo"};
            cmbCampo.DataSource = Campos;
        }

        private void dgvPokemon_SelectionChanged(object sender, EventArgs e)
        {

            dominio.Pokemon seleccionado = (dominio.Pokemon)dgvPokemon.CurrentRow.DataBoundItem;

            if (seleccionado != null)
                LoadImage(seleccionado.UrlImagen);
            else
                MessageBox.Show("Debe seleccionar uno para su modificación");
        }

        private void LoadImage(string image)
        {
            try
            {
                pbPokemon.Load(image);
            }
            catch (Exception)
            {

                pbPokemon.Load("https://i0.wp.com/thealmanian.com/wp-content/uploads/2019/01/product_image_thumbnail_placeholder.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaPokemon alta = new frmAltaPokemon();

            foreach (var views in Application.OpenForms)
            {
                if (views is frmAltaPokemon)
                {
                    return;
                }
            }

            alta.ShowDialog();
            cargar();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Guardamos los datos de la fila seleccionada
            dominio.Pokemon seleccionado = (dominio.Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
            
            //Creamos nueva ventana
            frmAltaPokemon modificar = new frmAltaPokemon(seleccionado);

            //Mostramos ventana
            modificar.ShowDialog();

            //Cargamos Grid en caso de actualizaciones
            cargar();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnBorrarLogica_Click(object sender, EventArgs e)
        {
            Eliminar(true);
        }

        private void Eliminar(bool logico = false)
        {
            dominio.Pokemon seleccionado = (dominio.Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
            PokemonNegocio pokemonNegocio = new PokemonNegocio();

            //Mensaje previo a la eliminación
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el Pokemon " + seleccionado.Nombre + "?", "Eliminar Pokemon", buttons, icon);

            if (result == DialogResult.OK)
            {
                try
                {
                    int rows = 0;
                    
                    if(logico)
                    {
                        rows = pokemonNegocio.EliminarLogica(seleccionado.Id);
                    }
                    else
                    {
                        rows = pokemonNegocio.Eliminar(seleccionado.Id);
                    }

                    if (rows > 0)
                    {
                        MessageBox.Show("Se ha eliminado el registro");
                        cargar();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el registro");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cargar();
                }

            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            PokemonNegocio pokemonNegocio = new PokemonNegocio();

            try
            {
                string busqueda = txtBusquedaAvanzada.Text;
                string campo = cmbCampo.SelectedItem.ToString();
                string criterio = cmbCriterio.SelectedItem.ToString();
                dgvPokemon.DataSource = pokemonNegocio.BusquedaAvanzada(busqueda, campo, criterio);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            busqueda();
        }

        private void busqueda()
        {
            string busqueda = txtBusqueda.Text;

            if (string.IsNullOrEmpty(busqueda))
            {
                dgvPokemon.DataSource = lista;
            }
            else
            {
                try
                {
                    var pokemonEncontrado = lista.FindAll(pokemon => pokemon.Nombre.ToLower().Contains(busqueda.ToLower()) || pokemon.Tipo.Descripcion.ToLower().Contains(busqueda.ToLower()));

                    if (pokemonEncontrado != null)
                    {
                        dgvPokemon.DataSource = pokemonEncontrado;
                    }
                    else
                    {
                        MessageBox.Show("El pókemon no fue encontrado");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pokemon no encontrado " + ex.Message);
                }
            }
        }

        private void cmbCampo_SelectedIndexchanged(object sender, EventArgs e)
        {

            List<String> Numerico = new List<String>() { "Menor a", "Mayor a", "Igual a" };
            List<String> Nombre = new List<String>() { "Comienza con", "Termina con", "Contiene" };

            if (cmbCampo.SelectedItem.ToString() == "Número")
            {
                cmbCriterio.DataSource = Numerico;
            }
            else
            {
                cmbCriterio.DataSource = Nombre;
            }

        }
    }
}
