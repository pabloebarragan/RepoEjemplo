using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.cmbOperador.Text = string.Empty;
            this.lblResultado.Text = string.Empty;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);
            double resultado = Calculadora.Operar(numeroUno, numeroDos, operador);
            return resultado;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            this.lblResultado.Text = resultado.ToString();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero binario = new Numero();
            string anterior = this.lblResultado.Text;
            if (anterior != "Valor invalido" && anterior != string.Empty && lblResultado.Text[0] != '0')
                this.lblResultado.Text = binario.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero binario = new Numero();
            string anterior = this.lblResultado.Text;
            if (anterior != "Valor invalido" && anterior != string.Empty)
            {
                this.lblResultado.Text = binario.BinarioDecimal(this.lblResultado.Text);
            }
        }
    }
}
