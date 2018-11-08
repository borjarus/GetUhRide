module GetRide.Core

let broadcast handlers msg = () // todo

type ErrorDescription = ErrorDescription of string

type Username = Username of string
type Password = Password of string

type FirstName = FirstName of string
type LastName = LastName of string

type Person = {
    FirstName: FirstName
    LastName: LastName
}

type TwoDigitYear = TwoDigitYear of int

type Address = {
    Address1: string
    Address2: string
    City: string
    State: string
    Postal: string
}

type AccountId = AccountId of int

type Credentials = {
    Username: Username
    Password: Password
}

type Account = {
    Id: AccountId
    Holder: Person
    BillingAddress: Address
}

type Driver = Driver of Person

type Make = Make of string
type Model = Model of string
type Color = | Red | Green | Blue | Yellow | Black 
             | White | Purple | Brown | Orange | Gray

type Vehicle = {
    Make: Make
    Model: Model 
    Year: TwoDigitYear
    Color: Color
}

type RideId = RideId of string

type Ride = {
    RideId: RideId    
    Driver: Driver
    Vehicle: Vehicle
}
