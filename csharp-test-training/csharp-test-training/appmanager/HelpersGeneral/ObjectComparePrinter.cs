using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace addressbook_web_tests
{
    public class ObjectComparePrinter : CompareHelper
    {
        private readonly Dictionary<string, Tuple<string, string>> _propertiesList;

        public string CompareObjectName {get;}

        public ObjectComparePrinter(string compareObjectName)
        {
            CompareObjectName = compareObjectName;
            _propertiesList = new Dictionary<string, Tuple<string, string>>();
        }

        public void AddPairOfValuesDiff(string propertyName, string firstValue, string secondValue)
        {
            AddPairOfValuesDiff<string>(propertyName, firstValue, secondValue);
        }
        
        public void AddPairOfValuesDiff(string propertyName, int firstValue, int secondValue)
        {
            AddPairOfValuesDiff<int>(propertyName, firstValue, secondValue);
        }
        
        public void AddPairOfValuesDiff<T>(string propertyName, T firstValue, T secondValue)
        {
            if (!CompareValuesNullFriendly(firstValue, secondValue))
            {
                _propertiesList.Add(propertyName, new Tuple<string, string>(PrettyPrint.PrintWithNull(firstValue), PrettyPrint.PrintWithNull(secondValue)));
            }
        }
        
        public string PrintFirstObjectData()
        {
            string retval = "";
            foreach (var propertyPair in _propertiesList)
            {
                retval += $"{propertyPair.Key} is '{propertyPair.Value.Item1}'\n";
                
            }
            return retval;
        }
        
        public string PrintSecondObjectData()
        {
            string retval = "";
            foreach (var propertyPair in _propertiesList)
            {
                retval += $"{propertyPair.Key} is '{propertyPair.Value.Item2}'\n";
                
            }
            return retval;
        }

        public string PrintListOfPropertiesSideBySide()
        {
            string retval = "";
            foreach (var propertyPair in _propertiesList)
            {
                retval += PrettyPrint.PrintTwoNamedStrings(propertyPair.Key, propertyPair.Value.Item1,
                    propertyPair.Value.Item2); 
            }
            return retval;

        }
    }
}