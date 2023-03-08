using System;

namespace WiredBrainCoffee.Models
{
    public class UploadedFile
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] FileContent { get; set; }
    }
}
