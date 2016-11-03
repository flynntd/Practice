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
    public partial class AddModifySong : Form
    {
        private Songs songs;

        public AddModifySong(Songs theSong)
        {
            InitializeComponent();

            songs = theSong;

            txtTitle.Text = songs.Title;
            txtArtist.Text = songs.Artist;
            mtbDate.Text = songs.Date;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            songs.Title = txtTitle.Text;
            songs.Artist = txtArtist.Text;
            songs.Date = mtbDate.Text;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
