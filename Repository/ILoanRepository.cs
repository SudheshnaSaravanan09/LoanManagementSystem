using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository
{
    interface ILoanRepository
    {
        bool ApplyLoan(Loan loan);
        int CalculateInterest(int loanId);
        List<Loan> LoanStatus(int loanId);
        double CalculateEmi(int loanId);
        string LoanRepayment(int loanId, int amount);
        List<Loan> GetAllLoans();
        List<Loan> GetLoanById(int loanId);

    }
}
