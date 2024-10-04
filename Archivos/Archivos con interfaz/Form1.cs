using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archivos_con_interfaz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            FileStream mArchivoEscritor = new FileStream("datos.dat", FileMode.OpenOrCreate, FileAccess.Write);
            using (BinaryWriter Escritor = new BinaryWriter(mArchivoEscritor)) { 

                string nombre = tbName.Text;
            int edad = int.Parse(tbAge.Text);
            string nota = tbNote.Text;
            string genero = tbGenero.Text;

            using (StreamWriter personas = new StreamWriter("personas.txt", true))
            {
                personas.WriteLine($"{nombre},{edad},{nota},{genero}");
                
            }

            MessageBox.Show("Datos agregados correctamente.");}

        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            List<Persona> personas = new List<Persona>();

            using (StreamReader sr = new StreamReader("personas.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    personas.Add(new Persona
                    {
                        Nombre = parts[0],
                        Edad = int.Parse(parts[1]),
                        Nota = parts[2],
                        Genero = parts[3]
                    });
                }
            }

            dgvPersona.DataSource = personas;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Clear();
            tbAge.Clear();
            tbNote.Clear();
            tbGenero.Clear();
            dgvPersona.DataSource = null;

        }
    }
    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Nota { get; set; }
        public string Genero { get; set; }
    }
}
