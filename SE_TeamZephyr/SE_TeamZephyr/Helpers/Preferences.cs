using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TeamZephyr.Helpers
{
    public static class Preferences
    {

        //Smoking
        public static string SmokingNo
        {
            get { return "I do not like smoking"; }
        }
        public static string SmokingMaybe
        {
            get { return "I do not mind smoking"; }
        }
        public static string SmokingYes
        {
            get { return "I like smoking"; }
        }


        //Animal
        public static string AnimalNo
        {
            get { return "I do not like animals"; }
        }
        public static string AnimalMaybe
        {
            get { return "I do not mind animals"; }
        }
        public static string AnimalYes
        {
            get { return "I like animals"; }
        }


        //Music
        public static string MusicNo
        {
            get { return "I do not like music"; }
        }
        public static string MusicMaybe
        {
            get { return "I do not mind music"; }
        }
        public static string MusicYes
        {
            get { return "I like music"; }
        }
    }
}