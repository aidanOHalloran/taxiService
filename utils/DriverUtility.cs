using System;
using System.Globalization;

namespace capTaxiBackEnd
{
    public class DriverUtility
    {
        public List<Driver> drivers;
        private DriverFileHandler fileHandler = new DriverFileHandler();

        public DriverUtility()
            {
                drivers = fileHandler.drivers;
            }


        public void DisplayDrivers()
            {
                Console.Clear();
                System.Console.WriteLine("\n\t\t1. Sort by Date Hired\n\t\t2. Sort by Rating\n\t\t3. Home\n");
                string userInput = Console.ReadLine();
                if(userInput == "1")
                {
                    SortDriversByDateHired();
                    Console.Clear();
                    System.Console.WriteLine("\n\t\t Filtered By: Date Hired\n");
                    System.Console.WriteLine("\tID: \t Name: \t\t    DateHired:    DriverRating: \n");
                try
                {
                    foreach (Driver driver in drivers)
                    {
                        if (drivers != null)
                        {
                            System.Console.WriteLine(driver.ToString());
                        }
                    }
                }
                catch (NullReferenceException err)
                {
                    System.Console.WriteLine("Null Reference Exception\n");
                    System.Console.WriteLine("Press any key to continue...");
                    System.Console.ReadKey();
                }

                }else if(userInput == "2")
                {
                    SortDriversByRating();
                    Console.Clear();
                    System.Console.WriteLine("\n\t\t Filtered By: Rating\n");
                    System.Console.WriteLine("\tID: \t Name: \t\t    DateHired:    DriverRating: \n");
                    try
                    {
                        foreach(Driver driver in drivers)
                        {
                            if(drivers != null){
                                System.Console.WriteLine(driver.ToString());
                            }
                        }
                    }
                    catch (NullReferenceException err)
                    {
                        System.Console.WriteLine($"These are getting a little too comfortable...\n\n{err.Message}");
                    }

                }else if(userInput == "3"){
                    return;
                }         
                else{
                    System.Console.WriteLine("Bad Entry...\nPress Enter to continue");
                    Console.ReadLine();
                    DisplayDrivers();
                }
            
                System.Console.WriteLine();
               
            }
        public void AddDriver()
            {
                Driver newDriver = new Driver();
                newDriver.Vehicle = new Vehicle();
                newDriver.Vehicle.VehicleMaintDate = new DateTime();
                DateTime tempDT = new DateTime(); 
                
                System.Console.WriteLine("Press enter to assign ID's: "); //logic for creating unique ID's
                Console.ReadLine();

                try
                {
                    if(drivers.Count() == 0){
                        
                    }
                }
                catch (ArgumentNullException ex)
                {
                    System.Console.WriteLine("Whoops, another error. Who woulda thought?");
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine("Press any key to continue");
                    StreamWriter sw = new StreamWriter("drivers.txt");
                    string text = "[]";
                    File.WriteAllText("drivers.txt", text);
                    System.Console.WriteLine();
                    System.Console.ReadKey();
                    return;
                }


                int intID = drivers.Count(), intVehicleID = drivers.Count();
                
                newDriver.ID = intID.ToString();
                foreach(Driver driver in drivers)
                    {
                        while(newDriver.ID == driver.ID){
                            intID += 1;
                            intVehicleID += 1;
                            newDriver.ID = intID.ToString();
                        }
                    }
                newDriver.Vehicle.VehicleID = intVehicleID.ToString();

                System.Console.WriteLine($"Driver ID: {newDriver.ID}");
                System.Console.WriteLine($"Vehicle ID: {newDriver.Vehicle.VehicleID}v"); //end logic to create unique ID's

                System.Console.WriteLine("Enter a name: ");
                newDriver.Name = Console.ReadLine();
                
                Console.WriteLine("Enter Date Hired(mm/dd/yyyy): ");
                newDriver.DateHired = Console.ReadLine();
            
                bool clearDateTest = false;

                while (clearDateTest == false)
                {
                    try
                    {
                        tempDT = DateTime.Parse(newDriver.DateHired);
                        newDriver.Vehicle.VehicleMaintDate = tempDT.ToUniversalTime();
                        newDriver.Vehicle.VehicleMaintDate = tempDT.ToUniversalTime().AddMonths(6);
                        clearDateTest = true;
                    }
                    catch (FormatException ex)
                    {
                        Console.Clear();
                        System.Console.WriteLine("\n\nInvalid Date: \n\n" + ex.Message);
                        Console.WriteLine("\nEnter Date Hired(mm/dd/yyyy): \n");
                        newDriver.DateHired = Console.ReadLine();
                    }
                }

                System.Console.WriteLine($"Vehicle maint date is {newDriver.Vehicle.VehicleMaintDate}");                

                bool clearRatingTest = false;
                while(clearRatingTest == false)
                {
                    System.Console.WriteLine("Enter Driver Rating: ");
                    newDriver.Rating = Console.ReadLine();
                    try
                    {
                        int tempRating;
                        do{
                          if(int.TryParse(newDriver.Rating, out tempRating)){
                              break;
                          }
                          System.Console.WriteLine("Please enter a whole integer between 1 and 5");
                          newDriver.Rating = Console.ReadLine();
                          tempRating = int.Parse(newDriver.Rating);
                        }while(!true);
                        
                        if(tempRating>= 1 && tempRating <= 5){
                            clearRatingTest = true;
                        }else{
                            clearRatingTest = false;
                            System.Console.WriteLine("Enter a rating between 1 and 5... Press any key to continue");
                            Console.ReadKey();
                        }
                    }
                    catch (FormatException ex)
                    {
                        clearRatingTest = false;
                        System.Console.WriteLine("\nError: " + ex.Message);
                        System.Console.WriteLine("\nPress any key to continue\n\n");
                        Console.ReadKey();
                        Console.Clear();
                    }      
                }


                System.Console.WriteLine("Enter Vehicle Model: ");
                newDriver.Vehicle.VehicleModel = Console.ReadLine();



                if(newDriver.Name == "")
                    newDriver.Name = null;

                if(newDriver.ID != null && newDriver.Name != null && newDriver.Rating != null &&
                     newDriver.DateHired != null && newDriver.Vehicle.VehicleID != null && newDriver.Vehicle.VehicleModel != null){
                    drivers.Add(newDriver);
                    SortDriversByDateHired();
                    SaveDrivers();
                }else{
                    Console.Clear();
                    System.Console.WriteLine("Bad Entry. Press any key to re-start process");
                    Console.ReadKey();
                    AddDriver();
                }
            }

            public void UpdateRating(){
                System.Console.WriteLine("Enter the ID of the driver you want to edit: ");
                string userInput = Console.ReadLine();
                Driver driver = FindDriver(userInput);

                bool clearRatingTest = false;
                
                    if(driver == null){
                        System.Console.WriteLine("404 ~~ driver ID not found");
                    }else{
                        while (clearRatingTest == false){
                        System.Console.WriteLine("Enter new rating: ");
                        driver.Rating = Console.ReadLine();
                        int tempRating = int.Parse(driver.Rating);
                            if(tempRating>= 1 && tempRating <= 5){
                                clearRatingTest = true;
                            }else{
                                clearRatingTest = false;
                                System.Console.WriteLine("Enter a rating between 1 and 5... Press any key to continue");
                                Console.ReadKey();
                            }
                    }
                }

                SaveDrivers();
            }

            public void DeleteDriver()
            {
                System.Console.WriteLine("Enter the id of the driver you want to delete: ");
                string userInput = Console.ReadLine();
                Driver driver = FindDriver(userInput); 
                if(driver == null)
                    {
                        System.Console.WriteLine("404 ~ Driver not found");
                    }else
                    {
                        int index = drivers.IndexOf(driver);
                        System.Console.WriteLine($"Removing driver: {driver.Name.ToUpper()}\n");
                        drivers.RemoveAt(index);
                    }
                SaveDrivers();
            }    

            private Driver FindDriver(string searchVal){
                Driver returnVal = drivers.Find(x => x.ID.ToLower() == searchVal.ToLower());
                return returnVal;
            }

        public void SaveDrivers()
            {
                fileHandler.SaveAllDrivers();
            }

        public void SortDriversByDateHired()
            {
                try{
                    drivers.Sort((x,y) => y.DateHired.CompareTo(x.DateHired));
                }catch(NullReferenceException err){
                    System.Console.WriteLine("Null Reference Exception... Be sure that 'Drivers.txt' is in the correct format\n");
                    System.Console.WriteLine("Please Add A Driver Into The DataBase Before Attempting A Sort\n");
                    System.Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        public void SortDriversByRating()
            {
               try{
                    drivers.Sort((x,y) => y.Rating.CompareTo(x.Rating));
                }catch(NullReferenceException err){
                    System.Console.WriteLine("Null Reference Exception... Be sure that 'Drivers.txt' is in the correct format\n");
                    System.Console.WriteLine("Please Add A Driver Into The DataBase Before Attempting A Sort\n");
                    System.Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                } 
            }


        public void MaintLongOrShort(){
            
            bool clearTest = false;

            while(clearTest == false){
            Console.Clear();    
            System.Console.WriteLine("\t\t1. View Short List");
            System.Console.WriteLine("\t\t2. View Full List\n\n");
            System.Console.WriteLine("Make a selection...\n");
           
            int userChoice;
            
            string userChoiceString = Console.ReadLine();
            try{
                userChoice = int.Parse(userChoiceString);
            }catch(Exception err)  {
                System.Console.WriteLine($"{err.Message}\nAutomatically selected Short List: ");
                userChoice = 1;
            }
            if(userChoice == 1){
                clearTest = true;
                ShowAllMaintsShort();
            }else if(userChoice == 2){
                clearTest = true;
                ShowAllMaints();
            }else{
                clearTest = false;
                System.Console.WriteLine("Enter either 1 or 2...\n\nPress any key to continue");
                Console.ReadKey();
            }
            }
        }    
        public void ShowAllMaints(){
            Console.Clear();
            System.Console.WriteLine("\t\tDisplaying All Maints By Month:\n\n");
            string [] months = new string[12]{"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            int monthCount = 0;
            foreach(string month in months){
                int count = 0;
                System.Console.WriteLine($"\n\t\tShowing Drivers From: {months[monthCount]}\n");
                foreach(Driver driver in drivers){
            string monthUtil = driver.Vehicle.VehicleMaintDate.ToString("MMMM");
            var dateOnly = DateOnly.FromDateTime(driver.Vehicle.VehicleMaintDate);
            string date = dateOnly.ToString("MM-dd-yyyy");
                    if(monthUtil == month){
                        count++;
                        System.Console.WriteLine($"{driver.Name.ToUpper()}'s {driver.Vehicle.VehicleModel.ToUpper()} scheduled for maint {date}\n");
                }
        }
                if(count == 0){
                    System.Console.WriteLine("\t\tCurrently No Drivers From This Month\n\n\n");
                }else{
            System.Console.WriteLine($"Total Drivers From {months[monthCount]} is: {count}.\n\n");  
            }
        monthCount++;
    } }

    public void ShowAllMaintsShort() {
        Console.Clear();
        System.Console.WriteLine("\t\tDisplaying All Maints By Month:\n\n");
        string [] months = new string[12]{"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
        int monthCount = 0;
            foreach(string month in months){
                int count = 0;
                foreach(Driver driver in drivers){
            string monthUtil = driver.Vehicle.VehicleMaintDate.ToString("MMMM");
            var dateOnly = DateOnly.FromDateTime(driver.Vehicle.VehicleMaintDate);
            string date = dateOnly.ToString("MM-dd-yyyy");
                    if(monthUtil == month){
                        count++;
                        System.Console.WriteLine($"{driver.Name.ToUpper()}'s {driver.Vehicle.VehicleModel.ToUpper()} scheduled for maint {date}\n");
                }
            }
        }
    }
  }
}
