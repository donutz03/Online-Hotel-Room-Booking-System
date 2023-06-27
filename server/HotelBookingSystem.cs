using System;
using System.Collections.Generic;

namespace HotelBookingSystem
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public decimal Price { get; set; }
        // Other room properties

        public Room(int roomId, string roomType, decimal price)
        {
            RoomId = roomId;
            RoomType = roomType;
            Price = price;
        }
    }

    public class Booking
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        // Other booking properties

        public Booking(int bookingId, int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            BookingId = bookingId;
            RoomId = roomId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }

    public class BookingSystem
    {
        private List<Room> availableRooms;
        private List<Booking> bookings;
        private int nextBookingId;

        public BookingSystem()
        {
            availableRooms = new List<Room>();
            bookings = new List<Booking>();
            nextBookingId = 1;
        }

        public void AddRoom(Room room)
        {
            availableRooms.Add(room);
        }

        public List<Room> GetAvailableRooms(DateTime checkInDate, DateTime checkOutDate)
        {
            List<Room> availableRooms = new List<Room>();

            foreach (var room in availableRooms)
            {
                bool isRoomAvailable = true;

                foreach (var booking in bookings)
                {
                    if (booking.RoomId == room.RoomId &&
                        (checkInDate >= booking.CheckInDate && checkInDate <= booking.CheckOutDate ||
                        checkOutDate >= booking.CheckInDate && checkOutDate <= booking.CheckOutDate))
                    {
                        isRoomAvailable = false;
                        break;
                    }
                }

                if (isRoomAvailable)
                {
                    availableRooms.Add(room);
                }
            }

            return availableRooms;
        }

        public Booking BookRoom(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            Room selectedRoom = availableRooms.Find(room => room.RoomId == roomId);

            if (selectedRoom == null)
            {
                throw new Exception("Room not found.");
            }

            Booking newBooking = new Booking(nextBookingId, roomId, checkInDate, checkOutDate);
            bookings.Add(newBooking);
            nextBookingId++;

            return newBooking;
        }
    }
}
