using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exceptionsSamples.Entities.Exceptions;

namespace exceptionsSamples.Entities
{
    internal class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new DomainException("Error in reservation: Check-out date must be after check-in date");
            }
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
        public double Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return(int)duration.TotalDays;
        }
        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;
            if (checkIn < now || checkOut < now)
            {
                throw new DomainException("Error in reservation: Reservation dates for update must be future dates");
            }
            if (checkOut <= checkIn)
            {
                throw new DomainException("Error in reservation: Check-out date must be after check-in date");
            }

            CheckIn = checkIn;
            CheckOut = checkOut;
            return null;
        }
        public override string ToString()
        {
            return "Room:" 
                + RoomNumber
                + ", checkin: "
                + CheckIn.ToString("dd/MM/yyyy")
                + ", checkout: "
                + CheckOut.ToString("dd/MM/yyyy")
                + ", "
                + Duration()
                + " nights";
        }

    }
}
