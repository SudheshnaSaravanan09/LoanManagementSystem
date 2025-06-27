using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Models
{
    class Loan
    {
        int loanId;
        int customerId;
        decimal principalAmount;
        decimal interestRate;
        int loanTerm;
        string loanType;
        string loanStatus;

        #region Getter Setter Methods
        public int LoanId
        {
            get { return loanId; }
            set { loanId = value; }
        }
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        public decimal PrincipalAmount
        {
            get { return  principalAmount; }
            set { principalAmount = value; }
        }
        public decimal InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }
        public int LoanTerm
        {
            get { return loanTerm; }
            set { loanTerm = value; }
        }
        public string LoanType
        {
            get { return loanType; }
            set { loanType = value; }
        }
        public string LoanStatus
        {
            get { return loanStatus; }
            set { loanStatus = value; }
        }
        #endregion

        #region Constructor
        public Loan()
        {

        }
        public Loan(int loanId, int customerId, decimal principalAmount, decimal interestRate, int loanTerm, string loanType, string loanStatus)
        {
            LoanId = loanId; CustomerId = customerId; PrincipalAmount = principalAmount; InterestRate = interestRate; LoanTerm = loanTerm; LoanType = loanType; LoanStatus = loanStatus;
        }
        #endregion

        public override string ToString()
        {
            return $"LoanId = {LoanId}\t CustomerId = {CustomerId}\t PrincipalAmount = {PrincipalAmount}\t InterestRate = {InterestRate}\t LoanTerm = {LoanTerm}\t LoanType = {LoanType}\t LoanStatus = {LoanStatus}\t";
        }
    }
}
