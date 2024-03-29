﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using SampleAppAdobeAnalytics.Constants;
using SampleAppAdobeAnalytics.Services;

namespace SampleAppAdobeAnalytics
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command AddItemCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new Command<Item>(async (Item item) =>
            {
                var data = new Dictionary<string, string>();
                data.Add("item", item.Text);
                AnalyticsService.TrackEvent(AnalyticConstants.AddItem, data);
                await AddItem(item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task AddItem(Item item)
        {
            Items.Add(item);
            await DataStore.AddItemAsync(item);
        }
    }
}
