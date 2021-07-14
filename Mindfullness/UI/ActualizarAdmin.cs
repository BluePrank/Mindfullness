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
    public partial class ActualizarAdmin : Form
    {
        public ActualizarAdmin()
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

        private void button2_Click(object sender, EventArgs e)
        {
            using(MindfullnessEntities min = new MindfullnessEntities())
            {
                administradores adm = new administradores()
                {
                    id = Convert.ToInt32(id_txt.Text),
                    nombre = user_txt.Text,
                    apellido = ape_txt.Text,
                    correo = mail_txt.Text,
                    edad = Convert.ToInt32(edad_txt.Text),
                    cargo = cargo_txt.Text,
                    pass = pass_txt.Text
                };
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
