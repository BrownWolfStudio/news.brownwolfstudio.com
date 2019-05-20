using System.ComponentModel.DataAnnotations;

namespace BrownNews.ViewModels
{
    public class PayPalTestViewModel
    {
        [Required]
        public string Amount { get; set; }
    }
}