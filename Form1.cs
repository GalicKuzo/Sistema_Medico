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
    }
}