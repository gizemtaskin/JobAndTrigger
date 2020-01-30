using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamanlayici.Gorevler;

namespace Zamanlayici
{
    class Tetikleyici
    {
        private IScheduler Baslat()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = schedFact.GetScheduler();
            if (!sched.IsStarted)
                sched.Start();

            return sched;
        }

        public void GoreviTetikle()
        {
            IScheduler sched = Baslat();

            IJobDetail MaaşYatır = JobBuilder.Create<MaaşYatırJob>().WithIdentity("MaaşYatır", null).Build();

            ISimpleTrigger TriggerMaaşYatır = (ISimpleTrigger)TriggerBuilder.Create().WithIdentity("MaaşYatır").StartAt(DateTime.UtcNow).WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever()).Build();
            sched.ScheduleJob(MaaşYatır, TriggerMaaşYatır);

            IJobDetail YıllıkUcretTahsilEt = JobBuilder.Create<YıllıkUcretTahsilEtJob>().WithIdentity("YıllıkUcretTahsilEt", null).Build();

            ISimpleTrigger TriggerYıllıkUcretTahsilEt = (ISimpleTrigger)TriggerBuilder.Create().WithIdentity("YıllıkUcretTahsilEt").StartAt(DateTime.UtcNow).WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever()).Build();
            sched.ScheduleJob(YıllıkUcretTahsilEt, TriggerYıllıkUcretTahsilEt);

            //Çalışma süresi ve tekrarları değiştirilebilir. Dbde parametre tablosunda jobların ne sıklıkla ve saat kaçta çalışacağına dair kayıt tutulup ona göre kontrol edilip işlem yapılması da sağlanabilir.
        }
    }
}
