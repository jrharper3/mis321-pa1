using System;
using System.Collections.Generic;
using System.IO;

namespace pa1
{
    public class Post : IComparable<Post>
    {
        public int id {get; set;}
        public string date {get; set;}
        public string time {get; set;}
        public string text {get; set;}
        public Post() {
            id = 0;
            date = "0/0";
            time = "00:00";
            text = "";
        }
        public Post(int num, string day, string t, string words) {
            id = num;
            date = day;
            time = t;
            text = words;
        }
        public static List<Post> GetPostsFromFile(string fileName) {
            List<Post> allPosts = new List<Post>();
            StreamReader inFile = null;

            try {
                inFile = new StreamReader(fileName);
            }
            catch (FileNotFoundException e) {
                Console.WriteLine("Something went wrong... returning blank list. {0}", e);
                return allPosts;
            }

            string line = inFile.ReadLine();
            string[] splitInput;

            while (line != null) {
                splitInput = line.Split("#");
                allPosts.Add(new Post(){id = int.Parse(splitInput[0]), date = splitInput[1], time = splitInput[2], text = splitInput[3]});
                line = inFile.ReadLine();
            }

            inFile.Close();

            return allPosts;
        }

        public string toString() {
            return "ID: " + id + " Date: " + date + " " + time + "\n" + text + "\n";
        }

        public int CompareTo(Post temp) {
            string thisDate = this.date + this.time;
            string tempDate = temp.date + temp.time;
            return thisDate.CompareTo(tempDate);
        }
    }
}