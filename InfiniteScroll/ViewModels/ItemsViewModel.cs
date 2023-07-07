using InfiniteScroll.InfiniteScrollModule;
using InfiniteScroll.Models;
using InfiniteScroll.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InfiniteScroll.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        private InfiniteScrollCollection<Item> _items;
        public InfiniteScrollCollection<Item> Items { get => _items; set => SetProperty(ref _items, value); }
        //public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }


        private const int PageSize = 20;
        public ICommand RefreshCommand { get; }


        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new InfiniteScrollCollection<Item>
            {
                OnLoadMore = async () =>
                {
                    // load the next page
                    var page = Items.Count / PageSize;
                    var items = await DataStore.GetItemsAsync(page + 1, PageSize);
                    return items;
                }
            };
            RefreshCommand = new Command(() =>
            {
                // clear and start again
                Items.Clear();
                Items.LoadMoreAsync();
            });

            // load the initial data
            Items.LoadMoreAsync();


            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        //async Task ExecuteLoadItemsCommand()
        //{
        //    IsBusy = true;

        //    try
        //    {
        //        //Items.Clear();
        //        //var items = await DataStore.GetItemsAsync(true);
        //        //foreach (var item in items)
        //        //{
        //        //    Items.Add(item);
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}