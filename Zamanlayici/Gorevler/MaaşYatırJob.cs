using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Zamanlayici.Program;

namespace Zamanlayici.Gorevler
{
    class MaaşYatırJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            int müşteriNumarası = 0;
            MuhasebeModülü modül = new MuhasebeModülü();
            //Bekleyenİşlemler için varsa müşteri numaraları çekilir ve maaş yatırma işlemleri yapılır.
            
            modül.MethodÇağır("MaaşYatır", müşteriNumarası);

        }
    }
}
