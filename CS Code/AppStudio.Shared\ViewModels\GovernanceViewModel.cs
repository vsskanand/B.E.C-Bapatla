using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class GovernanceViewModel : ViewModelBase<HtmlSchema>
    {
        override protected string CacheKey
        {
            get { return "GovernanceDataSource"; }
        }

        private RelayCommandEx<HtmlSchema> itemClickCommand;
        public RelayCommandEx<HtmlSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<HtmlSchema>(
                        (item) =>
                        {
                            NavigationServices.CurrentViewModel = this;
                            this.SelectedItem = item;

                            NavigationServices.NavigateToPage("", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected IDataSource<HtmlSchema> CreateDataSource()
        {
            return new GovernanceDataSource(); // HtmlDataSource
        }

        override public bool IsStaticData
        {
            get { return true; }
        }

        override public ViewTypes ViewType
        {
            get { return ViewTypes.Detail; }
        }
    }
}
