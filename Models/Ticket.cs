using System;

namespace AirlineAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string PassengerName { get; set; }
        public bool IsCheckedIn { get; set; }

        public Ticket(int flightId, string passengerName, bool isCheckedIn = false)
        {
            FlightId = flightId;
            PassengerName = passengerName;
            IsCheckedIn = isCheckedIn;
        }
    }
}
