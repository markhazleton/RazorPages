﻿using System;
using System.Linq;

namespace WiredBrainCoffee.Models
{
    public class Contact
    {
        public string PartnerId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public DateTime SubmittedTime { get; set; }

        public List<UploadedFile> AttachedFiles { get; set; } = new List<UploadedFile>();
    }
}
