using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rogue_Runner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form form1 = this.FindForm();
            form1.Controls.Remove(this);

            MenuScreen ms = new MenuScreen();
            form1.Controls.Add(ms);

            ms.Focus();
            ms.Location = new Point(this.Width / 2 - ms.Width / 2, this.Height / 2 - ms.Height / 2);
        }
    }
}
