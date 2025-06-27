using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Models
{
    class HomeLoan:Loan
    {
        string propertyAddress;
        int propertyValue;

        #region Getter Setter Methods
        public string PropertyAddress
        {
            get { return propertyAddress; }
            set { propertyAddress = value; }
        }
        public int PropertyValue
        {
            get { return propertyValue; }
            set { propertyValue = value; }
        }
        #endregion

        #region Constructor
        public HomeLoan()
        {
            
        }
        public HomeLoan(string propertyAddress, int propertyValue)
        {
            PropertyAddress = propertyAddress;
            PropertyValue = propertyValue;
        }
        #endregion

        public override string ToString()
        {
            return $"PropertyAddress: {PropertyAddress}\t PropertyValue: {PropertyValue}";
        }
    }
}
