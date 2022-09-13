namespace capTaxiBackEnd
{
    public class VehicleMaintUtility
    {

        static void ShowAllMaintsByMonth(string month){
            Console.Clear();
            System.Console.WriteLine($"Displaying drivers from {month.ToUpper()}");
        }

        static string MaintRoute(string userChoice){
            string month = "";
            switch(userChoice)
                {
                    case "1":
                        month = "January";
                        return month;
                        break;
                    case "2":
                          month = "February";
                        return month;  
                        break;
                    case "3":
                            month = "March";
                        return month;
                        break;
                    case "4":
                            month = "April";
                        return month;
                        break;
                    case "5":
                            month = "May";
                        return month;
                        break;
                    case "6":
                            month = "June";
                        return month;
                        break;
                    case "7":
                            month = "July";
                        return month;
                        break;
                    case "8":
                            month = "August";
                        return month;
                        break;
                    case "9":
                            month = "September";
                        return month;
                        break;
                    case "10":
                            month = "October";
                        return month;
                        break;
                    case "11":
                            month = "November";
                        return month;
                        break;
                    case "12":
                            month = "December";
                        return month;
                        break;
                    default:
                        System.Console.WriteLine("Bad Entry");
                        return month = "bad entry";
                        break;
                }
                
        }
    }
}