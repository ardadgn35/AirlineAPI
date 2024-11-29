namespace AirlineAPI.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public Passenger(string fullName)
        {
            FullName = fullName;
        }
    }
}
