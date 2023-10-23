using System;
using System.Collections.Generic;

// Customer class
public class Customer
{
    public int CustomerId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public Customer(int customerId, string lastName, string firstName, string street, string city, string state, string zipCode, string phone, string email, string password)
    {
        CustomerId = customerId;
        LastName = lastName;
        FirstName = firstName;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Phone = phone;
        Email = email;
        Password = password;
    }
}

// RetailCustomer class inherits from Customer
public class RetailCustomer : Customer
{
    public string CreditCardType { get; set; }
    public string CreditCardNo { get; set; }

    public RetailCustomer(int customerId, string lastName, string firstName, string street, string city, string state, string zipCode, string phone, string email, string password, string creditCardType, string creditCardNo)
        : base(customerId, lastName, firstName, street, city, state, zipCode, phone, email, password)
    {
        CreditCardType = creditCardType;
        CreditCardNo = creditCardNo;
    }
}

// Reservation class
public class Reservation
{
    public int ReservationNo { get; set; }
    public DateTime Date { get; set; }
    public Seat ReservedSeat { get; set; }
    public Customer Customer { get; set; }

    public Reservation(int reservationNo, DateTime date, Seat reservedSeat, Customer customer)
    {
        ReservationNo = reservationNo;
        Date = date;
        ReservedSeat = reservedSeat;
        Customer = customer;
    }
}

// Seat class
public class Seat
{
    public int RowNo { get; set; }
    public string SeatNo { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
    public Flight Flight { get; set; } // Associate the seat with a flight

    public Seat(int rowNo, string seatNo, decimal price, string status)
    {
        RowNo = rowNo;
        SeatNo = seatNo;
        Price = price;
        Status = status;
    }
}

// Flight class
public class Flight
{
    public int FlightId { get; set; }
    public DateTime Date { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int SeatingCapacity { get; set; }
    public List<Seat> Seats { get; set; }

    public Flight(int flightId, DateTime date, string origin, string destination, DateTime departureTime, DateTime arrivalTime, int seatingCapacity, List<Seat> seats)
    {
        FlightId = flightId;
        Date = date;
        Origin = origin;
        Destination = destination;
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
        SeatingCapacity = seatingCapacity;
        Seats = seats;
    }
}

class Program
{
    static void Main()
    {
        RetailCustomer retailCustomer1 = new RetailCustomer(1, "Sikandar", "Tareen", "456 St", "Multan", "Punjab", "90001", "9876543210", "sik@gmail.com", "password", "Visa", "1234 5678 9012 3459");

        Seat seat1 = new Seat(1, "A1", 100.00m, "Available");
        seat1.Flight = new Flight(101, DateTime.Now, "There", "Here", DateTime.Now, DateTime.Now.AddHours(6), 200, new List<Seat> { seat1 });

        Reservation reservation1 = new Reservation(1001, DateTime.Now, seat1, retailCustomer1);

        // Call the function to print out the information
        PrintReservationInformation(reservation1);
    }

    static void PrintReservationInformation(Reservation reservation)
    {
        Console.WriteLine("Retail Customer Information:");
        Console.WriteLine($"Customer ID: {reservation.Customer.CustomerId}");
        Console.WriteLine($"Name: {reservation.Customer.FirstName} {reservation.Customer.LastName}");
        Console.WriteLine($"Address: {reservation.Customer.Street}, {reservation.Customer.City}, {reservation.Customer.State} {reservation.Customer.ZipCode}");
        Console.WriteLine($"Phone: {reservation.Customer.Phone}");
        Console.WriteLine($"Email: {reservation.Customer.Email}");
        Console.WriteLine($"Credit Card Type: {((RetailCustomer)reservation.Customer).CreditCardType}");
        Console.WriteLine($"Credit Card Number: {((RetailCustomer)reservation.Customer).CreditCardNo}");

        Console.WriteLine("\nFlight Information:");
        Console.WriteLine($"Flight ID: {reservation.ReservedSeat.Flight.FlightId}");
        Console.WriteLine($"Origin: {reservation.ReservedSeat.Flight.Origin}");
        Console.WriteLine($"Destination: {reservation.ReservedSeat.Flight.Destination}");
        Console.WriteLine($"Departure Time: {reservation.ReservedSeat.Flight.DepartureTime}");
        Console.WriteLine($"Arrival Time: {reservation.ReservedSeat.Flight.ArrivalTime}");

        Console.WriteLine("\nReservation Information:");
        Console.WriteLine($"Reservation Number: {reservation.ReservationNo}");
        Console.WriteLine($"Reservation Date: {reservation.Date}");
        Console.WriteLine($"Reserved Seat: Row {reservation.ReservedSeat.RowNo}, Seat {reservation.ReservedSeat.SeatNo}");
    }
}
