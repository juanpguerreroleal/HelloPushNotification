using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloPushNotification.Models;
using HelloPushNotification.ViewModels;

namespace HelloPushNotification.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        readonly List<TransferItemViewModel> transferItems;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
            transferItems = new List<TransferItemViewModel>()
            {
                new TransferItemViewModel
                {
                    Id = 1,
                    Name = "Store 1"
                },
                new TransferItemViewModel
                {
                    Id = 2,
                    Name = "Store 2"
                },
                new TransferItemViewModel
                {
                    Id = 3,
                    Name = "Store 3"
                }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public async Task<TransferItemViewModel> GetTransferItemAsync(int id)
        {
            return await Task.FromResult(transferItems.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<TransferItemViewModel>> GetTransfersAsync()
        {
            return await Task.FromResult(transferItems);
        }
    }
}