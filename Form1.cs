using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Level_Presentation
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color colorSelect = colorDialog1.Color;

                textBox1.ForeColor = colorSelect;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {

                Font fontSelect = fontDialog1.Font;

                textBox1.Font = fontSelect;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                TextWriter Texto = new StreamWriter(folderBrowserDialog1.SelectedPath + "/" + textBox2.Text + ".txt");

                Texto.WriteLine(textBox1.Text);

                Texto.Close();

                MessageBox.Show("El Archivo Fue Creado y/o Actualizado Correctamente", "Archivo Creado");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
        }

        bool Dibujar = false;

        bool Borrar = false;

        bool Presionado = false;


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ( (Presionado) && (Dibujar))
            {
                Graphics graphics = CreateGraphics();

                graphics.FillEllipse(new SolidBrush(button6.BackColor), e.X, e.Y,float.Parse(comboBox1.Text), float.Parse(comboBox1.Text));

                graphics.Dispose();
            }
            else
            {
                if ((Presionado) && (Borrar))
                {
                    Graphics graphics = CreateGraphics();

                    graphics.FillEllipse(new SolidBrush(Color.White), e.X, e.Y, float.Parse(comboBox1.Text), float.Parse(comboBox1.Text));

                    graphics.Dispose();
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Presionado = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Presionado = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
             Dibujar = true;

             Borrar = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
             Dibujar = false;

             Borrar = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 8; i <= 72; i += 8) {

                comboBox1.Items.Add(i);


            }

            comboBox1.SelectedIndex = 0;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                Color colorSelect = colorDialog2.Color;

                button6.BackColor = colorSelect;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

            button7.Visible = false;

            button4.Visible = false;

            button5.Visible = false;

            comboBox1.Visible = false;

            button6.Visible = false;

            Text = "Home";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;

            panel2.Visible = true;

            Text = "Home";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;

            panel1.Visible = true;

            Text = "Editor de Texto";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;

            button7.Visible = true;

            button4.Visible = true;

            button5.Visible = true;

            comboBox1.Visible = true;

            button6.Visible = true;

            Text = "Cuadro de Dibujo";
        }
    }
}

