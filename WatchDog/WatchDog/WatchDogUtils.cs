using System;

namespace WatchDog
{
    class WatchDogUtils
    {
        private static OpenLibSys.Ols MyOls;

        public bool Initialize()
        {
            MyOls = new OpenLibSys.Ols();
            return MyOls.GetStatus() == (uint)OpenLibSys.Ols.Status.NO_ERROR;
        }

        public void InitSuperIO()
        {
            MyOls.WriteIoPortByte(0x2e, 0x87);
            MyOls.WriteIoPortByte(0x2e, 0x01);
            MyOls.WriteIoPortByte(0x2e, 0x55);
            MyOls.WriteIoPortByte(0x2e, 0x55);
        }

        public int SuperIoInw(byte data)
        {
            int val;
            MyOls.WriteIoPortByte(0x2e, data++);
            val = MyOls.ReadIoPortByte(0x2f) << 8;
            Console.WriteLine("SuperIo_Inw  val1:" + Convert.ToString(val, 16));
            MyOls.WriteIoPortByte(0x2e, data);
            val |= MyOls.ReadIoPortByte(0x2f);
            Console.WriteLine("SuperIo_Inw  val2:" + Convert.ToString(val, 16));
            return val;
        }

        public string GetChipName()
        {
            ushort chip_type;
            chip_type = (ushort)SuperIoInw(0x20);
            Console.WriteLine("chip type :" + Convert.ToString(chip_type, 16));
            return "IT" + Convert.ToString(chip_type, 16);
        }

        public void WatchDogInit()
        {
            //select logic device
            MyOls.WriteIoPortByte(0x2e, 0x07);
            MyOls.WriteIoPortByte(0x2f, 0x07);
            
        }

        public void EnableWatchDog()
        {
            //set configuartion register
            MyOls.WriteIoPortByte(0x2e, 0x72);
            MyOls.WriteIoPortByte(0x2f, 0x90);//1001 0000
        }

        public void StopWatchDog()
        {
            InitSuperIO();
            MyOls.WriteIoPortByte(0x2e, 0x72);
            MyOls.WriteIoPortByte(0x2f, 0x80);
            Console.WriteLine("WatchDog stopped!!!");
            ExitSuperIo();
        }

        public int TimeoutInw(byte data)
        {
            int val;
            MyOls.WriteIoPortByte(0x2e, data--);
            val = MyOls.ReadIoPortByte(0x2f) << 8;
            Console.WriteLine("Timeout MSB val:" + Convert.ToString(val, 2));
            MyOls.WriteIoPortByte(0x2e, data);
            val |= MyOls.ReadIoPortByte(0x2f);
            Console.WriteLine("TimeoutInw  LSB val:" + Convert.ToString(val, 2) + " ;VAL:" + val);
            return val;
        }

        public void FeedDog(ushort time)
        {
            InitSuperIO();
            MyOls.WriteIoPortByte(0x2e, 0x73);
            MyOls.WriteIoPortByte(0x2f, Convert.ToByte(time&0xff));
            if (time > 255)
            {
                MyOls.WriteIoPortByte(0x2e, 0x74);
                MyOls.WriteIoPortByte(0x2f, Convert.ToByte(time >> 8));
            }
            else
            {
                MyOls.WriteIoPortByte(0x2e, 0x74);
                MyOls.WriteIoPortByte(0x2f, 0x00);
            }
            
            //TimeoutInw(0x74);
            ExitSuperIo();
        }

        public void ExitSuperIo()
        {
            MyOls.WriteIoPortByte(0x2e, 0x02);
            MyOls.WriteIoPortByte(0x2f, 0x02);
        }

    }
}
