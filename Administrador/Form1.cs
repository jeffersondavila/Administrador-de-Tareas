using System;
using System.Windows.Forms;

namespace Process
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            list1.Items.Clear();
            list2.Items.Clear();

            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                list1.Items.Add(p.ProcessName);
                list2.Items.Add(p.Id + "\t\t" + p.WorkingSet64 + "\t\t" + p.VirtualMemorySize64 + "\t\t" + p.SessionId);
            }
            total.Text = "Total de procesos: " + list1.Items.Count.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
                {
                    string arr = list1.SelectedItem.ToString();

                    if(p.ProcessName == arr)
                    {
                        p.Kill();
                    }
                }
            }
            catch(Exception x)
            {
                MessageBox.Show("Debe seleccionar proceso para finalizar");
            }
            ActualizarLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
