using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryEstructuraDeDatos
{
    internal class ArbolBinario
    {
        private Nodo Inicio;
        private Nodo[] Vector = new Nodo[100];
        private Int32 i = 0;
        public Nodo Raiz
        {
            get { return Inicio; }
            set { Inicio = value; }
        }

        public void Agregar(Nodo Nuevo)
        {
            Nuevo.Izquierdo = null;
            Nuevo.Derecho = null;
            if (Raiz == null)
            {
                Raiz = Nuevo;
            }
            else
            {
                Nodo NodoPadre = Raiz;
                Nodo Aux = Raiz;
                while (Aux != null)
                {
                    NodoPadre = Aux;
                    if (Nuevo.Codigo < Aux.Codigo)
                    {
                        Aux = Aux.Izquierdo;
                    }
                    else
                    {
                        Aux = Aux.Derecho;
                    }
                }
                if (Nuevo.Codigo < NodoPadre.Codigo)
                {
                    NodoPadre.Izquierdo = Nuevo;
                }
                else
                {
                    NodoPadre.Derecho = Nuevo;
                }
            }
        }
        public void Recorrer(DataGridView Grilla, Int32 x)
        {
            switch (x)
            {
                case 1:
                    InOrden(Grilla, Raiz);
                    break;
                case 2:
                    PreOrden(Grilla, Raiz);
                    break;
                case 3:
                    PostOrden(Grilla, Raiz);
                    break;
            }
        }
        private void InOrden(DataGridView Grilla, Nodo Padre)
        {
            if (Padre.Izquierdo != null) InOrden(Grilla, Padre.Izquierdo);
            Grilla.Rows.Add(Padre.Codigo, Padre.Nombre, Padre.Tramite);
            if (Padre.Derecho != null) InOrden(Grilla, Padre.Derecho);
        }
        private void InOrdenDES(DataGridView Grilla, Nodo Padre)
        {
            if (Padre.Derecho != null) InOrdenDES(Grilla, Padre.Derecho);
            Grilla.Rows.Add(Padre.Codigo, Padre.Nombre, Padre.Tramite);
            if (Padre.Izquierdo != null) InOrdenDES(Grilla, Padre.Izquierdo);
        }

        private void PreOrden(DataGridView Grilla, Nodo Padre)
        {
            Grilla.Rows.Add(Padre.Codigo, Padre.Nombre, Padre.Tramite);
            if (Padre.Izquierdo != null) PreOrden(Grilla, Padre.Izquierdo);
            if (Padre.Derecho != null) PreOrden(Grilla, Padre.Derecho);
        }
        private void PostOrden(DataGridView Grilla, Nodo Padre)
        {
            if (Padre.Izquierdo != null) PostOrden(Grilla, Padre.Izquierdo);
            if (Padre.Derecho != null) PostOrden(Grilla, Padre.Derecho);


        }
        public void Recorrer(ComboBox Lista)
        {
            Lista.Items.Clear();
            InOrdenAsc(Lista, Raiz);
        }
        private void InOrdenAsc(ComboBox Lista, Nodo Raiz)
        {
            if(Raiz.Izquierdo != null) InOrdenAsc(Lista, Raiz.Izquierdo);
            Lista.Items.Add(Raiz.Codigo);
            if (Raiz.Derecho != null) InOrdenAsc(Lista, Raiz.Derecho);
        }
        private void Equilibrar()
        {
            i = 0;
            GrabarVectorInOrden(Raiz);
            Raiz = null;
            EquilibrarArbol(0, i - 1);
        }
        private void GrabarVectorInOrden(Nodo NodoPadre)
        {
            if (NodoPadre.Izquierdo != null)
            {
                GrabarVectorInOrden(NodoPadre.Izquierdo);
            }
            Vector[i] = NodoPadre;
            i = i + 1;
            if (NodoPadre.Derecho != null)
            {
                GrabarVectorInOrden(NodoPadre.Derecho);
            }
           
        }
        private void EquilibrarArbol(Int32 ini, Int32 fin)
        {
            Int32 m = (ini + fin) / 2;
            if (ini <= fin)
            {
                Agregar(Vector[m]);
                EquilibrarArbol(ini, m - 1);
                EquilibrarArbol(m + 1, fin);
            }
        }
        public void Eliminar(Int32 Codigo)
        {
            i = 0;
            GrabarVectorInOrden(Raiz, Codigo);
            Raiz = null;
            EquilibrarArbol(0, i - 1);
        }
        public void GrabarVectorInOrden(Nodo NodoPadre, Int32 Codigo)
        {
            if (NodoPadre.Izquierdo != null)
            {
                GrabarVectorInOrden(NodoPadre.Izquierdo, Codigo);
            }
            if (NodoPadre.Codigo != Codigo)
            {
                Vector[i] = NodoPadre;
                i = i + 1;
            }
            if (NodoPadre.Derecho != null)
            {
                GrabarVectorInOrden(NodoPadre.Derecho, Codigo);
            }
        }
    }
    
}
