using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zamanlayici
{
    class YıllıkÜcretTahsilEt : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Görevdeyiz...");

        }
    }
}
