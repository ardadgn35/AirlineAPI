using System;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

namespace AirlineAPI.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public List<Ticket> Tickets { get; set; }  // Related tickets for the flight

        public Flight(string from, string to, DateTime date, int capacity)
        {
            From = from;
            To = to;
            Date = date;
            Capacity = capacity;
            Tickets = new List<Ticket>();
        }
    }
}
