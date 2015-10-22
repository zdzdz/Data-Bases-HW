﻿namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        [Required]
        [MaxLength(300)]
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }

        [Required]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

    }
}
