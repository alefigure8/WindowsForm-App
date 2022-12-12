﻿using System;
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
using PokemonApp;
using static System.Net.Mime.MediaTypeNames;

namespace Pokemon
{
    public partial class frmAltaPokemon : Form
    {
        private dominio.Pokemon pokemon = null;
        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        public frmAltaPokemon(dominio.Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
        }
 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string numero = txtNumero.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            string urlImagen = txtUrlImagen.Text.Trim();
            Elemento tipo = (Elemento)cmbTipo.SelectedItem;
            Elemento debilidad = (Elemento)cmbDebilidad.SelectedItem;
            
            if (numero == "" || nombre == "" || descripcion == "" || urlImagen == "")
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                PokemonNegocio negocio = new PokemonNegocio();

                //cargamos los datos del formulario en el objeto
                pokemon.Numero = int.Parse(numero);
                pokemon.Nombre = nombre;
                pokemon.Descripcion = descripcion;
                pokemon.UrlImagen = urlImagen;
                pokemon.Tipo = tipo;
                pokemon.Debilidad = debilidad;

                if (pokemon.Id == 0)
                {
                    if (negocio.ExistePokemon(nombre))
                    {
                        MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                        DialogResult result = MessageBox.Show("El Pokemon que intenta Ingresar Ya existe. ¿Desea Activarlo?", "Pokemon ya esiste", btn);

                        if (result == DialogResult.OK)
                        {
                            try
                            {
                                int row = negocio.Activar(pokemon.Nombre);

                                if(row > 0)
                                {
                                    MessageBox.Show("Pokemon activado con exito");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Pokemon no pude ser activado");
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            negocio.Agregar(pokemon);
                            MessageBox.Show("Pokemon agregado con exito");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                else
                {
                    try
                    {
                        int rows = negocio.Modificar(pokemon);

                        if (rows == 1)
                        {
                            MessageBox.Show("Pokemon modificado con exito");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo modificar el pokemon");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        
        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio negocio = new ElementoNegocio();
            try
            {
                cmbTipo.DataSource = negocio.Listar();
                cmbTipo.ValueMember = "Id";
                cmbTipo.DisplayMember = "Descripcion";

                cmbDebilidad.DataSource = negocio.Listar();
                cmbDebilidad.ValueMember = "Id";
                cmbDebilidad.DisplayMember = "Descripcion";

                if (pokemon != null) //Cargamos datos del objeto del Constructor
                {
                    txtNumero.Text = pokemon.Numero.ToString();
                    txtNombre.Text = pokemon.Nombre;
                    txtDescripcion.Text = pokemon.Descripcion;
                    txtUrlImagen.Text = pokemon.UrlImagen;
                    cargarimagen(pokemon.UrlImagen);
                    cmbTipo.SelectedValue = pokemon.Tipo.Id;
                    cmbDebilidad.SelectedValue = pokemon.Debilidad.Id;
                    btnAceptar.Text = "Modificar";
                }
                else
                {
                    pokemon = new dominio.Pokemon(); //generamos uno nuevo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            string image = txtUrlImagen.Text;
            cargarimagen(image);
        }

        private void cargarimagen(string image)
        {
            try
            {
                pbCargarImagen.Load(image);
            }
            catch (Exception ex)
            {
                pbCargarImagen.Load("https://i0.wp.com/thealmanian.com/wp-content/uploads/2019/01/product_image_thumbnail_placeholder.png");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
