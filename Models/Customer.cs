using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Models
{
    class Customer
    {
        int customerId;
        string name;
        string email;
        string phoneNumber;
        string address;
        int creditScore;

        #region Getter Setter Methods
        public int CustomerId 
        { 
            get { return customerId; }
            set { customerId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Address
        {
            get { return address; }
            set {  address = value; }
        }
        public int CreditScore
        {
            get { return creditScore; }
            set { creditScore = value; }
        }
        #endregion

        #region Constructor
        public Customer()
        {
            
        }
        public Customer(int customerId, string name, string email, string phoneNumber, string address, int creditScore)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            CreditScore = creditScore;
        }
        #endregion

        public override string ToString()
        {
            return $"CustomerId: {CustomerId}\t Name: {Name}\t Email: {Email}\t PhoneNumber: {PhoneNumber}\t Address: {Address}\t CreditScore: {CreditScore}";
        }
    }
}
