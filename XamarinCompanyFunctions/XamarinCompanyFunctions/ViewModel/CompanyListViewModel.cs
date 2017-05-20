using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XamarinCompanyFunctions.Model;

namespace XamarinCompanyFunctions.ViewModel
{
    public class CompanyListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool _IsLoading;

        public bool IsLoading
        {
            get { return _IsLoading; }
            private set
            {
                if (_IsLoading != value)
                {
                    _IsLoading = value;
                    RaisePropertyChanged();
                }
            }
        }

        public List<string> Companies { get; set; }

        string _SelectedCompany;

        public string SelectedCompany
        {
            get { return _SelectedCompany; }
            set
            {
                if (_SelectedCompany != value)
                {
                    _SelectedCompany = value;
                    OnSelectedCompanyChanged();
                }
            }
        }

        IEnumerable<Address> _Addresses;

        public IEnumerable<Address> Addresses
        {
            get
            {
                return _Addresses;
            }
            set
            {
                _Addresses = value;
                RaisePropertyChanged();
            }
        }

        public CompanyListViewModel()
        {
            Companies = new List<string>() { "TecNM", "UGto" };
        }

        string AZURE_FUNCTION_URI = "https://companyfunction.azurewebsites.net/api/HttpTriggerCSharp1?code=2SEPwg0BeomxwxEQ35zOmj5HztcpkeI9R419uVSakpNbOrG9g7vsHw==";

        private async Task OnSelectedCompanyChanged()
        {
            IsLoading = true;
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var url = string.Format(AZURE_FUNCTION_URI + "&company={0}", SelectedCompany.ToLower());
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var addresses = JsonConvert.DeserializeObject<IEnumerable<Address>>(json);

                    Addresses = addresses;
                }

            }
            catch (Exception)
            {
                //Going to ignore it for now
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
