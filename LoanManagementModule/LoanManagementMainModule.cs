﻿using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using System.Threading.Channels;

namespace LoanManagementSystem.LoanManagementModule
{
    class LoanManagementMainModule
    {
        ILoanRepository loanRepository = new LoanRepository();
        public void Run()
        {
            int choice = 0;
            Console.WriteLine("Welcome to Loan Management System");
            Console.WriteLine("Choose from below options to continue...");
            do
            {
                Console.WriteLine("1.ApplyLoan\n2.GetAllLoan\n3.GetLoanById\n4.LoanRepayment\n5.GetLoanStatus\n6.Exit");
                choice = Convert.ToInt32(Console.ReadLine());
            
                switch (choice)
                {
                    case 1:
                        ApplyLoan();
                        break;
                    case 2:
                        GetAllLoan();
                        break;
                    case 3:
                        GetLoanById();
                        break;
                    case 4:
                        LoanRepayment();
                        break;
                    case 5:
                        GetLoanStatus();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            } while (choice != 5);
        }

        #region ApplyLoan method
        void ApplyLoan()
        {
            string loanType="";
            Console.WriteLine("Enter CustomerId: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Amount to be Borrowed: ");
            int principalAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Interest Rate: ");
            int interestRate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Loan Tenure (No of Months): ");
            int loanTerm = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose Loan Type: ");
            Console.WriteLine("1.CarLoan\n2.HomeLoan");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    loanType = "CarLoan";
                    break;
                case 2:
                    loanType = "HomeLoan";
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            Loan loan = new Loan() { CustomerId = customerId, PrincipalAmount = principalAmount, InterestRate = interestRate, LoanTerm = loanTerm, LoanType = loanType,LoanStatus = "Pending"};
            bool applyLoanStatus = loanRepository.ApplyLoan(loan);
            if (applyLoanStatus)
            {
                Console.WriteLine("Loan Applied Successfully");
            }
            else
            {
                Console.WriteLine("Loan Application Failed");
            }
        }
        #endregion

        #region GetAllLoan
        void GetAllLoan()
        {
            List<Loan> allLoan = loanRepository.GetAllLoans();
            foreach (var loan in allLoan)
            {
                Console.WriteLine(loan);
            }
        }
        #endregion

        #region GetLoanById
        void GetLoanById()
        {
            GetAllLoan();
            Console.WriteLine("Enter LoanId");
            int loanId = Convert.ToInt32(Console.ReadLine());
            List<Loan> allLoan = loanRepository.GetLoanById(loanId);
            foreach (var loan in allLoan)
            {
                Console.WriteLine(loan);
            }
        }
        #endregion

        #region LoanRepayment
        void LoanRepayment()
        {
            Console.WriteLine("Enter LoanId: ");
            int loanId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Amount: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            string loanRepayment = loanRepository.LoanRepayment(loanId, amount);
        }
        #endregion

        #region GetLoanStatus
        void GetLoanStatus()
        {
            Console.WriteLine("Enter LoanId: ");
            int loanId = Convert.ToInt32(Console.ReadLine());
            List<Loan> loanStatus = loanRepository.LoanStatus(loanId);
            foreach(var item in loanStatus)
            {
                Console.WriteLine(item);
            }
        }

        #endregion
    }
}
