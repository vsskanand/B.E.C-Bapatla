using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class MainViewModel : BindableBase
    {
       private AboutBECViewModel _aboutBECModel;
       private GovernanceViewModel _governanceModel;
       private FacilitiesViewModel _facilitiesModel;
       private HODsInfoViewModel _hODsInfoModel;
       private NewsViewModel _newsModel;
       private ContactUsViewModel _contactUsModel;
        private PrivacyViewModel _privacyModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModel()
        {
            _selectedItem = AboutBECModel;
            _privacyModel = new PrivacyViewModel();

        }
 
        public AboutBECViewModel AboutBECModel
        {
            get { return _aboutBECModel ?? (_aboutBECModel = new AboutBECViewModel()); }
        }
 
        public GovernanceViewModel GovernanceModel
        {
            get { return _governanceModel ?? (_governanceModel = new GovernanceViewModel()); }
        }
 
        public FacilitiesViewModel FacilitiesModel
        {
            get { return _facilitiesModel ?? (_facilitiesModel = new FacilitiesViewModel()); }
        }
 
        public HODsInfoViewModel HODsInfoModel
        {
            get { return _hODsInfoModel ?? (_hODsInfoModel = new HODsInfoViewModel()); }
        }
 
        public NewsViewModel NewsModel
        {
            get { return _newsModel ?? (_newsModel = new NewsViewModel()); }
        }
 
        public ContactUsViewModel ContactUsModel
        {
            get { return _contactUsModel ?? (_contactUsModel = new ContactUsViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            AboutBECModel.ViewType = viewType;
            GovernanceModel.ViewType = viewType;
            FacilitiesModel.ViewType = viewType;
            HODsInfoModel.ViewType = viewType;
            NewsModel.ViewType = viewType;
            ContactUsModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public Visibility AppBarVisibility
        {
            get
            {
                return SelectedItem == null ? AboutVisibility : SelectedItem.AppBarVisibility;
            }
        }

        public Visibility AboutVisibility
        {

         get { return Visibility.Visible; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("AppBarVisibility");
            OnPropertyChanged("AboutVisibility");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadData(bool isNetworkAvailable)
        {
            var loadTasks = new Task[]
            { 
                AboutBECModel.LoadItems(isNetworkAvailable),
                GovernanceModel.LoadItems(isNetworkAvailable),
                FacilitiesModel.LoadItems(isNetworkAvailable),
                HODsInfoModel.LoadItems(isNetworkAvailable),
                NewsModel.LoadItems(isNetworkAvailable),
                ContactUsModel.LoadItems(isNetworkAvailable),
            };
            await Task.WhenAll(loadTasks);
        }

        /// <summary>
        /// Refresh ViewModel items asynchronous
        /// </summary>
        public async Task RefreshData(bool isNetworkAvailable)
        {
            var refreshTasks = new Task[]
            { 
                AboutBECModel.RefreshItems(isNetworkAvailable),
                GovernanceModel.RefreshItems(isNetworkAvailable),
                FacilitiesModel.RefreshItems(isNetworkAvailable),
                HODsInfoModel.RefreshItems(isNetworkAvailable),
                NewsModel.RefreshItems(isNetworkAvailable),
                ContactUsModel.RefreshItems(isNetworkAvailable),
            };
            await Task.WhenAll(refreshTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await RefreshData(NetworkInterface.GetIsNetworkAvailable());
                });
            }
        }

        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand PrivacyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateTo(_privacyModel.Url);
                });
            }
        }
    }
}
