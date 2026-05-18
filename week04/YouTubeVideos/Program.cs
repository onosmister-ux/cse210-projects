using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Learning C#", "CodeMaster", 600);
        Video video2 = new Video("Python Basics", "Tech Guru", 750);
        Video video3 = new Video("Web Development Tutorial", "Dev World", 900);

        // Add comments to video1
        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Sarah", "Very helpful."));
        video1.AddComment(new Comment("Mike", "Thanks for explaining clearly."));

        // Add comments to video2
        video2.AddComment(new Comment("Anna", "Python is awesome!"));
        video2.AddComment(new Comment("David", "I learned a lot."));
        video2.AddComment(new Comment("Chris", "Please make more videos."));

        // Add comments to video3
        video3.AddComment(new Comment("Emma", "Excellent content."));
        video3.AddComment(new Comment("James", "This helped my project."));
        video3.AddComment(new Comment("Sophia", "Easy to understand."));

        // Store videos in a list
        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display videos and comments
        foreach (Video video in videos)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}