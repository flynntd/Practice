using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PA4
{
    class FindFile
    {
        private string fileName;
        private string status;
        private List<string> listOfStrings;

        public FindFile(string fileName)
        {
            this.fileName = fileName;
            status = "not ready";
            readTextFile(fileName);
        }

        private void readTextFile(string fileName)
        {
            string line;
            StreamReader inputFile;

            try
            {
                inputFile = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read));

                listOfStrings = new List<string>();

                while (inputFile.Peek() != -1)
                {
                    line = inputFile.ReadLine();
                    listOfStrings.Add(line);
                }

                inputFile.Close();

                status = "ok";
            }

            catch (Exception ex)
            {
                status = "error reading file---" + ex.ToString();
            }
        }

        public void showListOfStrings()
        {
            foreach (string thing in listOfStrings)
            {
                Console.WriteLine(thing);
            }
        }

        public void saveFile()
        {
            TextWriter tw = new StreamWriter(fileName);

            foreach (string thing in listOfStrings)
            {
                tw.WriteLine(thing);
            }

            tw.Close();
        }

        public string Status
        {
            get
            {
                return status;
            }
        }

        public List<string> ListOfStrings
        {
            get
            {
                return listOfStrings;
            }
            set
            {
                listOfStrings = value;
            }
        }
    }
}
