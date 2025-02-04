﻿namespace TodoAPI.Model
{
    public class TODOItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsCompleted { get; set; }
    }
}
