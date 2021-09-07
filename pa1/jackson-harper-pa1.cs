using System.Threading;
using System.Net.NetworkInformation;
using System.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace pa1
{
    class Program
    {
        static void ShowPosts(List<Post> posts) {
            posts.Sort();

            foreach(Post post in posts) {
                Console.WriteLine(post.toString());
            }
        }

        static void AddPost(List<Post> allPosts) {
            Console.WriteLine("What is the post ID?");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the date? Enter as (##/##)");
            string day = Console.ReadLine();

            Console.WriteLine("What is the time? Enter as ##:##");
            string t = Console.ReadLine();

            Console.WriteLine("What will the post say?");
            string post = Console.ReadLine();

            allPosts.Add(new Post(){id = num, date = day, time = t, text = post});

            Console.WriteLine("Post added!");
            WritePostsToFile("posts.txt", allPosts);
        }

        static void DeletePost(List<Post> allPosts) {
            Console.WriteLine("What is the ID of the post you want deleted?");
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i <= allPosts.Count; ++i) {
                if (allPosts[i].id == num) {
                    allPosts.Remove(allPosts[i]);
                    WritePostsToFile("posts.txt", allPosts);
                    break;
                }
            }

            Console.WriteLine("Successfully removed post.");
        }
        public static void WritePostsToFile(string fileName, List<Post> allPosts) {
            string output = null;

            foreach(Post post in allPosts) {
                output += post.id + "#" + post.date + "#" + post.time + "#" + post.text + "\n";
            }

            string text = File.ReadAllText(fileName);
            text = text.Replace(text, output);
            File.WriteAllText(fileName, text);
        }

        static void DisplayMenu(List<Post> posts) {
            Console.WriteLine("Welcome to the Big Al Goes Social backend! Please make a selection.");
            bool cont = true;

            while (cont) {
            Console.WriteLine("1. Show all posts\n2. Add a post\n3. Delete a post by ID\n4. Exit");
            int userSelection = int.Parse(Console.ReadLine());

            if (userSelection == 1) {
                ShowPosts(posts);
            }
            else if (userSelection == 2) {
                AddPost(posts);
            }
            else if (userSelection == 3) {
                DeletePost(posts);
            }
            else if (userSelection == 4) {
                Console.WriteLine("\nThank you for using the Big Al Goes Social backend! Exiting...");
                return;
            }
            else {
                Console.WriteLine("\nInvalid selection. Please try again.");
            }

            }
        }
        static void Main(string[] args)
        {
            List<Post> posts = Post.GetPostsFromFile("posts.txt");
            DisplayMenu(posts);
            WritePostsToFile("posts.txt", posts);
            return;
        }
    }
}
