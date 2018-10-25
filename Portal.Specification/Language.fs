module Portal.Specification.Language

open GetRide.Core

type Latitude = Latitude of int
type Longtitude = Longtitude of int 

type GPSCoordinate = Latitude * Longtitude

type Destination = Address

type Pickup =
    | Current of GPSCoordinate
    | Address of Address

type Passenger = Passenger of Person