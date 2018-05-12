using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.Infrastructure
{
    internal class Logger
    {
        private string successFileName;
        private string errorFileName;

        public Logger(string successFileName, string errorFileName)
        {
            this.successFileName = successFileName;
            this.errorFileName = errorFileName;
        }

        public string SuccessFileName
        {
            get { return this.successFileName; }
        }

        public string ErrorFileName
        {
            get { return this.errorFileName; }
        }

        public void SuccessLog(string msg, Exception exception)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(SuccessFileName))
                {
                    Task result = writer.WriteLineAsync(msg);
                    result.ContinueWith((task) =>
                    {
                        writer.WriteLineAsync(exception.StackTrace);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: something went wrong with success file.", "Error", MessageBoxButtons.OK);
            }
        }

        public void ErrorLog(string msg, Exception exception)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ErrorFileName))
                {
                    Task result = writer.WriteLineAsync(msg);
                    result.ContinueWith((task) =>
                    {
                        writer.WriteLineAsync(exception.StackTrace);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: something went wrong with error file.", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
