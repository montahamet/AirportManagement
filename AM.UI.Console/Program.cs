﻿// See https://aka.ms/new-console-template for more information


using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, Montaha!");
Plane p1 = new Plane();
p1.Capacity = 10;
p1.ManufactureDate = new DateTime(2024, 01, 29);
p1.planetype = PlaneType.Boing;
p1.PlanedId = 1;
Console.WriteLine(p1);
//Plane p2 = new Plane(PlaneType.Airbus, 150,DateTime.Now);
//Console.WriteLine(p2);
Plane p3 = new Plane { 
    Capacity = 10111,
    PlanedId = 1,
    planetype = PlaneType.Boing,


};
Console.WriteLine(p3);
Passenger P1 = new Passenger
{
    FirstName = "Test",
    LastName = "Test",
    EmailAddress = "Test",
};
Console.WriteLine(P1.CheckProfile("Test","Test"));
P1.PassengerType();
Console.WriteLine("********************");
Staff s = new Staff {
    
};
s.PassengerType();
Console.WriteLine("********************");
Traveller Traveller = new Traveller {} ;
Traveller.PassengerType();
FlightMethods FM = new FlightMethods { Flights = TestData.listFlights };
FM.GetFlights("Destination", "Paris");
Console.WriteLine("********************");
foreach (var item in FM.GetFlightDates("Madrid"))
{
    Console.WriteLine(item);
    
}
Console.WriteLine("*********delegue1***********");
//FM.ShowFlightDetails(TestData.BoingPlane);
FM.FlightDetailsDel(TestData.BoingPlane);
Console.WriteLine("********************");
Console.WriteLine(FM.ProgrammedFlightNumber(new DateTime(2022,01,01)));
Console.WriteLine("*******delegue2*************");
Console.WriteLine(FM.DurationAverage("Paris"));

Console.WriteLine("********************");
foreach (var item in FM.OrderedDurationFlights())
{
    Console.WriteLine(item);
    
}
Console.WriteLine("********************");
foreach (var item in FM.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(item);
}
Console.WriteLine("********************");
//FlightMethods FM = new FlightMethods { Flights = TestData.listFlights };
FM.DestinationGroupedFlights();
Console.WriteLine("********************");
//Console.WriteLine("Before" + pass1.FirstName + "" + pass1.LastName);
Passenger pass1= new Passenger() { FirstName ="montaha",LastName="metjaouel"};//initialiseur d objet
pass1.UpperFullName();
Console.WriteLine("After"+pass1.FirstName+""+pass1.LastName);

