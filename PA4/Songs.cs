using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PA4
{
    public class Songs
    {
        private String title;
        private String artist;
        private String date;

        public Songs()
        {
            title = "???";
            artist = "???";
            date = "??/??/????";
        }

        public Songs(String title, String artist, String date)
        {
            this.title = title;
            this.artist = artist;
            this.date = date;
        }

        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public String Artist
        {
            get
            {
                return artist;
            }
            set
            {
                artist = value;
            }
        }

        public String Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public override string ToString()
        {
            return "Title: " + title + "\r\n" +
                    "Artist: " + artist + "\r\n" +
                    "Date Released: " + date;
        }
    }
}