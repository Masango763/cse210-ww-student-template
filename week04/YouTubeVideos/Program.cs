using System;
using System.Collections.Generic;

// ===================================================================================
// SYSTEM DRIVER: YouTubeVideos Program
// This entry point initializes the video database list, populates it with distinct
// video instances, attaches corresponding user comments, and renders the output.
// ===================================================================================

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // ---------------------------------------------------------------------------
        // VIDEO 1: Educational Programming Content
        // ---------------------------------------------------------------------------
        Video video1 = new Video("C# Tutorial for Beginners", "ProgrammingWithMosh", 1200);
        video1.AddComment(new Comment("Alice", "This cleared up all my confusion about classes!"));
        video1.AddComment(new Comment("Bob", "Great pacing, thank you."));
        video1.AddComment(new Comment("Charlie", "Can you make a video on interfaces next?"));
        videos.Add(video1);

        // ---------------------------------------------------------------------------
        // VIDEO 2: Aerospace/Engineering Content
        // ---------------------------------------------------------------------------
        Video video2 = new Video("SpaceX Starship Launch Analysis", "CosmoGazer", 750);
        video2.AddComment(new Comment("David", "The telemetry breakdown was fantastic."));
        video2.AddComment(new Comment("Emma", "Incredible footage of the booster catch!"));
        video2.AddComment(new Comment("Frank", "Engineering marvel of our century."));
        videos.Add(video2);

        // ---------------------------------------------------------------------------
        // VIDEO 3: Culinary Arts Instruction
        // ---------------------------------------------------------------------------
        Video video3 = new Video("Sourdough Bread Making 101", "BakeWithGrace", 1500);
        video3.AddComment(new Comment("Grace", "My crust finally turned out crispy!"));
        video3.AddComment(new Comment("Henry", "What hydration percentage did you use?"));
        video3.AddComment(new Comment("Ian", "Best tutorial on the internet, hands down."));
        videos.Add(video3);

        // ---------------------------------------------------------------------------
        // ITERATION & OUTPUT RENDERING
        // ---------------------------------------------------------------------------
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
