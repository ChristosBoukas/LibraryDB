using LibraryDB.Data;

namespace LibraryDB
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataAccess dataAccess = new DataAccess();

            #region Seed
            SeedCustomerWithLoanCards(20);
            //SeedBooksWithAuthors(20);
            #endregion

            #region Create
            //dataAccess.CreateCustomerAndLoanCard();
            //dataAccess.CreateBook();
            //dataAccess.CreateAuthor();
            #endregion

            #region Remove
            //dataAccess.RemoveAuthorByID(20);
            //dataAccess.RemoveBookByID(2);
            //dataAccess.RemoveLoancardAndCustomerByID();
            #endregion

            #region Loan/Return Book & Show Loan History
            //dataAccess.LoanBook(1, 1);
            //dataAccess.ReturnBook(1);
            //dataAccess.ShowLoanHistoryByLoanCardId(1);
            #endregion


            Console.WriteLine("Finished");
            Console.ReadLine();
        }


        private static void SeedCustomerWithLoanCards(int amountToSeed)
        {
            DataAccess dataAccess = new DataAccess();
            for (int i = 0; i < amountToSeed; i++)
            {
                dataAccess.SeedCustomerAndLoanCard();
            }
        }

        private static void SeedBooksWithAuthors(int amountToSeed)
        {
            DataAccess dataAccess = new DataAccess();
            for (int i = 0; i < amountToSeed; i++)
            {
                dataAccess.SeedBookAndAuthor();
            }
        }








    }

}