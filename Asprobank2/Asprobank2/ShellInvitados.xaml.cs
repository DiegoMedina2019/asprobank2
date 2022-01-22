using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asprobank2.ViewModels;
using Asprobank2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asprobank2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShellInvitados : Xamarin.Forms.Shell
    {
        public ShellInvitados()
        {
            InitializeComponent();
        }
        //private void Login_Clic(object sender, EventArgs e)
        //{
        //    Application.Current.MainPage = new LoginPage();
        //}
    }
}