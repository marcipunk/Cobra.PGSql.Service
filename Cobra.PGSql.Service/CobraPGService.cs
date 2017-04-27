using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Cobra.PGSql.Service
{
    public partial class Service1: ServiceBase
    {
        public Service1()
        {
            PGEntities PGdb = new PGEntities();
            var PGCollectorQuery = from c in PGdb.Collector select c;
            IList<PGCollector> PGCollectorList = PGCollectorQuery.ToList();
            //BindingList<PGCollector> PGCollectors = new BindingList<PGCollector>(PGCollectorQuery.ToList());
           

        }

        protected override void OnStart(string[] args)
        {
            if (Properties.Settings.Default.LastRun == DateTime.Now)
            {

                FileStream LogFile = new FileStream("Log.Txt", FileMode.OpenOrCreate);
                StreamWriter LogWriter = new StreamWriter(LogFile);
                LogWriter.WriteLine("A CobraPGService elindult:" + DateTime.Now);
            }
             
        }

        protected override void OnStop()
        {
            FileStream LogFile = new FileStream("Log.Txt", FileMode.OpenOrCreate);
            StreamWriter LogWriter = new StreamWriter(LogFile);
            LogWriter.WriteLine("A CobraPGService leállt:" + DateTime.Now);
        }
    }
}
