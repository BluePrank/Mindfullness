using Mindfullness.model;
using Mindfullness.UI;
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

namespace Mindfullness
{
    public partial class Form1 : Form
    {
        public Form1()
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (MindfullnessEntities min = new MindfullnessEntities())
            {
                var admin = from d in min.administradores
                            where d.nombre == user_txt.Text &&
                            d.pass == pass_txt.Text
                            select d;
                if(admin.Count() > 0)
                {
                    this.Hide();
                    GestionAdmin gesAd = new GestionAdmin();
                    gesAd.Show();
                }
                else
                {
                    MessageBox.Show("No hay campos en la b.d");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrarAdmin regAd = new RegistrarAdmin();
            regAd.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
