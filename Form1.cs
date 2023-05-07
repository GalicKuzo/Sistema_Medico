using System.Windows.Forms;

namespace Sistema_Medico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int n = dgvLista.Rows.Add();
            string codigo = Convert.ToString(txtCodigo.Text);
            string nombre = Convert.ToString(txtNombre.Text);
            string cantidad = Convert.ToString(txtCantidad.Text);
            string precio = Convert.ToString(txtPrecio.Text);
            double montoInvertido = Int32.Parse(cantidad) * Double.Parse(precio);
            dgvLista.Rows[n].Cells[0].Value = codigo;
            dgvLista.Rows[n].Cells[1].Value = nombre;
            dgvLista.Rows[n].Cells[2].Value = cantidad;
            dgvLista.Rows[n].Cells[3].Value = precio;
            dgvLista.Rows[n].Cells[4].Value = montoInvertido;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string codigoIngresado = Convert.ToString(txtCodigoElm.Text);
            for(int cantidadFilas = 0; cantidadFilas < dgvLista.RowCount; cantidadFilas++)
            {
                string codigoRecibido = Convert.ToString(dgvLista.Rows[cantidadFilas].Cells[0].Value);
                if(codigoIngresado == codigoRecibido)
                {
                    dgvLista.Rows.RemoveAt(cantidadFilas);
                    MessageBox.Show("¡Medicamento Removido!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else if (cantidadFilas + 1 == dgvLista.RowCount)
                {
                    MessageBox.Show("¡El codigo que ha ingresado no existe!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvLista.ClearSelection();
            string nombreIngresado = Convert.ToString(txtNombreBusc.Text);
            for (int cantidadFilas = 0; cantidadFilas < dgvLista.RowCount; cantidadFilas++)
            {
                string nombreRecibido = Convert.ToString(dgvLista.Rows[cantidadFilas].Cells[1].Value);
                if (nombreIngresado.ToUpper() == nombreRecibido.ToUpper())
                {
                    dgvLista.Rows[cantidadFilas].Selected = true;
                    MessageBox.Show("¡Medicamento Encontrado!","",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                } else if (cantidadFilas + 1 == dgvLista.RowCount )
                {
                    MessageBox.Show("¡El medicamento que ha ingresado no existe!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRowWrapper> rows = new List<DataGridViewRowWrapper>();
            foreach (DataGridViewRow row in dgvLista.Rows)
            {
                rows.Add(new DataGridViewRowWrapper(row));
            }
            int n = rows.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (rows[j].CompareTo(rows[j + 1]) > 0)
                    {
                        DataGridViewRowWrapper temp = rows[j];
                        rows[j] = rows[j + 1];
                        rows[j + 1] = temp;
                    }
                }
            }
            dgvLista.Rows.Clear();
            foreach (DataGridViewRowWrapper rowWrapper in rows)
            {
                dgvLista.Rows.Add(rowWrapper.Row);
            }

        }
        class DataGridViewRowWrapper : IComparable<DataGridViewRowWrapper>
        {
            private DataGridViewRow _row;

            public DataGridViewRowWrapper(DataGridViewRow row)
            {
                _row = row;
            }

            public int CompareTo(DataGridViewRowWrapper other)
            {
                return string.Compare(_row.Cells[1].Value.ToString(), other._row.Cells[1].Value.ToString());
            }

            public DataGridViewRow Row
            {
                get { return _row; }
            }

        }
    }
}