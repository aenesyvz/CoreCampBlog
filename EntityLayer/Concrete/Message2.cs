using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Message2
    {
        [Key]
        public int MessageId { get; set; }
        public int? SenderId { get; set; }
        public int? RecevierId { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
        public Writer SenderUser { get; set; }
        public Writer ReceiverUser { get; set; }
    }
}
