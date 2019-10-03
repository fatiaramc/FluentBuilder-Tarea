using FluentBuilder.Builder;
using FluentBuilder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FluentBuilder
{
    public partial class Form1 : Form
    {
        List<Cuenta> _cuentas = new List<Cuenta>();
        List<Cuenta> _cuentasSeleccionadas = new List<Cuenta>();
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(TipoCuenta));
            comboBox1.SelectedItem = TipoCuenta.Basic;

            _cuentas.Add(new Cuenta());

            dataGridView1.DataSource = new BindingSource(_cuentas, null);
            dataGridView1.DataSource = typeof(List<Cuenta>);
            dataGridView1.DataSource = _cuentas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TipoCuenta tp = (TipoCuenta)comboBox1.SelectedItem;
            Console.WriteLine(tp);
            if (ValidarCampos())
            {
                try
                {
                    //Cuenta cuenta = CuentaFluentBuilder.Crear(TipoCuenta.Basic)
                    Cuenta cuenta = CuentaFluentBuilder.Crear(tp)
                        .NumeroCuenta(Int32.Parse(textBoxCuenta.Text))
                        .Propietario(textBoxPropietario.Text)
                        .SaldoInicial(Double.Parse(textBoxSaldo.Text))
                        .Tasa(Double.Parse(textBoxTasa.Text))
                        .GenerarCuenta();
                    _cuentas.Add(cuenta);
                    dataGridView1.DataSource = new BindingSource(_cuentas, null);
                    dataGridView1.DataSource = typeof(List<Cuenta>);
                    dataGridView1.DataSource = _cuentas;
                    LimpiarTextBox();
                    MessageBox.Show("Cuenta generada y agregada correctamente");
                }
                catch { }                
            }
        }

        private bool ValidarCampos()
        {
            if (textBoxCuenta.Text == "" || textBoxCuenta.Text.Any(c => !char.IsDigit(c))) {
                MessageBox.Show("Error en numero de cuenta, dato invalido");
                return false;
            }
            else if (textBoxPropietario.Text == "")
            {
                if (textBoxCuenta.Text.Any(c => char.IsDigit(c)))
                {
                    MessageBox.Show("Error en propietario, dato invalido");
                    return false;
                }
            }
            else if (textBoxSaldo.Text == "" || textBoxCuenta.Text.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Error en saldo, dato invalido");
                return false;
            }
            else if (textBoxTasa.Text == "" || textBoxCuenta.Text.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Error en tasa, dato invalido");
                return false;
            }
            return true;
        }
        private void LimpiarTextBox()
        {
            textBoxCuenta.Text = "";
            textBoxPropietario.Text = "";
            textBoxSaldo.Text = "";
            textBoxTasa.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Program.DeleteFriend(amigos[e.RowIndex].idamigo));
            if(_cuentasSeleccionadas.Count != 0)
            {
                foreach (Cuenta c in _cuentasSeleccionadas)
                {
                    _cuentas.Remove(c);
                }
                _cuentasSeleccionadas = new List<Cuenta>();
                dataGridView1.DataSource = new BindingSource(_cuentas, null);
                dataGridView1.DataSource = typeof(List<Cuenta>);
                dataGridView1.DataSource = _cuentas;
                MessageBox.Show("Cuentas eliminadas");
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos una cuenta");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _cuentasSeleccionadas.Add(_cuentas[e.RowIndex]);
        }
    }
}
