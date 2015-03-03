using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class ContactUsViewModel : ViewModelBase<MenuSchema>
    {
        override protected string CacheKey
        {
            get { return "ContactUsDataSource"; }
        }

        private RelayCommandEx<MenuSchema> itemClickCommand;
        public RelayCommandEx<MenuSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<MenuSchema>(
                        (item) =>
                        {
                            NavigationServices.CurrentViewModel = this;
                            this.SelectedItem = item;

                            var currentItem = GetCurrentItem();
                            if (currentItem != null)
                            {
                                if (currentItem.GetValue("Type").EqualNoCase("Section"))
                                {
                                    NavigationServices.NavigateToPage(currentItem.GetValue("Target"));
                                }
                                else
                                {
                                    NavigationServices.NavigateTo(new Uri(currentItem.GetValue("Target"), UriKind.Absolute));
                                }
                            }
                           
                        });
                }

                return itemClickCommand;
            }
        }

        override protected IDataSource<MenuSchema> CreateDataSource()
        {
            return new ContactUsDataSource(); // MenuDataSource
        }

        override public bool IsStaticData
        {
            get { return true; }
        }

        override public bool HasMoreItems
        {
            get { return false; }
        }

        override protected void NavigateToSelectedItem()
        {
            var currentItem = GetCurrentItem();
            if (currentItem != null)
            {
                if (currentItem.GetValue("Type").EqualNoCase("Section"))
                {
                    NavigationServices.NavigateToPage(currentItem.GetValue("Target"));
                }
                else
                {
                    NavigationServices.NavigateTo(new Uri(currentItem.GetValue("Target"), UriKind.Absolute));
                }
            }
        }
    }
}
