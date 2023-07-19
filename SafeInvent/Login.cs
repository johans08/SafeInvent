using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafeInvent
{
    public partial class Login : Form
    {
        public Login()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEnter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            foreach (Control ctrl in panelContainerTextBox.Controls)
            {
                if (ctrl is PictureBox && ctrl.Name == "pictureBox" + txt.Tag.ToString())
                {
                    ctrl.BackColor = Color.FromArgb(79, 129, 189);
                }
                if (ctrl is Label && ctrl.Name == "label" + txt.Tag.ToString())
                {
                    ctrl.BackColor = Color.FromArgb(79, 129, 189);
                }
            }

        }

        private void txtLeave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            foreach (Control ctrl in panelContainerTextBox.Controls)
            {
                if (ctrl is PictureBox && ctrl.Name == "pictureBox" + txt.Tag.ToString())
                {
                    ctrl.BackColor = Color.FromArgb(255, 128, 0);
                }
                if (ctrl is Label && ctrl.Name == "label" + txt.Tag.ToString())
                {
                    ctrl.BackColor = Color.FromArgb(255, 128, 0);
                }
            }
           
        }

        private int posY = 0;
        private int posX = 0;
        private void Titulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void pictureBoxCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pictureBoxAgrandar.Visible = true;
            pictureBoxMin.Visible = false;
        }

        private void pictureBoxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxAgrandar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBoxAgrandar.Visible = false;
            pictureBoxMin.Visible = true;
        }
    }
}
