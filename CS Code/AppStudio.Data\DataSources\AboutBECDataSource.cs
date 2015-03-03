using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AboutBECDataSource : IDataSource<HtmlSchema>
    {
        private IEnumerable<HtmlSchema> _data = new HtmlSchema[]
        {
            new HtmlSchema
            {
                Id = "{957d2cf5-20c4-4631-ad31-d53a23903222}",
                Content = @"<p>
</p>

<h5 style=""color:white"">
   Bapatla Engineering College (Autonomous) is one of the seven educational Institutions founded and run by BAPATLA EDUCATION SOCIETY. The society was established in the year 1962 registered (No: 58/1962) under societies act XXI of 1860 with the objectives to fund and run the educational &amp; cultural Institutions

</h5>
<h5 style=""color:white"">
<u>Institutions run by Bapatla Education Society</u>
<br>
1. 	Bapatla College of Arts &amp; Sciences	1963<br>
2	. Bapatla Engineering College (Autonomous)	1981<br>
3	. Bapatla Public School	1987<br>
4	. Bapatla Junior College	1994<br>
5	. Bapatla College of Pharmacy	1995<br>
6	. Bapatla Polytechnic College	2009<br>
7	. Bapatla Womens' Engineering Col	2009<br></h5> "
            }
        };

        public async Task<IEnumerable<HtmlSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<HtmlSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
