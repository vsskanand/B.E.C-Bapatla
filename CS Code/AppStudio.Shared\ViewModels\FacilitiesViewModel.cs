using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class FacilitiesViewModel : ViewModelBase<FacilitiesSchema>
    {
        override protected string CacheKey
        {
            get { return "FacilitiesDataSource"; }
        }

        private RelayCommandEx<FacilitiesSchema> itemClickCommand;
        public RelayCommandEx<FacilitiesSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<FacilitiesSchema>(
                        (item) =>
                        {
                            NavigationServices.CurrentViewModel = this;
                            this.SelectedItem = item;

                            NavigationServices.NavigateToPage("FacilitiesDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected IDataSource<FacilitiesSchema> CreateDataSource()
        {
            return new FacilitiesDataSource(); // CollectionDataSource
        }

        override public Visibility PinToStartVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected void PinToStart()
        {
            base.PinToStart("FacilitiesDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
        }

        override public Visibility ShareItemVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override public Visibility TextToSpeechVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected async void TextToSpeech()
        {
            await base.SpeakText("Description");
        }

        override public Visibility RefreshVisibility
        {
            get { return ViewType == ViewTypes.List ? Visibility.Visible : Visibility.Collapsed; }
        }

        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("FacilitiesList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("FacilitiesDetail");
        }
    }
}
