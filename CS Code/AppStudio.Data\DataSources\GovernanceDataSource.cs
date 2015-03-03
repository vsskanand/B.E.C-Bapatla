using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class GovernanceDataSource : IDataSource<HtmlSchema>
    {
        private IEnumerable<HtmlSchema> _data = new HtmlSchema[]
        {
            new HtmlSchema
            {
                Id = "{4eff3c60-bb4f-430c-83cf-26a3c1521768}",
                Content = "<style>\nh5{color:white; font-size:16px}\n</style>\n<h5 style=\"color:white\"><u>\nOur " +
    "distinguished office bearers are</u></h5>\n\n<div class=\"wysiwyg-text-align-center" +
    "\"><img alt=\"\" src=\"http://becbapatla.ac.in/img/president.jpg\" height=\"150\"></div" +
    ">\n\n<h5>\nSri. Muppalaneni Seshagiri Rao<br>\nPresident Bapatla Education Society</" +
    "h5>\n\n<h5>The college is especially lucky regarding the commitment of the managem" +
    "ent. The management members are imbued with a spirit of selfless service and bel" +
    "ieve in the principle of Academic autonomy. Transparency of all financial transa" +
    "ctions is strictly adhered and all payments and receipts are through DD’s and Ch" +
    "eques only. The Management obtains objective feedback about all aspects of the c" +
    "ollege and suitably advises and motivates employees in a discrete manner.\n\n</h5>" +
    "\n<h5>Vice-President : \tSri. P. Raghuram\n</h5><h5>Vice-President-II : \tSri. T. Ra" +
    "ma Krishna Rao\n</h5><h5>Secretary\t : Sri. Manam Nageswara Rao\n</h5><h5>Correspon" +
    "dent : \tSri. K. Lakshminarayana\n</h5><h5>Treasurer\t : Sri. P. Sambasiva Rao\n\n\n</" +
    "h5><h5>\nThe constructional works are personally supervised by the management not" +
    " entrusted to contractors. Good quality materials are negotiated at best price p" +
    "ersonally by the management. College buildings are constructed by the management" +
    " at about 50% of the cost of the approved Scheduled Rates (SR) of the State Govt" +
    ". without compromising the quality.\n\nAs a mark of commitment to good management," +
    " rules and regulations are applied with justice and fair play. Above all the man" +
    "agement makes all out effort to provide healthy environment on the campus. (Lawn" +
    "s, Greenery (Including 1000 neem trees) and CC roads provided)</h5>"
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
