using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sPass = textPassword.Text;
            using (models.CATALOGO_DBEntities db = new models.CATALOGO_DBEntities())
            {
                var lst = from d in db.Users
                          where d.user == textUser.Text
                          && d.password == sPass
                          select d;
                if(lst.Count()>0)
                {
                    this.Hide();
                    Form frm=new Form();
                    frm.FormClosed += (s, args) => this.Close();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("No se pudo iniciar sesion");
                }
            }

        }
    }
}
