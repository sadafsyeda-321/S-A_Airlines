using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.RepositoryLayer
{
    public class PriceRepository
    {
        private readonly string _filePath = "D:\\2nd Semester\\OOP\\OOP Project\\OOP Project\\RepositoryLayer\\Price.txt";

        public double[] GetAll()
        {
            // Default prices 
            double[] prices = { 250000, 180000, 150000, 110000 };

            //if (File.Exists(_filePath))
            //{
            //    string record = File.ReadAllText(_filePath).Trim();
            //    if (record != "")
            //    {
            //        for (int i = 0; i < 4; i++)
            //        {
            //            string text = getField(record, i + 1);
            //            if (text != "")
            //            {
            //                prices[i] = double.Parse(text);
            //            }
            //        }
            //    }
            //}
            return prices;
        }

        public void SaveAll(double[] prices)
        {
            string line = prices[0] + "," + prices[1] + "," + prices[2] + "," + prices[3];
            File.WriteAllText(_filePath, line);
        }

        // Save

        public string getField(string record, int field)
        {
            int commaCount = 1;
            string word = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    word = word + record[i];
                }
            }
            return word;
        }

        public void ClearAll()
        {
            File.WriteAllText(_filePath, string.Empty);
        }
    }
}
