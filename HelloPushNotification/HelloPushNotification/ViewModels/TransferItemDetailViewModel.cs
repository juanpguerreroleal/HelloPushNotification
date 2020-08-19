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
                _id = value;
                LoadData(Convert.ToInt32(value));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
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
            var item = await DataStore.GetTransferItemAsync(TransferId);
            Name = item.Name;
        }
    }
}
