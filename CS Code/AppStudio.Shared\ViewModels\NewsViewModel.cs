using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class NewsViewModel : ViewModelBase<BingSchema>
    {
        override protected string CacheKey
        {
            get { return "NewsDataSource"; }
        }

        private RelayCommandEx<BingSchema> itemClickCommand;
        public RelayCommandEx<BingSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<BingSchema>(
                        (item) =>
                        {
                            NavigationServices.CurrentViewModel = this;
                            this.SelectedItem = item;

                            var currentItem = GetCurrentItem();
                            if (currentItem != null)
                            {
                                NavigationServices.NavigateTo(new Uri(currentItem.GetValue("Link")));
                            }
                        });
                }

                return itemClickCommand;
            }
        }

        override protected IDataSource<BingSchema> CreateDataSource()
        {
            return new NewsDataSource(); // BingDataSource
        }

        override public Visibility RefreshVisibility
        {
            get { return ViewType == ViewTypes.List ? Visibility.Visible : Visibility.Collapsed; }
        }

        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("NewsList");
        }

        override protected void NavigateToSelectedItem()
        {
            var currentItem = GetCurrentItem();
            if (currentItem != null)
            {
                NavigationServices.NavigateTo(new Uri(currentItem.GetValue("Link")));
            }
        }
    }
}
