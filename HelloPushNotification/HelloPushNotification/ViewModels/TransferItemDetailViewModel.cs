using Acr.UserDialogs;
using HelloPushNotification.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace HelloPushNotification.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class TransferItemDetailViewModel: BaseViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _id;

        public string Id
        {
            get 
            { 
                return _id; 
            }
            set 
            {
                if (_id != value)
                {
                    _id = value;
                    LoadData(Convert.ToInt32(value));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
                }
            }
        }
        private string _name;

        public string Name
        {
            get 
            { 
                return _name; 
            }
            set 
            { 
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }


        public TransferItemDetailViewModel()
        {

        }

        public async void LoadData(int TransferId)
        {
            try
            {
                var item = await DataStore.GetTransferItemAsync(TransferId);
                Name = item.Name;
            }
            catch (Exception e)
            {
                await UserDialogs.Instance.AlertAsync("The transfer you are trying to see doesn't exist", "Non-existent transfer", "OK");
                await Shell.Current.Navigation.PopToRootAsync();
            }
        }
    }
}
