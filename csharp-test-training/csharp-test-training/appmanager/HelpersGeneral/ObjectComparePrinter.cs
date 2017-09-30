using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace addressbook_web_tests
{
    public class ObjectComparePrinter
    {
        private Dictionary<string, Tuple<string, string>> propertiesList;

        public string CompareObjectName {get;}

        public ObjectComparePrinter(string compareObjectName)
        {
            CompareObjectName = compareObjectName;
            propertiesList = new Dictionary<string, Tuple<string, string>>();
        }

        public void AddPairOfValues(string propertyName, string firstValue, string secondValue)
        {
            propertiesList.Add(propertyName, new Tuple<string, string>(firstValue, secondValue));
        }
        
        public string PrintFirstObjectData()
        {
            string retval = "";
            foreach (var propertyPair in propertiesList)
            {
                retval += $"{propertyPair.Key} is '{propertyPair.Value.Item1}'\n";
                
            }
            return retval;
        }
        
        public string PrintSecondObjectData()
        {
            string retval = "";
            foreach (var propertyPair in propertiesList)
            {
                retval += $"{propertyPair.Key} is '{propertyPair.Value.Item2}'\n";
                
            }
            return retval;
        }

        public string PrintListOfPropertiesSideBySide()
        {
            string retval = "";
            foreach (var propertyPair in propertiesList)
            {
                retval += PrettyPrint.PrintTwoNamedStrings(propertyPair.Key, propertyPair.Value.Item1,
                    propertyPair.Value.Item2); 
            }
            return retval;

        }
    }
}