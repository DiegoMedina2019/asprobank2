using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Asprobank2.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Asprobank2.ViewModels
{
    public class RedesViewModel
    {
        public ICommand TwitterCommand { get; }
        public ICommand FacebookCommand { get; }
        public RedesViewModel()
        {
            TwitterCommand = new Command(async () => await Browser.OpenAsync("https://mobile.twitter.com/ASPROBANK"));
            FacebookCommand = new Command(async () => await Browser.OpenAsync("https://www.facebook.com/"));
        }
    }
}
