using LoanManagementSystem.Exceptions;
using LoanManagementSystem.Models;
using LoanManagementSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Repository
{
    class LoanRepository : ILoanRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public LoanRepository()
        {
            cmd = new SqlCommand();
        }

        #region Apply Loan
        public bool ApplyLoan(Loan loan)
        {
            using (SqlConnection sqlConnection = DbConnectionUtility.GetSqlConnectionObject())
            {
                cmd.CommandText = "insert into Loans values(@CustomerId,@PrincipalAmount,@InterestRate,@LoanTerm,@LoanType,@LoanStatus)";
                cmd.Parameters.AddWithValue("@CustomerId", loan.CustomerId);
                cmd.Parameters.AddWithValue("@PrincipalAmount", loan.PrincipalAmount);
                cmd.Parameters.AddWithValue("@InterestRate", loan.InterestRate);
                cmd.Parameters.AddWithValue("@LoanTerm", loan.LoanTerm);
                cmd.Parameters.AddWithValue("@LoanType", loan.LoanType);
                cmd.Parameters.AddWithValue("@LoanStatus", loan.LoanStatus);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
            }
            if (cmd.ExecuteNonQuery()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Calculate EMI
        public double CalculateEmi(int loanId)
        {
            int P = 0;
            int R = 0;
            int interest = 0;
            int N = 0;
            double EMI = 0;
            using (SqlConnection sqlConnection = DbConnectionUtility.GetSqlConnectionObject())
            {
                cmd.CommandText = "select * from Loans where LoanId = @LoanId";
                cmd.Parameters.AddWithValue("@LoanId", loanId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    P = (int)reader["PrincipalAmount"];
                    interest = (int)reader["InterestRate"];
                    R = (interest / 12 / 100);
                    N = (int)reader["LoanTerm"];
                }
                EMI = (P * R* Math.Pow(1 + R,N))/ (Math.Pow(1 + R , N - 1));
            }
            return EMI;
        }
        #endregion

        #region Calculate Interest
        public int CalculateInterest(int loanId)
        {
            int principalAmount = 0;
            int interestRate = 0;
            int loanTerm = 0;
            int interest = 0;

            using (SqlConnection sqlConnection = DbConnectionUtility.GetSqlConnectionObject())
            {
                cmd.CommandText = "select PricipalAmount,InterestRate,LoanTerm from Loans where LoanId = @LoanId";
                cmd.Parameters.AddWithValue("@LoanId", loanId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    principalAmount = (int)reader["PrincipalAmount"];
                    interestRate = (int)reader["InterestRate"];
                    loanTerm = (int)reader["LoanTerm"];
                }
                interest = (principalAmount * interestRate * loanTerm) / 12;
            }
            return interest;
        }
        #endregion

        #region Get All Loans
        public List<Loan> GetAllLoans()
        {
            List<Loan> loans = new List<Loan>();
            using (sqlConnection = DbConnectionUtility.GetSqlConnectionObject())
            {

                cmd.CommandText = "select * from Loans";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Loan loan = new Loan();
                    loan.LoanId = (int)reader["LoanId"];
                    loan.CustomerId = (int)reader["CustomerId"];
                    loan.PrincipalAmount = (decimal)reader["PrincipalAmount"];
                    loan.InterestRate = (decimal)reader["InterestRate"];
                    loan.LoanTerm = (int)reader["LoanTerm"];
                    loan.LoanType = (string)reader["LoanType"];
                    loan.LoanStatus = (string)reader["LoanStatus"];
                    loans.Add(loan);
                }
            }
            //sqlConnection.Close();
            return loans;
        }
        #endregion

        #region GetLoanById
        public List<Loan> GetLoanById(int loanId)
        {
            List<Loan> loans = new List<Loan>();
            using (sqlConnection = DbConnectionUtility.GetSqlConnectionObject())
            {
                try
                {
                    cmd.CommandText = "select * from Loans where LoanId = @LoanId";
                    cmd.Parameters.AddWithValue("@LoanId", loanId);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Loan loan = new Loan();
                        loan.LoanId = (int)reader["LoanId"];
                        loan.CustomerId = (int)reader["CustomerId"];
                        loan.PrincipalAmount = (decimal)reader["PrincipalAmount"];
                        loan.InterestRate = (decimal)reader["InterestRate"];
                        loan.LoanTerm = (int)reader["LoanTerm"];
                        loan.LoanType = (string)reader["LoanType"];
                        loan.LoanStatus = (string)reader["LoanStatus"];
                        loans.Add(loan);
                    }
                }
                catch (Exception)
                {
                    throw new InvalidLoanException("No Such Loan Exists. Invalid LoanId");
                }
            }
            //sqlConnection.Close();
            return loans;
        }
        #endregion

        #region Loan Repayment
        public string LoanRepayment(int loanId, int amount)
        {
            int noOfEmi = 0;
            var emi = (int)CalculateEmi(loanId);
            if (emi > amount)
            {
                return "Not Acceptable!!!\nAmount you are trying to pay is less than the EMI.";
            }
            else 
            {
                noOfEmi = amount / emi;
                return $"EMI Rs.{amount} is paid";
            }
        }
        #endregion

        #region Loan Status
        public List<Loan> LoanStatus(int loanId)
        {
            List<Loan> loans = new List<Loan>();
            
            int customerId = 0;
            int creditScore = 0;
            using (sqlConnection = DbConnectionUtility.GetSqlConnectionObject())
            {
                try
                {
                    cmd.CommandText = "select LoanStatus,CustomerId from Loans where LoanId = @LoanId";
                    cmd.Parameters.AddWithValue("@LoanId", loanId);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Loan loan = new Loan();
                        loan.LoanStatus = (string)reader["LoanStatus"];
                        customerId = loan.CustomerId = (int)reader["CustomerId"];
                        loans.Add(loan);
                    }
                    cmd.CommandText = "select CreditScore from Customers where CustomerId = @customerId";
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    while (reader.Read())
                    {
                        creditScore = (int)reader["CreditScore"];
                    }
                    if(creditScore > 650)
                    {
                        cmd.CommandText = "update Status = 'Approved' where LoanId = @LoanId";
                        cmd.Parameters.AddWithValue("@LoanId", loanId);
                    }
                    else
                    {
                        cmd.CommandText = "update Status = 'Rejected' where LoanId = @LoanId";
                        cmd.Parameters.AddWithValue("@LoanId", loanId);
                    }

                }
                catch (Exception)
                {
                    throw new InvalidLoanException("No Such Loan Exists. Invalid LoanId");
                }
            }
            //sqlConnection.Close();
            return loans;
        }
        #endregion
    }
}
