using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Zamanlayici.Program;

namespace Zamanlayici.Gorevler
{
    class YıllıkUcretTahsilEtJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            int müşteriNumarası = 0;
            MuhasebeModülü modül = new MuhasebeModülü();

            //Bekleyenİşlemler için müşteri numaraları çekilir yıllıkücrettahsiletme işlemleri yapılır.

            modül.MethodÇağır("YıllıkUcretTahsilEt", müşteriNumarası);

        }
    }
}
