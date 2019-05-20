using BrownNews.ViewModels;
using System.Threading.Tasks;

namespace BrownNews.Services
{
    public interface IPayPalService
    {
        Task<string> ProcessPayment(PayPalTestViewModel model);
    }
}
