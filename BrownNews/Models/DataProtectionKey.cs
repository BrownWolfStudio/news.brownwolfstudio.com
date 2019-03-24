using System.ComponentModel.DataAnnotations;

namespace BrownNews.Models
{
    public class DataProtectionKey
    {
        [Key]
        public string FriendlyName { get; set; }
        public string XmlData { get; set; }
    }
}
