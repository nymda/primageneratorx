using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace primageneratorx
{
    public partial class info : Form
    {
        public info()
        {
            InitializeComponent();
        }

        public int count = 0;

        private void info_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if(count == 3)
            {
                label1.Text = "Closed species are a sin to creative freedom.";
                count++;
            }
            else if(count == 4)
            {
                label1.Text = "Primagen generator thing. Software by knedit. Pixel art base by malice, i think.\nNo hard limit on maximum resolution but anything over 50x50 tends to crash.\n \"Show process\" shows each primagen as its made.Looks cool but slow.\n \"name\" uses random surnames from the \"namey.muffinlabs.com\" API.";
            }
            else
            {
                count++;
            }
        }
    }
}
