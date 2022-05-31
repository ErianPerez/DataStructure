using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryEstructuraDeDatos
{
    public partial class frm06ArbolBinario : Form
    {
        public frm06ArbolBinario()
        {
            InitializeComponent();
        }

        ArbolBinario ObjArbol = new ArbolBinario();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Nodo Persona = new Nodo();
            Persona.Codigo = Convert.ToInt32(txtCodigo.Text);
            Persona.Nombre = txtNombre.Text;
            Persona.Tramite = txtTramite.Text;

            ObjArbol.Agregar(Persona);

        }
    }
}
