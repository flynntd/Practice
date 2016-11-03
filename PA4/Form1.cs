using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * CSC 220 PA 4
 * Tyler D. Flynn
 * 4/24/2014
 * List of 80's Songs
 */

namespace PA4
{
    public partial class frmSongs : Form
    {
        private List<Songs> songList;
        private FindFile findFile;

        private int currentIndex;

        public frmSongs()
        {
            InitializeComponent();

            startUpList();
        }

        private void startUpList()
        {
            string fileName = "Z:/CSC220/PA4/PA4/80'sSongs.txt";

            findFile = new FindFile(fileName);
            
            if (findFile.Status.Equals("ok"))
            {
                findFile.showListOfStrings();

                songList = new List<Songs>();

                List<string> listOfStrings = findFile.ListOfStrings;
                for (int i = 0; i < listOfStrings.Count; i += 3)
                {
                    string title = listOfStrings[i];
                    string artist = listOfStrings[i + 1];
                    string date = listOfStrings[i + 2];

                    songList.Add(new Songs(title, artist, date));
                }

                currentIndex = 0;

                txtOutput.Text = songList[currentIndex].ToString();
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = 0;
            }

            if (currentIndex >= 0 && currentIndex < songList.Count)
            {
                txtOutput.Text = songList[currentIndex].ToString();
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            currentIndex++;
            if (currentIndex >= songList.Count - 1)
            {
                currentIndex = songList.Count - 1;
            }

            if (currentIndex >= 0 && currentIndex < songList.Count)
            {
                txtOutput.Text = songList[currentIndex].ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Songs temp = new Songs();
            AddModifySong dialogTest = new AddModifySong(temp);
            DialogResult result = dialogTest.ShowDialog();

            if (result.ToString().Equals("OK"))
            {
                songList.Add(temp);
                currentIndex = songList.Count-1;
                txtOutput.Text = songList[currentIndex].ToString();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0 && currentIndex < songList.Count)
            {
                AddModifySong dialogTest = new AddModifySong(songList[currentIndex]);
                DialogResult result = dialogTest.ShowDialog();

                if (result.ToString().Equals("OK"))
                {
                    txtOutput.Text = songList[currentIndex].ToString();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0 && currentIndex < songList.Count)
            {
                RemoveSong dialogTest = new RemoveSong(songList[currentIndex]);
                DialogResult result = dialogTest.ShowDialog();

                if (result.ToString().Equals("OK"))
                {
                    txtOutput.Text = "";

                    songList.Remove(songList[currentIndex]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> listOfStrings = new List<string>();

            for (int i = 0; i < songList.Count; i++)
            {
                Songs temp = songList[i];

                string title = temp.Title;
                string artist = temp.Artist;
                string date = temp.Date;

                listOfStrings.Add(title);
                listOfStrings.Add(artist);
                listOfStrings.Add(date);
            }

            findFile.ListOfStrings = listOfStrings;
            findFile.saveFile();
        }
    }
}
