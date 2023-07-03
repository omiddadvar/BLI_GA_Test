using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLI_GA_Test.Classes.Log
{
    public class TextLog
    {
        private string _FolderName, _FileName , _Path;
        public TextLog(string FolderName , string FileName)
        {
            try
            {
                _FolderName = FolderName;
                _FileName = FileName;
                _Path = _FolderName + "/" + _FileName + " " + _getDateTimeNow(true) + ".txt";
                _createFolder();
                _createFile();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.ToString());
            }
        }
        public bool AddLog(string logText)
        {
            string datetime = _getDateTimeNow();
            string logString = string.Format("{0} => {1}", datetime, logText);
            return _writeLogOnFile(logString);
        }
        private bool _writeLogOnFile(string logText)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_Path, true))
                {
                    writer.WriteLine(logText);
                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.ToString());
                return false;
            }
        }
        private string _getDateTimeNow(bool isForFileName = false)
        {
            DateTime date = DateTime.Now;
            var calendar = new PersianCalendar();
            var persianDate = new DateTime(calendar.GetYear(date), 
                calendar.GetMonth(date), 
                calendar.GetDayOfMonth(date),
                calendar.GetHour(date),
                calendar.GetMinute(date),
                calendar.GetSecond(date));

            if (isForFileName)
                return persianDate.ToString("yyyy-MM-dd");
            else
                return persianDate.ToString("yyyy/MM/dd HH:mm:ss");
        }
        private void _createFolder()
        {
            if (!Directory.Exists(_FolderName))
            {
                Directory.CreateDirectory(_FolderName);
            }
        }
        private void _createFile()
        {
            if (!File.Exists(_Path))
            {
                var stream = File.Create(_Path);
                stream.Flush();
                stream.Close();
            }
        }
    }
}
