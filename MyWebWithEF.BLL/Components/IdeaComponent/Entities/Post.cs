﻿public class Post
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Details { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
