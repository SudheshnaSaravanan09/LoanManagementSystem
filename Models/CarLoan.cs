using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Models
{
    class CarLoan:Loan
    {
        string carModel;
        int carValue;

        #region Getter Setter Methods
        public string CarModel
        {
            get { return carModel; }
            set { carModel = value; }
        }
        public int CarValue
        {
            get { return carValue; }
            set { carValue = value; }
        }
        #endregion

        #region Constructor
        public CarLoan()
        {

        }
        public CarLoan(string propertyAddress, int propertyValue)
        {
            CarModel = carModel;
            CarValue = carValue;
        }
        #endregion

        public override string ToString()
        {
            return $"CarModel: {CarModel}\t CarValue: {CarValue}";
        }
    }
}
