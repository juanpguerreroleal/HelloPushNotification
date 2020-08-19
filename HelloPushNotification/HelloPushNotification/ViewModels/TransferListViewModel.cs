using HelloPushNotification.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloPushNotification.ViewModels
{
    public class TransferListViewModel: BaseViewModel
    {
        private ObservableCollection<TransferItemViewModel> _transferList;

        public ObservableCollection<TransferItemViewModel> TransferList
        {
            get 
            { 
                return _transferList; 
            }
            set 
            {
                if (value != _transferList)
                {
                    _transferList = value;
                }
            }
        }

        public TransferListViewModel()
        {
            Title = "Transfer List";
            TransferList = new ObservableCollection<TransferItemViewModel>();
            LoadTransfers();
        }
        public ICommand ShowTransferDetailsCommand
        {
            get
            {
                return new Command<int>((Id) => GetTransferDetails(Id));
            }
        }
        public async void LoadTransfers()
        {
            var items = await DataStore.GetTransfersAsync();
            foreach (var item in items)
            {
                TransferList.Add(item);
            }
        }
        public async void GetTransferDetails(int Id)
        {
            await Shell.Current.GoToAsync($"{nameof(TransferItemDetailPage)}?{nameof(TransferItemViewModel.Id)}={Id}");
        }
    }
}
