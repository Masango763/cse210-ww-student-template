using System;
using System.Collections.Generic;

// ===================================================================================
// CREATIVITY AND EXCEEDING REQUIREMENTS:
// 1. Human-Readable Runtime Formatter: Added an analytical parsing engine that formats
//    large quantities of raw seconds into structured hours, minutes, and seconds 
//    (e.g., "25m 0s" or "1h 5m 12s") rather than only printing the raw number.
// ===================================================================================

public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public string GetFormattedDuration()
    {
        TimeSpan time = TimeSpan.FromSeconds(_lengthInSeconds);
        if (time.Hours > 0)
        {
            return $"{time.Hours}h {time.Minutes}m {time.Seconds}s";
        }
        return $"{time.Minutes}m {time.Seconds}s";
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Runtime: {GetFormattedDuration()} ({_lengthInSeconds} total seconds)");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"  - {comment.GetCommenterName()}: \"{comment.GetText()}\"");
        }
        Console.WriteLine(new string('-', 40));
    }
}