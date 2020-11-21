using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousDemo
{
    public class DataManagerSerivice
    {
        /// <summary>
        /// 异步回调结果
        /// </summary>
        IAsyncResult asyncResult = null;

        private static DataManagerSerivice instance = new DataManagerSerivice();

        private int data = -1;

        private DataManagerSerivice()
        {

        }

        public static DataManagerSerivice Instance
        {
            get
            {
                return instance;
            }
        }

        public int Data
        {
            get
            {
                return this.data;
            }

            set
            {
                this.data = value;
            }
        }

        public void DataWarmUp()
        {
            Action func = new Action(this.QueryData);

            this.asyncResult = func.BeginInvoke(null, null);
        }

        public int GetData()
        {
            if (null == this.asyncResult)
            {
                return -1;
            }

            this.asyncResult.AsyncWaitHandle.WaitOne();
            return this.Data;
        }

        private void QueryData()
        {
            Thread.Sleep(5000);
            Random random = new Random();
            this.Data = random.Next();
        }
    }
}
