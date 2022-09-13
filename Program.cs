using capTaxiBackEnd;

Console.Clear();

DriverUtility utils = new DriverUtility();
Menu menu = new Menu();

string userChoice = menu.GetMainMenuChoice();
while(userChoice != "6"){
    RouteEm(userChoice);
    userChoice = menu.GetMainMenuChoice();
}
if(userChoice == "6")
    Environment.Exit(0);

void RouteEm(string userChoice)
    {
        switch(userChoice)
            {
                case "1":
                    utils.DisplayDrivers();
                    break;
                case "2":
                    utils.AddDriver();
                    break;
                case "3":
                    utils.UpdateRating();
                    break;
                case "4":
                    utils.DeleteDriver();
                    break;
                case "5":
                    utils.MaintLongOrShort();
                    break;
                default:
                    System.Console.WriteLine("Bad Entry");
                    break;
            }
    }