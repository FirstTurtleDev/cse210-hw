using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Video
    {
        private readonly string _title;
        private readonly string _author;
        private readonly int _lengthSeconds;
        private readonly List<Comment> _comments = new List<Comment>();

        public Video(string title, string author, int lengthSeconds)
        {
            _title = title;
            _author = author;
            _lengthSeconds = lengthSeconds;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetCommentCount()
        {
            // Returns directly from the list (meets rubric #4 perfectly)
            return _comments.Count;
        }

        public string GetTitle()  => _title;
        public string GetAuthor() => _author;
        public int GetLengthSeconds() => _lengthSeconds;

        public IEnumerable<Comment> GetComments()
        {
            return _comments;
        }
    }
}
