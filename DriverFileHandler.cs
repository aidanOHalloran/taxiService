using Newtonsoft.Json;
namespace capTaxiBackEnd
{
    public class DriverFileHandler
    {
        public List<Driver> drivers;
        public DriverFileHandler(){
            GetAllDrivers();
        }

        private void GetAllDrivers(){
            try {
        string json = File.ReadAllText("drivers.txt");
        bool readTest = false;

        
            if(json != null){
            drivers = JsonConvert.DeserializeObject<List<Driver>>(json);
            
            if(drivers == null){
                readTest = true;
            }else{
                readTest = false;
            }
            }else{
                System.Console.WriteLine("Error Reading File");
                StreamWriter sw = new StreamWriter("drivers.txt");
                string text = "[]";
                File.WriteAllText("drivers.txt", text);
                System.Console.WriteLine();
            }
        

        SaveAllDrivers();
      }
     catch (FileNotFoundException e) {
      Console.WriteLine("'drivers.txt' does not exist. Press enter to create file...");
      Console.ReadLine();
      StreamWriter sr = new StreamWriter("drivers.txt");
      string text = "[]";
      File.WriteAllText("drivers.txt", text);
      System.Console.WriteLine();
    }
}

        public void SaveAllDrivers()
            {
                File.WriteAllText("drivers.txt", JsonConvert.SerializeObject(drivers));
            }
    }
}