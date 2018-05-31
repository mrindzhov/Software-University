﻿namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public enum ContentType
    {
        Application, Pdf, Zip
    }

    public class Homework
    {
        //•	Homework: id, content, content-type (application/pdf/zip), submission date
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}