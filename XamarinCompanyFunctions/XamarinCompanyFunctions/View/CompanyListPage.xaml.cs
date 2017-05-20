using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCompanyFunctions.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanyListPage : ContentPage
    {
        public CompanyListPage()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.CompanyListViewModel();
        }
    }
}
