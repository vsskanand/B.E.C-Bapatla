using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class HODsInfoDataSource : IDataSource<HODsInfoSchema>
    {
        private readonly IEnumerable<HODsInfoSchema> _data = new HODsInfoSchema[]
		{
            new HODsInfoSchema
            {
                Name = "Sri Dr.Nagalla Sudhakar, Principal",
                Email = "suds_nagalla@yahoo.com            suds.nagalla@gmail.com",
                Phone = "555-0104",
                Image = "/Assets/DataImages/nsuds.jpg",
            },
            new HODsInfoSchema
            {
                Name = "Prof. CH.Ramesh, E.I.E Dept",
                Email = "ramesh.ch.m@gmail.com",
                Phone = "555-0103",
                Image = "/Assets/DataImages/eie.jpg",
            },
            new HODsInfoSchema
            {
                Name = "Sri Dr B.Chandra Mohan, E.C.E Dept",
                Email = " chandrabhuma@yahoo.co.in            chandrabhuma@gmail.com",
                Phone = "555-0105",
                Image = "/Assets/DataImages/chandrabhumaece-1.jpg",
            },
            new HODsInfoSchema
            {
                Name = "Sri N. Siva Ram Prasad, I.T Dept",
                Email = "sivanalluri@rediffmail.com",
                Phone = "555-0102",
                Image = "/Assets/DataImages/it.jpg",
            },
            new HODsInfoSchema
            {
                Name = "Sri Dr. N.Rama Gopal, Chemical Engg Dept",
                Email = "nrgbec@gmail.com",
                Phone = "555-0101",
                Image = "/Assets/DataImages/chm.jpg",
            },
            new HODsInfoSchema
            {
                Name = "Dr.N.PrabhakaraRao, Mathematics Dept",
                Email = "mail2drnpr@gmail.com",
                Phone = "555-0100",
                Image = "/Assets/DataImages/mm.jpg",
            },
            new HODsInfoSchema
            {
                Name = "Dr. K.Ravindranath, Chemistry Dept",
                Email = "ravindhranath.sita@yahoo.co.in",
                Phone = "",
                Image = "/Assets/DataImages/cc.jpg",
            },
            new HODsInfoSchema
            {
                Name = "Sri K. Neelakanteswara Prasad, M.C.A Dept",
                Email = "knpindia1@yahoo.com",
                Phone = "",
                Image = "/Assets/DataImages/nx.jpg",
            },
            new HODsInfoSchema
            {
                Name = "Mr.K.Siva Koteswara Rao, English Dept",
                Email = "sivakk@in.com",
                Phone = "",
                Image = "/Assets/DataImages/eng.jpg",
            },
            new HODsInfoSchema
            {
                Name = "Prof. Vetagiri Chakradhar, C.S.E Dept",
                Email = "cdvetagiri@gmail.com",
                Phone = "",
                Image = "/Assets/DataImages/vc1.jpg",
            },
		};

        public async Task<IEnumerable<HODsInfoSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<HODsInfoSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
