using Mindfullness.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mindfullness.UI
{
    public partial class GestionAdmin : Form
    {
        public GestionAdmin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            using(MindfullnessEntities min = new MindfullnessEntities())
            {
                IQueryable<administradores> adm = from d in min.administradores
                                                    select d;
                List<administradores> lista = adm.ToList();
                tabla.DataSource = lista;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.tabla.SelectedRows)
            {
                int id = int.Parse(item.Cells[0].Value.ToString());

                using (MindfullnessEntities min = new MindfullnessEntities())
                {
                    var delete = from d in min.administradores
                                 where d.id == id
                                 select d;
                    foreach (var adm in delete)
                    {
                        min.administradores.Remove(adm);
                    }
                    min.SaveChanges();
                    MessageBox.Show("Has eliminado correctamente");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ActualizarAdmin actAd = new ActualizarAdmin();
            actAd.Show();
        }
    }
}
