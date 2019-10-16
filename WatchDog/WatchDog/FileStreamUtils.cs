using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchDog
{
    class FileStreamUtils
    {
        public void FileStreamWriteTimeout(String path, ushort time)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, 
                FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.SetLength(0);
            StreamWriter writer = new StreamWriter(fs, System.Text.Encoding.UTF8);
            Console.WriteLine("Write time out path:"+ path + ";time:" + time);
            try
            {
                writer.Write(Convert.ToString(time));
            }
            finally
            {
                writer.Close();
                fs.Close();
            }
        }

        public string FileStreamReadTimeout(String path, ushort defaultTime)
        {
            string time = "";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate,
                FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(fs, System.Text.Encoding.UTF8);
            String data = "";
            try
            {
                if ((data = reader.ReadLine()) != null)
                {
                    time = data.Trim();
                    Console.WriteLine("Read Time-out:" + time);
                    LogHelper.WriteLog(path + " Read Time-out:" + time);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(fs, System.Text.Encoding.UTF8);
                    fs.SetLength(0);
                    Console.WriteLine("Write default Time-out:" + defaultTime);
                    LogHelper.WriteLog(path + " Write default Time-out:" + time);
                    writer.Write(Convert.ToString(defaultTime));
                    writer.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                reader.Close();
                fs.Close();
            }
            return time;
        }
    }
}
