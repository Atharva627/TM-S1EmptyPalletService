using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtsWmsS1EmptyPalletService
{
    public partial class AtsWmsS1EmptyPalletService : ServiceBase
    {
        static string className = "AtsWmsEmptyPalletAutoCallServiceService";
        private static readonly ILog Log = LogManager.GetLogger(className);

        public AtsWmsS1EmptyPalletService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                Log.Debug("OnStart :: AtsWmsEmptyPalletAutoCallService in OnStart....");

                try
                {
                    XmlConfigurator.Configure();
                    try
                    {
                        AtsWmsEmptyPalletAutoCallServiceTaskThread();
                    }
                    catch (Exception ex)
                    {
                        Log.Error("OnStart :: Exception occured while AtsWmsEmptyPalletAutoCallServiceTaskThread  threads task :: " + ex.Message);
                    }
                    Log.Debug("OnStart :: AtsWmsEmptyPalletAutoCallServiceTaskThread in OnStart ends..!!");

                    //XmlConfigurator.Configure();
                    //Thread staThread = new Thread(new ThreadStart(AtsWmsEmptyPalletAutoCallServiceTaskThread));
                    //staThread.SetApartmentState(ApartmentState.STA);
                    //staThread.Start();
                    //Log.Debug("OnStart :: AtsWmsS1EmptyPalletServiceTaskThread in OnStart ends..!!");
                }
                catch (Exception ex)
                {
                    Log.Error("OnStart :: Exception occured in OnStart :: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Log.Error("OnStart :: Exception occured in OnStart :: " + ex.Message);
            }
        }


        public async void AtsWmsEmptyPalletAutoCallServiceTaskThread()
        {
            await Task.Run(() =>
            {
                try
                {
                    AtsWmsS1EmptyPalletServiceDetails AtsWmsS1EmptyPalletServiceDetailsInstance = new AtsWmsS1EmptyPalletServiceDetails();
                    AtsWmsS1EmptyPalletServiceDetailsInstance.startOperation();
                }
                catch (Exception ex)
                {
                    Log.Error("TestService :: Exception in AtsWmsEquipmentAlarmTaskThread :: " + ex.Message);
                }

            });
        }
        //public void AtsWmsEmptyPalletAutoCallServiceTaskThread()
        //{
        //    try
        //    {
        //        AtsWmsS1EmptyPalletServiceDetails AtsWmsS1EmptyPalletServiceDetailsInstance = new AtsWmsS1EmptyPalletServiceDetails();
        //        AtsWmsS1EmptyPalletServiceDetailsInstance.startOperation();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("TestService :: Exception in AtsWmsS1EmptyPalletServiceTaskThread :: " + ex.Message);
        //    }
        //}
        protected override void OnStop()
        {
            try
            {
                Log.Debug("OnStop :: AtsWmsEmptyPalletAutoCallService in OnStop ends..!!");
            }
            catch (Exception ex)
            {
                Log.Error("OnStop :: Exception occured in OnStop :: " + ex.Message);
            }
        }
    }
}
