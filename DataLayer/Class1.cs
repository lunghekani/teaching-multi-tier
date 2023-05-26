using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataLogic
    {
        // creating a method to read the file
        public List<string> ReadFromCSV()
        {

            string file = "./MOCK_DATA.csv";
            List<string> lstCSV = new List<string>();
            using (var sr = new StreamReader(file))
            {
                sr.ReadLine(); // skipping the headers in the CSV
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine(); // declaring a variable called line and giving it the value of sr.ReadLine()
                    lstCSV.Add(line); // populating the list
                }
            }

            return lstCSV;
        }

        public void WriteDomainsToFile(List<string> info)
        {
            using (var sw = new StreamWriter("./export.txt"))
            {
                foreach (var item in info   )
                {
                    sw.WriteLine(item);
                }
            }
        }
    }
}
