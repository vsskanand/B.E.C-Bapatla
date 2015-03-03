using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class NewsDataSource : IDataSource<BingSchema>
    {
        private const string _url = @"http://www.bing.com/search?q=Bapatla+Engineering+College loc:in&format=rss";

        private IEnumerable<BingSchema> _data = null;

        public NewsDataSource()
        {
        }

        public async Task<IEnumerable<BingSchema>> LoadData()
        {
            if (_data == null)
            {
                try
                {
                    var rssDataProvider = new RssDataProvider(_url);
                    var syndicationItems = await rssDataProvider.Load();
                    _data = from r in syndicationItems
                            select new BingSchema()
                            {
                                Title = r.Title,
                                Summary = r.Summary,
                                Link = r.FeedUrl,
                                Published = r.PublishDate
                            };
                }
                catch (Exception ex)
                {
                    AppLogs.WriteError("NewsDataSourceDataSource.LoadData", ex.ToString());
                }
            }
            return _data;
        }

        public async Task<IEnumerable<BingSchema>> Refresh()
        {
            _data = null;
            return await LoadData();
        }
    }
}
