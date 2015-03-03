using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class FacilitiesDataSource : IDataSource<FacilitiesSchema>
    {
        private const string _appId = "beb29d24-a197-47c0-814a-b86aaafe3800";
        private const string _dataSourceName = "3927124e-e4dc-4132-ada8-4eb5e09a8806";

        private IEnumerable<FacilitiesSchema> _data = null;

        public FacilitiesDataSource()
        {
        }

        public async Task<IEnumerable<FacilitiesSchema>> LoadData()
        {
            if (_data == null)
            {
                try
                {
                    var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                    _data = await serviceDataProvider.Load<FacilitiesSchema>();
                }
                catch (Exception ex)
                {
                    AppLogs.WriteError("FacilitiesDataSource.LoadData", ex.ToString());
                }
            }
            return _data;
        }

        public async Task<IEnumerable<FacilitiesSchema>> Refresh()
        {
            _data = null;
            return await LoadData();
        }
    }
}
