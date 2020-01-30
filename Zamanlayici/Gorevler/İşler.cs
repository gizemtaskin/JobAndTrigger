using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zamanlayici.Gorevler
{
    class DersGorev : IJob
    {

        public Ogrenci Ogrenci { get; set; } = new Ogrenci();
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap data = context.JobDetail.JobDataMap;
            Console.WriteLine($"{data.GetString("Adi")} {data.GetString("SoyAdi")} tek ayakta bekliyor...");
        }
    }
}
