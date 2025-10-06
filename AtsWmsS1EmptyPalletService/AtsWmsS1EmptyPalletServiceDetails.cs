using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtsWmsS1EmptyPalletService.ats_tata_metallics_dbDataSetTableAdapters;
using static AtsWmsS1EmptyPalletService.ats_tata_metallics_dbDataSet;
using System.Net.NetworkInformation;
using OPCAutomation;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace AtsWmsS1EmptyPalletService
{
    class AtsWmsS1EmptyPalletServiceDetails
    {

        #region Data Tables 
        ats_wms_manual_outfeed_mission_detailsDataTable ats_wms_manual_outfeed_mission_detailsDataTableDT = null;
        ats_wms_current_stock_detailsDataTable ats_wms_current_stock_detailsDataTableDT = null;
        ats_wms_master_pallet_informationDataTable ats_wms_master_pallet_informationDataTableDT = null;
        ats_wms_master_position_detailsDataTable ats_wms_master_position_detailsDataTableDT = null;
        ats_wms_master_plc_connection_detailsDataTable ats_wms_master_plc_connection_detailsDataTableDT = null;
        ats_wms_current_stock_detailsDataTable ats_wms_current_stock_detailsDataTableEmptyPalletDT = null;
        ats_wms_current_stock_detailsDataTable ats_wms_current_stock_detailsDataTableEmptyPalletDT1 = null;
        ats_wms_outfeed_mission_runtime_detailsDataTable ats_wms_outfeed_mission_runtime_detailsDataTableDT = null;
        ats_wms_loading_stations_tag_detailsDataTable ats_wms_loading_stations_tag_detailsDataTableDT = null;
        ats_wms_master_station_detailsDataTable ats_wms_master_station_detailsDataTableDT = null;
        ats_wms_master_pallet_type_detailsDataTable ats_wms_master_pallet_type_detailsDataTableDT = null;
        ats_wms_master_position_detailsDataTable ats_wms_master_position_detailsDataTableFrontPositionEmptyDT = null;
        ats_wms_current_stock_detailsDataTable ats_wms_current_stock_detailsDataTableFetchData = null;
        ats_wms_master_position_detailsDataTable ats_wms_master_position_detailsDataTableLocationDT = null;
        ats_wms_outfeed_mission_runtime_detailsDataTable ats_wms_outfeed_mission_runtime_detailsDataTableCheckReadyIn_ProgressDT = null;
        ats_wms_master_position_detailsDataTable ats_wms_master_position_detailsDataTableLocationIsMaterialLoadedDT = null;
        ats_wms_outfeed_mission_runtime_detailsDataTable ats_wms_outfeed_mission_runtime_detailsDataTableDTPalletStatus = null;
        ats_wms_master_rack_detailsDataTable ats_wms_master_rack_detailsDataTableDT = null;
        ats_wms_outfeed_mission_runtime_detailsDataTable ats_wms_outfeed_mission_runtime_detailsDataTableRackINPROGRESSDT = null;
        ats_wms_infeed_mission_runtime_detailsDataTable ats_wms_infeed_mission_runtime_detailsDataTableRackINPROGRESSDT = null;
        ats_wms_transfer_pallet_mission_runtime_detailsDataTable ats_wms_transfer_pallet_mission_runtime_detailsDataTableRackINPROGRESSDT = null;

        #endregion


        #region Table Adapters 
        ats_wms_manual_outfeed_mission_detailsTableAdapter ats_wms_manual_outfeed_mission_detailsTableAdapterInstance = new ats_wms_manual_outfeed_mission_detailsTableAdapter();
        ats_wms_current_stock_detailsTableAdapter ats_wms_current_stock_detailsTableAdapterInstance = new ats_wms_current_stock_detailsTableAdapter();
        ats_wms_master_pallet_informationTableAdapter ats_wms_master_pallet_informationTableAdapterInstance = new ats_wms_master_pallet_informationTableAdapter();
        ats_wms_master_position_detailsTableAdapter ats_wms_master_position_detailsDataTableInstance = new ats_wms_master_position_detailsTableAdapter();
        ats_wms_master_plc_connection_detailsTableAdapter ats_wms_master_plc_connection_detailsTableAdapterInstance = new ats_wms_master_plc_connection_detailsTableAdapter();
        ats_wms_outfeed_mission_runtime_detailsTableAdapter ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance = new ats_wms_outfeed_mission_runtime_detailsTableAdapter();
        //ats_wms_master_area_detailsTableAdapter ats_wms_master_area_detailsTableAdapterInstance = new ats_wms_master_area_detailsTableAdapter();
        ats_wms_loading_stations_tag_detailsTableAdapter ats_wms_loading_stations_tag_detailsTableAdapterInstance = new ats_wms_loading_stations_tag_detailsTableAdapter();
        ats_wms_master_station_detailsTableAdapter ats_wms_master_station_detailsTableAdapterInstance = new ats_wms_master_station_detailsTableAdapter();
        ats_wms_master_pallet_type_detailsTableAdapter ats_wms_master_pallet_type_detailsTableAdapterInstance = new ats_wms_master_pallet_type_detailsTableAdapter();
        ats_wms_master_position_detailsTableAdapter ats_wms_master_position_detailsTableAdapterInstance = new ats_wms_master_position_detailsTableAdapter();
        ats_wms_current_stock_detailsTableAdapter ats_wms_current_stock_detailsTableAdapterInstance2 = new ats_wms_current_stock_detailsTableAdapter();
        ats_wms_master_position_detailsTableAdapter ats_wms_master_position_detailsTableAdapterInstance3 = new ats_wms_master_position_detailsTableAdapter();
        ats_wms_master_rack_detailsTableAdapter ats_wms_master_rack_detailsTableAdapterInstance = new ats_wms_master_rack_detailsTableAdapter();
        ats_wms_infeed_mission_runtime_detailsTableAdapter ats_wms_infeed_mission_runtime_detailsTableAdapterInstance = new ats_wms_infeed_mission_runtime_detailsTableAdapter();
        ats_wms_transfer_pallet_mission_runtime_detailsTableAdapter ats_wms_transfer_pallet_mission_runtime_detailsTableAdapterInstance = new ats_wms_transfer_pallet_mission_runtime_detailsTableAdapter();
        #endregion

        #region PLC PING VARIABLE   
        //private string IP_ADDRESS = System.Configuration.ConfigurationManager.AppSettings["IP_ADDRESS"]; //2
        private Ping pingSenderForThisConnection = null;
        private PingReply replyForThisConnection = null;
        private Boolean pingStatus = false;
        private int serverPingStatusCount = 0;
        #endregion

        #region KEPWARE VARIABLES

        /* Kepware variable*/

        OPCServer ConnectedOpc = new OPCServer();

        Array OPCItemIDs = Array.CreateInstance(typeof(string), 100);
        Array ItemServerHandles = Array.CreateInstance(typeof(Int32), 100);
        Array ItemServerErrors = Array.CreateInstance(typeof(Int32), 100);
        Array ClientHandles = Array.CreateInstance(typeof(Int32), 100);
        Array RequestedDataTypes = Array.CreateInstance(typeof(Int16), 100);
        Array AccessPaths = Array.CreateInstance(typeof(string), 100);
        Array ItemServerValues = Array.CreateInstance(typeof(string), 100);
        OPCGroup OpcGroupNames4;
        object aAGS11;
        object bAGS11;

        // Connection string
        static string plcServerConnectionString = null;

        #endregion

        #region Global Variables
        static string className = "AtsWmsS1EmptyPalletServiceDetails";
        private static readonly ILog Log = LogManager.GetLogger(className);
        private System.Timers.Timer StationCurrentPalletTimer = null;

        private string IP_ADDRESS = "172.16.67.60";
        int stationId = 0;
        int areaId = 1;
        string emptyPalletRequest = "";
        #endregion

        public void startOperation()
        {
            try
            {
                Log.Debug("1");
                //Timer 
                StationCurrentPalletTimer = new System.Timers.Timer();
                //Running the function after 5 sec 
                StationCurrentPalletTimer.Interval = (1000);
                //After 1 sec timer will elapse and DataFetchDetailsOperation function will be called 
                StationCurrentPalletTimer.Elapsed += new System.Timers.ElapsedEventHandler(AtsWmsS1EmptyPalletServiceDetailsOperation);
                //Timr autoreset flase
                StationCurrentPalletTimer.AutoReset = false;
                //starting the timer
                StationCurrentPalletTimer.Start();
            }
            catch (Exception ex)
            {
                Log.Error("startOperation :: Exception Occure in StationCurrentPalletTimer" + ex.Message);
            }
        }


        public void AtsWmsS1EmptyPalletServiceDetailsOperation(object sender, EventArgs args)
        {
            try
            {
                Log.Debug("2");
                try
                {
                    //Stopping the timer to start the below operation
                    StationCurrentPalletTimer.Stop();
                }
                catch (Exception ex)
                {
                    Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occure while stopping the timer :: " + ex.Message + "StackTrace  :: " + ex.StackTrace);
                }

                try
                {
                    //Fetching PLC data from DB by sending PLC connection IP address
                    ats_wms_master_plc_connection_detailsDataTableDT = ats_wms_master_plc_connection_detailsTableAdapterInstance.GetDataByPLC_CONNECTION_IP_ADDRESS(IP_ADDRESS);
                    Log.Debug("2.1");
                }
                catch (Exception ex)
                {
                    Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception Occure while reading machine datasource connection details from the database :: " + ex.Message + "StackTrace :: " + ex.StackTrace);
                }


                // Check PLC Ping Status
                try
                {
                    //Checking the PLC ping status by a method
                    pingStatus = checkPlcPingRequest();
                    Log.Debug("2.2");
                }
                catch (Exception ex)
                {
                    Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception while checking plc ping status :: " + ex.Message + " stactTrace :: " + ex.StackTrace);
                }

                if (pingStatus == true)
                //if (true)
                {
                    Log.Debug("3");
                    //checking if the PLC data from DB is retrived or not

                    if (ats_wms_master_plc_connection_detailsDataTableDT != null && ats_wms_master_plc_connection_detailsDataTableDT.Count != 0)
                    //if (true)
                    {
                        plcServerConnectionString = ats_wms_master_plc_connection_detailsDataTableDT[0].PLC_CONNECTION_URL;
                        try
                        {
                            //Calling the connection method for PLC connection
                            OnConnectPLC();
                        }
                        catch (Exception ex)
                        {
                            Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception while connecting to plc :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                        }
                        try
                        {
                            // Check the PLC connected status
                            if (ConnectedOpc.ServerState.ToString().Equals("1"))
                            //if (true)
                            {
                                Log.Debug("4");
                                //Bussiness logic

                                #region oldCode

                                // check that loading station conveyor is empty 
                                {



                                    {
                                        try
                                        {
                                            Log.Debug("A1 :: Getting loading station data");
                                            ats_wms_loading_stations_tag_detailsDataTableDT = ats_wms_loading_stations_tag_detailsTableAdapterInstance.GetDataBySTATION_IDBetween(1, 3);


                                            if (ats_wms_loading_stations_tag_detailsDataTableDT != null && ats_wms_loading_stations_tag_detailsDataTableDT.Count > 0)
                                            {

                                                Log.Debug("A2 :: Found Count " + ats_wms_loading_stations_tag_detailsDataTableDT.Count);
                                                for (int i = 0; i < ats_wms_loading_stations_tag_detailsDataTableDT.Count; i++)
                                                {
                                                    Thread.Sleep(100);
                                                    try
                                                    {
                                                        try
                                                        {
                                                            Log.Debug("A3 :: Checking emptyPalletRequest For Drop station :: " + ats_wms_loading_stations_tag_detailsDataTableDT[i].STATION_NAME);
                                                            emptyPalletRequest = readTag(ats_wms_loading_stations_tag_detailsDataTableDT[i].DROP_POSITION_IS_READY_TAG);



                                                            stationId = ats_wms_loading_stations_tag_detailsDataTableDT[i].STATION_ID;

                                                            Log.Debug("Station Id :: " + stationId);
                                                            Log.Debug("A4 :: Checking if Empty pallet outfeed is inprogress");
                                                            try
                                                            {
                                                                ats_wms_outfeed_mission_runtime_detailsDataTableDT = ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.GetDataByPALLET_STATUS_IDAndOUTFEED_MISSION_STATUS1OrOUTFEED_MISSION_STATUS2(3, "READY", "IN_PROGRESS");

                                                                if (ats_wms_outfeed_mission_runtime_detailsDataTableDT != null && ats_wms_outfeed_mission_runtime_detailsDataTableDT.Count == 0)
                                                                {
                                                                    Log.Debug("A5 :: Checking if empty psallet outfeed is in progress for station :: " + ats_wms_loading_stations_tag_detailsDataTableDT[i].STATION_NAME);
                                                                    try
                                                                    {
                                                                        ats_wms_outfeed_mission_runtime_detailsDataTableCheckReadyIn_ProgressDT = ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.GetDataByOUTFEED_MISSION_STATUSAndDESTINATION("READY", "IN_PROGRESS", ats_wms_loading_stations_tag_detailsDataTableDT[i].STATION_NAME);

                                                                        if (ats_wms_outfeed_mission_runtime_detailsDataTableCheckReadyIn_ProgressDT != null && ats_wms_outfeed_mission_runtime_detailsDataTableCheckReadyIn_ProgressDT.Count == 0)
                                                                        {
                                                                            Log.Debug(" Count is Zero");


                                                                            Log.Debug("A6");
                                                                            if (emptyPalletRequest.Equals("True"))
                                                                            {
                                                                                Log.Debug("A7 :: emptyPalletRequest");

                                                                                //string loadingStationConveyorIdle = "";
                                                                                try
                                                                                {
                                                                                    Log.Debug("A8 :: Checking ats_wms_master_station_detailsDataTableDT for station ID :: " + stationId);
                                                                                    try
                                                                                    {
                                                                                        // Getting Pallet type id for corresponding Station (CS)
                                                                                        ats_wms_master_station_detailsDataTableDT = ats_wms_master_station_detailsTableAdapterInstance.GetDataBySTATION_ID(stationId);
                                                                                        Log.Debug("A8:: GOT Pallet type id for corresponding Station (CS)");

                                                                                        //Getting Pallet Type for respective Pallet type ID
                                                                                        ats_wms_master_pallet_type_detailsDataTableDT = ats_wms_master_pallet_type_detailsTableAdapterInstance.GetDataByPALLET_TYPE_ID(ats_wms_master_station_detailsDataTableDT[0].PALLET_TYPE_ID);
                                                                                        Log.Debug("A9:: GOT Pallet Type for respective Pallet type ID");


                                                                                   
                                                                                        try
                                                                                        {
                                                                                            Log.Debug("Checking empty pallet availability in current stock for the required pallet type");
                                                                                            ats_wms_current_stock_detailsDataTableDT = ats_wms_current_stock_detailsTableAdapterInstance.GetDataByPALLET_STATUS_IDAndPALLET_CODENotEqualsAndPALLET_TYPEAndFLOOR_IDLessThanAndPOSITION_IDAsc(3, "NA", ats_wms_master_pallet_type_detailsDataTableDT[0].PALLET_TYPE, 6);


                                                                                            if (ats_wms_current_stock_detailsDataTableDT != null && ats_wms_current_stock_detailsDataTableDT.Count > 0)
                                                                                            {
                                                                                                Log.Debug("A10 :: Found the pallet in current stock");
                                                                                                for (int j = 0; j < ats_wms_current_stock_detailsDataTableDT.Count; j++)
                                                                                                {
                                                                                                    //var outfeed_data = ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.GetDataByabbbbcd(3, stationId);

                                                                                                    //if (outfeed_data[0].RACK_ID == ats_wms_current_stock_detailsDataTableDT[j].RACK_ID)
                                                                                                    //{

                                                                                                    //}

                                                                                                    try
                                                                                                    {
                                                                                                        Log.Debug("14 Checking if any infeed outfeed or transfer mission is in_progress in the rack");
                                                                                                        ats_wms_infeed_mission_runtime_detailsDataTableRackINPROGRESSDT = ats_wms_infeed_mission_runtime_detailsTableAdapterInstance.GetDataByRACK_IDAndINFEED_MISSION_STATUSOrINFEED_MISSION_STATUS1(ats_wms_current_stock_detailsDataTableDT[j].RACK_ID, "READY", "IN_PROGRESS");

                                                                                                        ats_wms_outfeed_mission_runtime_detailsDataTableRackINPROGRESSDT = ats_wms_outfeed_mission_runtime_detailsTableAdapterInstance.GetDataByRACK_IDAndOUTFEED_MISSION_STATUSOrOUTFEED_MISSION_STATUS1(ats_wms_current_stock_detailsDataTableDT[j].RACK_ID, "READY", "IN_PROGRESS");

                                                                                                        ats_wms_transfer_pallet_mission_runtime_detailsDataTableRackINPROGRESSDT = ats_wms_transfer_pallet_mission_runtime_detailsTableAdapterInstance.GetDataByRACK_IDAndTRANSFER_MISSION_STATUSOrTRANSFER_MISSION_STATUS1(ats_wms_current_stock_detailsDataTableDT[j].RACK_ID, "READY", "IN_PROGRESS");


                                                                                                        if (ats_wms_infeed_mission_runtime_detailsDataTableRackINPROGRESSDT != null && ats_wms_infeed_mission_runtime_detailsDataTableRackINPROGRESSDT.Count == 0 &&
                                                                                                            ats_wms_outfeed_mission_runtime_detailsDataTableRackINPROGRESSDT != null && ats_wms_outfeed_mission_runtime_detailsDataTableRackINPROGRESSDT.Count == 0 &&
                                                                                                            ats_wms_transfer_pallet_mission_runtime_detailsDataTableRackINPROGRESSDT != null && ats_wms_transfer_pallet_mission_runtime_detailsDataTableRackINPROGRESSDT.Count == 0)
                                                                                                        {

                                                                                                            try
                                                                                                            {
                                                                                                                Log.Debug("A11 :: Checking if the maniual mission data added");
                                                                                                                ats_wms_manual_outfeed_mission_detailsDataTableDT = ats_wms_manual_outfeed_mission_detailsTableAdapterInstance.GetDataByPALLET_INFORMATION_IDAndIS_MISSION_GENERATED(ats_wms_current_stock_detailsDataTableDT[j].PALLET_INFORMATION_ID, 0);


                                                                                                                //Log.Debug("8");
                                                                                                                if (ats_wms_manual_outfeed_mission_detailsDataTableDT != null && ats_wms_manual_outfeed_mission_detailsDataTableDT.Count == 0)
                                                                                                                {
                                                                                                                    Log.Debug("A12 :: Manual mission data not added :: Checking if the rack is active");

                                                                                                                    try
                                                                                                                    {
                                                                                                                        ats_wms_master_rack_detailsDataTableDT = ats_wms_master_rack_detailsTableAdapterInstance.GetDataByRACK_IDAndRACK_IS_ACTIVE(ats_wms_current_stock_detailsDataTableDT[j].RACK_ID, 1);



                                                                                                                        if (ats_wms_master_rack_detailsDataTableDT != null && ats_wms_master_rack_detailsDataTableDT.Count > 0)
                                                                                                                        {
                                                                                                                            Log.Debug("A13 Found rack is active :: cHECKING FOR POSITION DETAILS HAVING PSLLETS IN THE RACK :: " + ats_wms_current_stock_detailsDataTableDT[j].RACK_ID);

                                                                                                                            try
                                                                                                                            {
                                                                                                                                //ats_wms_master_position_detailsDataTableDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByRACK_IDAndPOSITION_IS_EMPTY(ats_wms_current_stock_detailsDataTableDT[j].RACK_ID, 0);
                                                                                                                                ats_wms_master_position_detailsDataTableDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByRACK_IDAndPOSITION_IS_EMPTYAndPOSITION_IS_ACTIVE(ats_wms_current_stock_detailsDataTableDT[j].RACK_ID, 0, 1);


                                                                                                                                if (ats_wms_master_position_detailsDataTableDT != null && ats_wms_master_position_detailsDataTableDT.Count > 0)
                                                                                                                                {
                                                                                                                                    Log.Debug("A14 :: Checking front position is empty");

                                                                                                                                    try
                                                                                                                                    {
                                                                                                                                        ats_wms_master_position_detailsDataTableFrontPositionEmptyDT = ats_wms_master_position_detailsTableAdapterInstance.GetDataByRACK_IDAndPOSITION_IDLessThan(ats_wms_current_stock_detailsDataTableDT[j].RACK_ID, ats_wms_current_stock_detailsDataTableDT[j].POSITION_ID);


                                                                                                                                        Log.Debug("A15 ats_wms_master_position_detailsDataTableFrontPositionEmptyDT.Count :: " + ats_wms_master_position_detailsDataTableFrontPositionEmptyDT.Count);


                                                                                                                                        if (ats_wms_master_position_detailsDataTableFrontPositionEmptyDT != null && ((ats_wms_master_position_detailsDataTableFrontPositionEmptyDT.Count > 0 && ats_wms_master_position_detailsDataTableFrontPositionEmptyDT[0].POSITION_IS_ALLOCATED == 0) || (ats_wms_master_position_detailsDataTableFrontPositionEmptyDT.Count == 0)))
                                                                                                                                        {
                                                                                                                                            try
                                                                                                                                            {
                                                                                                                                                Log.Debug("A16 :: Found front position empty");
                                                                                                                                                ats_wms_master_pallet_informationDataTableDT = ats_wms_master_pallet_informationTableAdapterInstance.GetDataByPALLET_INFORMATION_ID(ats_wms_current_stock_detailsDataTableDT[j].PALLET_INFORMATION_ID);


                                                                                                                                                if (ats_wms_master_pallet_informationDataTableDT != null && ats_wms_master_pallet_informationDataTableDT.Count > 0)
                                                                                                                                                {
                                                                                                                                                    Log.Debug("A17:: Pallet information found for the pallet information ID :: " + ats_wms_current_stock_detailsDataTableDT[j].PALLET_INFORMATION_ID + " :: Checking if mission outfeed is generated");
                                                                                                                                                    if (ats_wms_master_pallet_informationDataTableDT[0].IS_OUTFEED_MISSION_GENERATED == 0)
                                                                                                                                                    {
                                                                                                                                                        Log.Debug("A18 :: Outfeed mission is not already generated");
                                                                                                                                                        //rack with single pallet

                                                                                                                                                        Log.Debug("A19 :: Checking if the rack has the pallet count 1 or 2");
                                                                                                                                                        if (ats_wms_master_position_detailsDataTableDT != null && ats_wms_master_position_detailsDataTableDT.Count < 2)
                                                                                                                                                        {
                                                                                                                                                            //generate the mission of the 0th row of the current stock position
                                                                                                                                                            //Log.Debug("15.0 :: Position ID" + ats_wms_master_position_detailsDataTableDT[0].POSITION_ID + " Position is Active= " + ats_wms_master_position_detailsDataTableDT[0].POSITION_IS_ACTIVE);
                                                                                                                                                            Log.Debug("A19 :: Found the rack with single pallet");
                                                                                                                                                            try
                                                                                                                                                            {
                                                                                                                                                                Log.Debug("20 :: Data Inserting for position ID :: " + ats_wms_current_stock_detailsDataTableDT[j].POSITION_ID);
                                                                                                                                                                ats_wms_manual_outfeed_mission_detailsTableAdapterInstance.Insert(
                                                                                                                                                                   ats_wms_current_stock_detailsDataTableDT[j].PALLET_INFORMATION_ID,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].PALLET_CODE,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].POSITION_ID,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].POSITION_NAME,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].NOMENCLATURE,
                                                                                                                                                                            0,
                                                                                                                                                                            ats_wms_master_station_detailsDataTableDT[0].STATION_NAME,
                                                                                                                                                                            1,
                                                                                                                                                                            "Auto",
                                                                                                                                                                            DateTime.Now,
                                                                                                                                                                            stationId,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].PALLET_TYPE,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].STACKER_ID,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].PALLET_STATUS_ID);

                                                                                                                                                                Log.Debug("A21 :: Data Inserted :: Updating Manual Dispatch");

                                                                                                                                                                try
                                                                                                                                                                {
                                                                                                                                                                    ats_wms_master_position_detailsDataTableInstance.UpdateIS_MANUAL_DISPATCHWherePOSITION_ID(1, ats_wms_current_stock_detailsDataTableDT[j].POSITION_ID);
                                                                                                                                                                }
                                                                                                                                                                catch (Exception ex)
                                                                                                                                                                {
                                                                                                                                                                    Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while updating manual dispatch 1 ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                                                                                                                }

                                                                                                                                                                Log.Debug("Pallet Code :: " + ats_wms_current_stock_detailsDataTableDT[j].PALLET_CODE);
                                                                                                                                                                Log.Debug("Pallet Information ID :: " + ats_wms_current_stock_detailsDataTableDT[j].PALLET_INFORMATION_ID);
                                                                                                                                                                Log.Debug("Position ID :: " + ats_wms_current_stock_detailsDataTableDT[j].POSITION_ID);
                                                                                                                                                                Log.Debug("Position ID :: " + ats_wms_current_stock_detailsDataTableDT[j].POSITION_NAME);
                                                                                                                                                                Thread.Sleep(3000);
                                                                                                                                                                break;
                                                                                                                                                            }
                                                                                                                                                            catch (Exception ex)
                                                                                                                                                            {
                                                                                                                                                                Log.Error("atsWmsS1EmptyPalletServiceOperation :: Exception occured while inserting empty pallet outfeed mission details ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                                                                                                            }

                                                                                                                                                        }
                                                                                                                                                        //rack with 2 pallets
                                                                                                                                                        else if (ats_wms_master_position_detailsDataTableDT != null && ats_wms_master_position_detailsDataTableDT.Count == 2)
                                                                                                                                                        {
                                                                                                                                                            //generate the mission of the 0th row of the current stock position
                                                                                                                                                            Log.Debug("A22 :: Found the tack with 2 pallets and the position ID :: " + ats_wms_current_stock_detailsDataTableDT[j].POSITION_ID);

                                                                                                                                                            try
                                                                                                                                                            {
                                                                                                                                                                Log.Debug("A23 :: Data Inserting");
                                                                                                                                                                ats_wms_manual_outfeed_mission_detailsTableAdapterInstance.Insert(
                                                                                                                                                                   ats_wms_current_stock_detailsDataTableDT[j].PALLET_INFORMATION_ID,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].PALLET_CODE,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].POSITION_ID,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].POSITION_NAME,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].NOMENCLATURE,
                                                                                                                                                                            0,
                                                                                                                                                                            ats_wms_master_station_detailsDataTableDT[0].STATION_NAME,
                                                                                                                                                                            1,
                                                                                                                                                                            "Auto",
                                                                                                                                                                            DateTime.Now,
                                                                                                                                                                            stationId,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].PALLET_TYPE,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].STACKER_ID,
                                                                                                                                                                            ats_wms_current_stock_detailsDataTableDT[j].PALLET_STATUS_ID);

                                                                                                                                                                Log.Debug("A24 :: Data Inserted :: Updating Manual Dispatch");

                                                                                                                                                                try
                                                                                                                                                                {
                                                                                                                                                                    ats_wms_master_position_detailsDataTableInstance.UpdateIS_MANUAL_DISPATCHWherePOSITION_ID(1, ats_wms_current_stock_detailsDataTableDT[j].POSITION_ID);
                                                                                                                                                                }
                                                                                                                                                                catch (Exception ex)
                                                                                                                                                                {
                                                                                                                                                                    Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while updating manual discpatch 1 ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                                                                                                                }

                                                                                                                                                                Log.Debug("Pallet Code :: " + ats_wms_current_stock_detailsDataTableDT[j].PALLET_CODE);
                                                                                                                                                                Log.Debug("Pallet Information ID :: " + ats_wms_current_stock_detailsDataTableDT[j].PALLET_INFORMATION_ID);
                                                                                                                                                                Log.Debug("Position ID :: " + ats_wms_current_stock_detailsDataTableDT[j].POSITION_ID);
                                                                                                                                                                Log.Debug("Position ID :: " + ats_wms_current_stock_detailsDataTableDT[j].POSITION_NAME);
                                                                                                                                                                Thread.Sleep(3000);
                                                                                                                                                                break;
                                                                                                                                                            }
                                                                                                                                                            catch (Exception ex)
                                                                                                                                                            {
                                                                                                                                                                Log.Error("atsWmsS1EmptyPalletServiceOperation :: Exception occured while inserting empty pallet outfeed mission details ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                                                                                                            }

                                                                                                                                                        }

                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                            catch (Exception ex)
                                                                                                                                            {
                                                                                                                                                Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while getting pallet information details ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                    catch (Exception ex)
                                                                                                                                    {
                                                                                                                                        Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while getting front position details ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                            catch (Exception ex)
                                                                                                                            {
                                                                                                                                Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while getting position details ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                    catch (Exception ex)
                                                                                                                    {
                                                                                                                        Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while getting rack details ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                            catch (Exception ex)
                                                                                                            {
                                                                                                                Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while getting manual outfeed mission ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                    catch (Exception ex)
                                                                                                    {
                                                                                                        Log.Error("atsWmsS1EmptyPalletServiceOperation :: Exception occured while Checking if any infeed outfeed or transfer mission is in_progress in the rack ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        catch (Exception ex)
                                                                                        {
                                                                                            Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while getting current stock details ::" + ex.Message + " StackTrace:: " + ex.StackTrace); ;
                                                                                        }
                                                                                    }
                                                                                    catch (Exception ex)
                                                                                    {
                                                                                        Log.Error("atsWmsS1EmptyPalletServiceOperation :: Exception occured while getting outfeed mission details ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                                    }

                                                                                    // }
                                                                                }
                                                                                catch (Exception ex)
                                                                                {

                                                                                    Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while reading  ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                                }

                                                                            }
                                                                            else
                                                                            {
                                                                                continue;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            continue;
                                                                        }
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while getting empty pallet outfeed mission for station ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                                    }
                                                                }
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while getting empty pallet outfeed mission ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while reading emptyPalletRequest ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {

                                                        int hResult = System.Runtime.InteropServices.Marshal.GetHRForException(ex);
                                                        string comError = (ex is System.Runtime.InteropServices.COMException) ? ((System.Runtime.InteropServices.COMException)ex).ErrorCode.ToString() : "No COM error";

                                                        Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception while emptyPalletRequest :: " + ex.Message
                                                        + " HResult :: " + hResult
                                                        + " COM Component Error :: " + comError
                                                        + " stackTrace :: " + ex.StackTrace);
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while getting loading station data  ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                                        }
                                    }
                                }

                                #endregion
                            }
                            else
                            {
                                //Reconnect to plc
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error("AtsWmsS1EmptyPalletServiceDetailsOperation :: Exception occured while checking server state is 1 ::" + ex.Message + " StackTrace:: " + ex.StackTrace);
                        }
                    }
                    else
                    {
                        //Reconnect to plc, Check Ip address, url
                    }
                }
            }
            catch (Exception ex)
            {

                Log.Error("startOperation :: Exception occured while stopping timer :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
            }
            finally
            {
                try
                {
                    //Starting the timer again for the next iteration
                    StationCurrentPalletTimer.Start();
                }
                catch (Exception ex1)
                {
                    Log.Error("startOperation :: Exception occured while stopping timer :: " + ex1.Message + " stackTrace :: " + ex1.StackTrace);
                }
            }

        }


        #region Ping funcationality

        public Boolean checkPlcPingRequest()
        {
            //Log.Debug("IprodPLCMachineXmlGenOperation :: Inside checkServerPingRequest");

            try
            {
                try
                {
                    pingSenderForThisConnection = new Ping();
                    replyForThisConnection = pingSenderForThisConnection.Send(IP_ADDRESS);
                }
                catch (Exception ex)
                {
                    Log.Error("checkPlcPingRequest :: for IP :: " + IP_ADDRESS + " Exception occured while sending ping request :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                    replyForThisConnection = null;
                }

                if (replyForThisConnection != null && replyForThisConnection.Status == IPStatus.Success)
                {
                    //Log.Debug("checkPlcPingRequest :: for IP :: " + IP_ADDRESS + " Ping success :: " + replyForThisConnection.Status.ToString());
                    return true;
                }
                else
                {
                    //Log.Debug("checkPlcPingRequest :: for IP :: " + IP_ADDRESS + " Ping failed. ");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Error("checkPlcPingRequest :: for IP :: " + IP_ADDRESS + " Exception while checking ping request :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region Read and Write PLC tag

        [HandleProcessCorruptedStateExceptions]
        public string readTag(string tagName)
        {

            try
            {
                //Log.Debug("IprodPLCCommunicationOperation :: Inside readTag.");

                // Set PLC tag
                OPCItemIDs.SetValue(tagName, 1);
                //Log.Debug("readTag :: Plc tag is configured for plc group.");

                // remove all group
                ConnectedOpc.OPCGroups.RemoveAll();
                //Log.Debug("readTag :: Remove all group.");

                // Kepware configuration                
                OpcGroupNames4 = ConnectedOpc.OPCGroups.Add("AtsWmsS1EmptyPalletServiceDetailsGroup");
                OpcGroupNames4.DeadBand = 0;
                OpcGroupNames4.UpdateRate = 500;
                OpcGroupNames4.IsSubscribed = true;
                OpcGroupNames4.IsActive = true;
                OpcGroupNames4.OPCItems.AddItems(1, ref OPCItemIDs, ref ClientHandles, out ItemServerHandles, out ItemServerErrors, RequestedDataTypes, AccessPaths);
                //Log.Debug("readTag :: Kepware properties configuration is complete.");

                // Read tag
                OpcGroupNames4.SyncRead((short)OPCAutomation.OPCDataSource.OPCDevice, 1, ref
                   ItemServerHandles, out ItemServerValues, out ItemServerErrors, out aAGS11, out bAGS11);

                //Log.Debug("readTag ::  tag name :: " + tagName + " tag value :: " + Convert.ToString(ItemServerValues.GetValue(1)));

                if (Convert.ToString(ItemServerValues.GetValue(1)).Equals("True"))
                {
                    Log.Debug("readTag :: Found and Return True");
                    return "True";
                }
                else if (Convert.ToString(ItemServerValues.GetValue(1)).Equals("False"))
                {
                    Log.Debug("readTag :: Found and Return False");
                    return "False";
                }
                else
                {
                    Log.Debug("readTag :: Found read value :: " + (ItemServerValues.GetValue(1)));
                    return Convert.ToString(ItemServerValues.GetValue(1));

                }

            }
            catch (Exception ex)
            {
                Log.Error("readTag :: Exception while reading plc tag :: " + tagName + " :: " + ex.Message);
                OnConnectPLC();
            }

            Log.Debug("readTag :: Return False.. retun null.");

            return "False";
        }

        [HandleProcessCorruptedStateExceptions]
        public Boolean writeTag(string tagName, string tagValue)
        {

            try
            {
                Log.Debug("IprodGiveMissionToStacker :: Inside writeTag.");

                // Set PLC tag
                OPCItemIDs.SetValue(tagName, 1);
                //Log.Debug("writeTag :: Plc tag is configured for plc group.");

                // remove all group
                ConnectedOpc.OPCGroups.RemoveAll();
                //Log.Debug("writeTag :: Remove all group.");

                // Kepware configuration                  
                OpcGroupNames4 = ConnectedOpc.OPCGroups.Add("AtsWmsS1EmptyPalletServiceDetailsGroup");
                OpcGroupNames4.DeadBand = 0;
                OpcGroupNames4.UpdateRate = 500;
                OpcGroupNames4.IsSubscribed = true;
                OpcGroupNames4.IsActive = true;
                OpcGroupNames4.OPCItems.AddItems(1, ref OPCItemIDs, ref ClientHandles, out ItemServerHandles, out ItemServerErrors, RequestedDataTypes, AccessPaths);
                //Log.Debug("writeTag :: Kepware properties configuration is complete.");

                // read plc tags
                OpcGroupNames4.SyncRead((short)OPCAutomation.OPCDataSource.OPCDevice, 1, ref
                   ItemServerHandles, out ItemServerValues, out ItemServerErrors, out aAGS11, out bAGS11);

                // Add tag value
                ItemServerValues.SetValue(tagValue, 1);

                // Write tag
                OpcGroupNames4.SyncWrite(1, ref ItemServerHandles, ref ItemServerValues, out ItemServerErrors);

                return true;

            }
            catch (Exception ex)
            {
                Log.Error("writeTag :: Exception while writing mission data in the plc tag :: " + tagName + " :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
                OnConnectPLC();

            }

            return false;

        }

        #endregion

        #region Connect and Disconnect PLC

        private void OnConnectPLC()
        {

            Log.Debug("OnConnectPLC :: inside OnConnectPLC");

            try
            {
                // Connection url
                if (!((ConnectedOpc.ServerState.ToString()).Equals("1")))
                {
                    ConnectedOpc.Connect(plcServerConnectionString, "");
                    Log.Debug("OnConnectPLC :: PLC connection successful and OPC server state is :: " + ConnectedOpc.ServerState.ToString());
                }
                else
                {
                    Log.Debug("OnConnectPLC :: Already connected with the plc.");
                }

            }
            catch (Exception ex)
            {
                Log.Error("OnConnectPLC :: Exception while connecting to plc :: " + ex.Message + " stackTrace :: " + ex.StackTrace);
            }
        }

        private void OnDisconnectPLC()
        {
            Log.Debug("inside OnDisconnectPLC");

            try
            {
                ConnectedOpc.Disconnect();
                Log.Debug("OnDisconnectPLC :: Connection with the plc is disconnected.");
            }
            catch (Exception ex)
            {
                Log.Error("OnDisconnectPLC :: Exception while disconnecting to plc :: " + ex.Message);
            }

        }


        #endregion
    }
}


