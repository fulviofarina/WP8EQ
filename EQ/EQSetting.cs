using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using This;



namespace EQ
{
    public class EQSetting : ISetting
    {

        private double minMag = 0;
        private double minSince = 600;
        private double minDistance = 40000;
        private Int16 filterNear = 0;
        private IList<object> table = null;
        private bool asc = true;
        public bool Asc
        {
            get { return asc; }
            set { asc = value; }
        }
        public double MinMag
        {
            get { return minMag; }
            set { minMag = value; }
        }
        public double MinSince
        {
            get { return minSince; }
            set { minSince = value; }
        }
        public double MinDistance
        {
            get { return minDistance; }
            set { minDistance = value; }
        }
        public Int16 FilterNear
        {
            get { return filterNear; }
            set { filterNear = value; }
        }
        private int currIndex = 0;
        public int CurrIndex
        {
            get { return currIndex; }
            set { currIndex = value; }
        }


        private void set(object mMag, object mSince, object mDistance, object fNear)
        {



            minMag = Convert.ToDouble(mMag);
            minSince = Convert.ToDouble(mSince);
            minDistance = Convert.ToDouble(mDistance);
            filterNear = Convert.ToInt16(fNear);

        }
        private void set(string content)
        {
            string[] aux = content.Split(',');
            set(aux[0], aux[1], aux[2], aux[3]);

        }



        public EQSetting(string SettingsFile)
        {

            settingsFile = SettingsFile;
            
        }


        string content = string.Empty;


       private string settingsFile = string.Empty;
     
        public async Task ReadOrWrite(bool read)
        {


            if (read)
            {

                content = await IO.ReadFileContentsAsync(settingsFile);

                if (string.IsNullOrEmpty(content))
                {
                    content = minMag + "," + minSince + "," + minDistance + "," + filterNear;

                }
                else content = content.Replace("\0", "");
                set(content);

            }
            else
            {

                content = table.ElementAt(0) + "," + table.ElementAt(1) + "," + table.ElementAt(2) + "," + filterNear;
                set(content);

                await IO.WriteDataToFileAsync(settingsFile, content);

            }

        }



        public IList<object> Table
        {
            get
            {

                table = new List<object>();
                table.Add(minMag);
                table.Add(minSince);
                table.Add(minDistance);

                return table;
            }

            set
            {
                table = value;


             


            }

        }
        public IList<string> TableName
        {
            get
            {
                List<string> tableName = null;

                tableName = new List<string>();
                tableName.Add("Magnitude");
                tableName.Add("Time (min)");
                tableName.Add("Radius (km)");

                return tableName;
            }

        }


    }

}
