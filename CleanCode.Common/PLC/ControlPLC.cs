using ActUtlType64Lib;
using System.IO.Ports;

namespace CleanCode.Common
{
    public class ControlPLC
    {
        private readonly ActUtlType64 _plc = new();
        
        private const int _plcStation = 1;
        
        private readonly bool isExist = false;

        private bool isStart;
        private bool isEMG = false;
        private bool isStop = false;
        private bool isAlarm = false;

        // Register read
        private const string REG_READ_PLC_READ_STATUS = "D20";
        private const string REG_READ_PLC_REFRESH_DATA= "M2010";

        // Register Write
        private const string REG_WRITE_PLC = "D";
        private const int REG_WRITE_PLC_START = 900;
        private const string REG_WRITE_PLC_VISION_BUSY = "M420";
        private const string REG_WRITE_PLC_NOT_ENOUGHT_TRAY = "M421";
        private const string REG_WRITE_PLC_VISION_DONE_INSPECTION = "M240";

        public ControlPLC()
        {
            _plc.ActLogicalStationNumber = _plcStation;
        }

        public void Connect()
        {
            if (_plc.Open() == 0)
            {
                Thread thread = new Thread(ReadStatusPLC);
                thread.IsBackground = true;
                thread.Name = "READ_PLC_STATUS";
                thread.Start();

                Thread thread1 = new Thread(ReadEventStartFromPLC);
                thread1.IsBackground = true;
                thread1.Name = "READ_EVENT_START_PLC";
                thread1.Start();
            }
        }

        private void ReadStatusPLC()
        {
            while (!isExist)
            {
                int valueReaded = 0;
                _plc.ReadDeviceBlock(REG_READ_PLC_READ_STATUS, 1, out valueReaded);
                SetStatusOfMachine(valueReaded);
                Thread.Sleep(Constants.TIME_SLEEP);
            }
        }

        private void ReadEventStartFromPLC()
        {
            while (!isExist)
            {
                int valueReaded = 0;
                _plc.GetDevice(REG_READ_PLC_REFRESH_DATA, out valueReaded);
                Thread.Sleep(Constants.TIME_SLEEP);
            }
        }

        private void SetStatusOfMachine(int binary)
        {
            isAlarm = isStart = isStop = isEMG = false;

            switch (binary)
            {
                case 0:
                    isEMG = true;
                    break;
                case 1:
                    isStart = true;
                    break;
                case 2:
                    isStop = true;
                    break;
                case 3:
                    isAlarm = true;
                    break;
                default:
                    break;
            }
        }

        public void WriteDataToRegister(int data, int index)
        {
            _plc.WriteDeviceBlock(GetWriteRegisterByIndex(index), 1, data);
        }

        private string GetWriteRegisterByIndex(int index)
        {
            return string.Format("{0}{1}", REG_WRITE_PLC, REG_WRITE_PLC_START + index);
        }

        public void TurnOnLightControl()
        {
            try
            {
                SerialPort lightControl1 = new SerialPort("COM4", Constants.PORT_COM_4);
                SerialPort lightControl2 = new SerialPort("COM5", Constants.PORT_COM_5);

                lightControl1.Open();
                lightControl2.Open();

                lightControl1.WriteLine("@SI00/255/255/255/255");
                lightControl2.WriteLine("@SI00/255/255/255/255");

                lightControl1.Close();
                lightControl2.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void TurnOffLightControl()
        {
            try
            {
                SerialPort lightControl1 = new SerialPort("COM4", Constants.PORT_COM_4);
                SerialPort lightControl2 = new SerialPort("COM5", Constants.PORT_COM_5);

                lightControl1.Open();
                lightControl2.Open();

                lightControl1.WriteLine("@SI00/0/0/0/0");
                lightControl2.WriteLine("@SI00/0/0/0/0");

                lightControl1.Close();
                lightControl2.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //busy = 1, ready 0
        public void VisionBusy(bool status)
        {
            _plc.SetDevice(REG_WRITE_PLC_VISION_BUSY, status ? 1 : 0);
        }

        public void VisionDoneIns()
        {
            _plc.SetDevice(REG_WRITE_PLC_VISION_DONE_INSPECTION, 1);
        }

        public void VisionNotEnoughTray()
        {
            _plc.SetDevice(REG_WRITE_PLC_NOT_ENOUGHT_TRAY, 1);
        }
    }
}
