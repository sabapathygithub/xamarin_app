using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Exercise1.ViewModels
{
    public interface IPageService
    {
        Task PushAsync(Page page);

        void PopAsync();

        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
    }
}
