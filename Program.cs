using LoanManagementSystem.LoanManagementModule;

namespace LoanManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoanManagementMainModule loanManagementMainModule = new LoanManagementMainModule();
            loanManagementMainModule.Run();
        }
    }
}
