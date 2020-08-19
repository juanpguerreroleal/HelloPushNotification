using HelloPushNotification.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloPushNotification.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<TransferItemViewModel> GetTransferItemAsync(int id);
        Task<IEnumerable<TransferItemViewModel>> GetTransfersAsync();
    }
}
