using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PA4
{
    public partial class RemoveSong : Form
    {
        private Songs songs;

        public RemoveSong(Songs theSong)
        {
            InitializeComponent();

            songs = theSong;

            txtSong.Text = songs.ToString();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
