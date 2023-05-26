using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
    public class BusinessLogic
    {
        DataLogic objLogic = new DataLogic();

        public List<string> SendListToPresentation() {

            // calling the 
            return objLogic.ReadFromCSV();
        }

        public void SearchByDomain(string _domain)
        {
            int count = 0;
            
            List<string> list = new List<string>();
            list = objLogic.ReadFromCSV();
            foreach (var item in list)
            {
                if (item.Contains(_domain))
                {
                    Console.WriteLine(item);
                    count++; // increasing the count by one
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Number of " + _domain + " domains is " + count);
        }

        public int CalulateAverageAge()
        {

            List<string> list = new List<string>();
            list = objLogic.ReadFromCSV();
            int sum = 0;
            foreach (var item in list)
            {
                string[] userData = item.Split(',');
                int age = int.Parse(userData[6]); // converting the string in the string[] to a number

                sum += age; // adding the age to the sum variable

            }
            int average = sum / list.Count();

            return average;
           
        }

        // sending list of user selected domains to datalayer so that it can be written to file
        public void SendListOfDomainsToDataLayer(string _domain)
        {
            List<string> list = new List<string>();
            List<string> listToSendToDataLayer = new List<string>();

            list = objLogic.ReadFromCSV();

            foreach (var item in list)
            {
                if (item.Contains(_domain))
                {
                  listToSendToDataLayer.Add(item);  
                 
                }
            }
            objLogic.WriteDomainsToFile(listToSendToDataLayer);
        }

    }
}

// Data -> Business -> Presentation
// Data <- Business <- Presentation
