using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class ContactUsDataSource : IDataSource<MenuSchema>
    {
        private readonly IEnumerable<MenuSchema> _data = new MenuSchema[]
		{
            new MenuSchema
            {
                Type = "Url",
                Title = "Postal Address",
                Icon = "/Assets/DataImages/Item-dd7eb8ba-7f16-46b0-9a38-ff3ebe9433c5.png",
                Target = "bingmaps:?where=Bapatla+Engineering+College%2c+Bapatla+Engineering+College%2c+Gun" +
    "tur+National+Highway+214A%2c+Bapatla%2c+Andhra+Pradesh+522101+IndiaAndhra+Prades" +
    "h+522101+India",
            },
            new MenuSchema
            {
                Type = "Url",
                Title = "How to get to",
                Icon = "/Assets/DataImages/Item-53e88f6f-42e4-4d2c-ab41-a8d568894434.png",
                Target = "bingmaps:?where=Bapatla+Engineering+College%2c+Guntur%2c+National+Highway+214A%2c" +
    "+Bapatla%2c+Andhra+Pradesh+522101%2c+India",
            },
            new MenuSchema
            {
                Type = "Url",
                Title = "0-864-322-4244",
                Icon = "/Assets/DataImages/Item-9ce253a3-5d2c-4151-b88c-6188566638a0.png",
                Target = "tel:0-864-322-4244",
            },
            new MenuSchema
            {
                Type = "Url",
                Title = "bec_principal@yahoo.com",
                Icon = "/Assets/DataImages/Item-18a79169-63d2-4418-931d-dc6f9a6be1a8.png",
                Target = "mailto:bec_principal@yahoo.com",
            },
            new MenuSchema
            {
                Type = "Url",
                Title = "www.becbapatla.ac.in",
                Icon = "/Assets/DataImages/Item-492dd772-70d2-480e-b4d5-66c89315293c.png",
                Target = "http://www.becbapatla.ac.in",
            },
		};

        public async Task<IEnumerable<MenuSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<MenuSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
