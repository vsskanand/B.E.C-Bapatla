using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class HODsInfoViewModel : ViewModelBase<HODsInfoSchema>
    {
        override protected string CacheKey
        {
            get { return "HODsInfoDataSource"; }
        }

        private RelayCommandEx<HODsInfoSchema> itemClickCommand;
        public RelayCommandEx<HODsInfoSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<HODsInfoSchema>(
                        (item) =>
                        {
                            NavigationServices.CurrentViewModel = this;
                            this.SelectedItem = item;

                            NavigationServices.NavigateToPage("HODsInfoDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected IDataSource<HODsInfoSchema> CreateDataSource()
        {
            return new HODsInfoDataSource(); // CollectionDataSource
        }

        override public bool IsStaticData
        {
            get { return true; }
        }

        override public Visibility PinToStartVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected void PinToStart()
        {
            base.PinToStart("HODsInfoDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
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
            await base.SpeakText("Name");
        }

        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("HODsInfoList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("HODsInfoDetail");
        }
    }
}
