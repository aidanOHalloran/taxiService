namespace capTaxiBackEnd
{
    public class Menu
    {
        private void DisplayMenu()
            {
                System.Console.WriteLine("\n\t\tPress any key to continue");
                Console.ReadKey();
                Console.Clear();
                System.Console.WriteLine("\n\t\t-------------");
                System.Console.WriteLine("\t\tTAXI SERVICE");
                System.Console.WriteLine("\t\t-------------\n\n");
                System.Console.WriteLine("\t\t1. Show All Drivers");
                System.Console.WriteLine("\t\t2. Hire New Driver");
                System.Console.WriteLine("\t\t3. Update Driver Rating");
                System.Console.WriteLine("\t\t4. Fire Driver");
                System.Console.WriteLine("\t\t5. View Maintenance Date By Month");
                System.Console.WriteLine("\t\t6. Exit App\n");
            }

        public string GetMainMenuChoice()
            {
                DisplayMenu();
                System.Console.WriteLine("\t\tPlease enter a selection: ");
                System.Console.Write("\n\t\t");
                string userChoice = Console.ReadLine();
                return userChoice;
            }

    }
}