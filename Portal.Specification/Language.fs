module Portal.Specification.Language

type Latitude = Latitude of int
type Longtitude = Longtitude of int 

type GPSCoordinate = Latitude * Longtitude

type Address = {
    Address1: string
    Address2: string
    City: string
    State: string
    Postal: string
}

type Destination = Address

type Pickup =
    | Current of GPSCoordinate
    | Address of Address

type FirstName = FirstName of string
type LastName = LastName of string

type Person = {
    FirstName: FirstName
    LastName: LastName
}

type Passenger = Passenger of Person

type Driver = Driver of Person

type Make = Make of string
type Model = Model of string
type TwoDigitYear = TwoDigitYear of int
type Color = | Red | Green | Blue | Yellow | Black 
             | White | Purple | Brown | Orange | Gray


type Vehicle = {
    Make: Make
    Model: Model 
    Year: TwoDigitYear
    Color: Color
}

type Ride = {
    Driver: Driver
    Vehicle: Vehicle
}