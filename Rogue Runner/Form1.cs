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

            GameScreen gs = new GameScreen();
            form1.Controls.Add(gs);

            gs.Focus();
            gs.Location = new Point(this.Width / 2 - gs.Width / 2, this.Height / 2 - gs.Height / 2);
        }
    }
}
