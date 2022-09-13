namespace capTaxiBackEnd
{
    public class Driver
    {
        public string ID {get; set;}
        public string Name {get; set;}
        public string DateHired {get; set;}
        public string Rating {get; set;}
        public Vehicle Vehicle {get; set;}
        
        public override string ToString(){
            return $"\t {ID} \t {Name} \t {DateHired} \t\t {Rating}";
        }

        public Driver defaultDriver(string id, string name, string dateHired, string rating, Vehicle vehicle){
            DateTime defaultDate = new DateTime();
            id = " ";
            name = " ";
            dateHired = " ";
            rating = " ";
            Vehicle.VehicleID = " ";
            Vehicle.VehicleModel = " ";
            Vehicle.VehicleMaintDate = defaultDate;
            this.ID = id;
            this.Name = name;
            this.DateHired = dateHired;
            this.Rating = rating;
            this.Vehicle = vehicle;
            return this;
        }
    }
}