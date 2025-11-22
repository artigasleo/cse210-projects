using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        List<Video> videos = new List<Video>();

        // ----- Video 1 -----
        Video video1 = new Video
        {
            Title = "How to Make Strogonoff",
            Author = "Chef Leo",
            LengthSeconds = 420
        };
        video1.AddComment(new Comment("Camila", "This looks delicious!"));
        video1.AddComment(new Comment("Helena", "I'm making this today!"));
        video1.AddComment(new Comment("Heitor", "Best recipe I've seen!"));
        videos.Add(video1);

        // ----- Video 2 -----
        Video video2 = new Video
        {
            Title = "Learn C# in 10 Minutes",
            Author = "CodeMaster",
            LengthSeconds = 600
        };
        video2.AddComment(new Comment("Julio", "Very helpful tutorial!"));
        video2.AddComment(new Comment("Amelia", "Excellent explanation."));
        video2.AddComment(new Comment("Henrique", "Thanks for sharing!"));
        videos.Add(video2);

        // ----- Video 3 -----
        Video video3 = new Video
        {
            Title = "Travel Vlog: Buenos Aires",
            Author = "Leo Artigas",
            LengthSeconds = 900
        };
        video3.AddComment(new Comment("Nikolas", "I want to travel there now!"));
        video3.AddComment(new Comment("Dimitrios", "Loved this video!"));
        video3.AddComment(new Comment("Cibele", "Beautiful places!"));
        videos.Add(video3);

        // ----- Display Results -----
        foreach (Video vid in videos)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Title: {vid.Title}");
            Console.WriteLine($"Author: {vid.Author}");
            Console.WriteLine($"Length: {vid.LengthSeconds} seconds");
            Console.WriteLine($"Comments: {vid.GetCommentCount()}");
            Console.WriteLine("Comment List:");

            foreach (Comment c in vid.GetComments())
            {
                Console.WriteLine($" - {c.Name}: {c.Text}");
            }

            Console.WriteLine();
        }
    }
}
