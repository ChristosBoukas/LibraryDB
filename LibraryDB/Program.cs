using LibraryDB.Data;

namespace LibraryDB
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataAccess dataAccess = new DataAccess();

            for (int i = 0; i < 10; i++)
            {
                dataAccess.SeedCustomerAndLoanCard();
            }

            for (int i = 0; i < 20; i++)
            {
                dataAccess.SeedBookAndAuthor();
            }

            //dataAccess.LoanBook(1, 1);
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}