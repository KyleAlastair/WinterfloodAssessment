using BookingsConsoleApp;
using System;
using System.Collections.Generic;

namespace InMemoryBookingApp
{
    class Program:BookingsModel
    {
        static List<BookingsModel> bookings = new List<BookingsModel>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMainMenu();
                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": ListBookings(); break;
                    case "2": AddBooking(); break;
                    case "3": EditBooking(); break;
                    case "4": DeleteBooking(); break;
                    case "5": return;
                    default: Console.WriteLine("Invalid choice. Try again.\n"); break;
                }
            }
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("=== Booking Manager ===");
            Console.WriteLine("1) List all bookings");
            Console.WriteLine("2) Add a booking");
            Console.WriteLine("3) Edit a booking");
            Console.WriteLine("4) Delete a booking");
            Console.WriteLine("5) Exit");
            Console.Write("Select an option: ");
        }

        static void ListBookings()
        {
            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings found.\n");
                return;
            }

            Console.WriteLine("Current bookings:");
            foreach (var b in bookings)
            {
                Console.WriteLine($"[{b.BookingId}] {b.NameOfPersonBooking} create booking on: {b.DateOfBooking} for the service - ({b.BookingService})");
            }
            Console.WriteLine();
        }

        static void AddBooking()
        {
            Console.Write("Enter customer name: ");
            var name = Console.ReadLine().Trim();

            Console.Write("Enter booking date (YYYY-MM-DD): ");
            var date = Console.ReadLine().Trim();

            Console.Write("Enter service type: ");
            var service = Console.ReadLine().Trim();

            var booking = new BookingsModel
            {
                BookingId = nextId++,
                NameOfPersonBooking = name,
                DateOfBooking = date,
                BookingService = service
            };
            bookings.Add(booking);

            Console.WriteLine($"Booking added with ID {booking.BookingId}.\n");
        }

        static void EditBooking()
        {
            Console.Write("Enter the BookingID of the booking to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid BookingID format.\n");
                return;
            }

            var booking = bookings.Find(b => b.BookingId == id);
            if (booking == null)
            {
                Console.WriteLine("Booking not found.\n");
                return;
            }

            Console.Write($"Name [{booking.NameOfPersonBooking}]: ");
            var name = Console.ReadLine().Trim();
            Console.Write($"Date [{booking.DateOfBooking}]: ");
            var date = Console.ReadLine().Trim();
            Console.Write($"Service [{booking.BookingService}]: ");
            var service = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(name)) booking.NameOfPersonBooking = name;
            if (!string.IsNullOrEmpty(date)) booking.DateOfBooking = date;
            if (!string.IsNullOrEmpty(service)) booking.BookingService = service;

            Console.WriteLine("Booking updated successfully.\n");
        }

        static void DeleteBooking()
        {
            Console.Write("Enter the BookingID of the booking to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid BookingID format.\n");
                return;
            }

            var removed = bookings.RemoveAll(b => b.BookingId == id) > 0;
            Console.WriteLine(removed ? "Booking deleted.\n" : "Booking not found.\n");
        }
    }
}