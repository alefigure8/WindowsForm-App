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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            btnModificar.Visible = false;
        }

        public void cargar()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            List<dominio.Pokemon> lista = negocio.Listar();

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

        private void dgvPokemon_SelectionChanged(object sender, EventArgs e)
        {
            
            dominio.Pokemon seleccionado = (dominio.Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
            LoadImage(seleccionado.UrlImagen);
            
            if(seleccionado != null)
            {
            btnModificar.Visible = true;
            }

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
            dominio.Pokemon seleccionado = (dominio.Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
            frmAltaPokemon modificar = new frmAltaPokemon(seleccionado);
            modificar.ShowDialog();
            cargar();
        }
    }
}
