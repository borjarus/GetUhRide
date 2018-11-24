module Ride.Specification.Language

open GetRide.Core
open GetRide.Core

type Latitude = Latitude of int
type Longtitude = Longtitude of int 

type GPSCoordinate = Latitude * Longtitude

type Destination = Address

type Pickup =
    | Current of GPSCoordinate
    | Address of Address

type Passenger = Passenger of Person

type CancallationId = CancallationId of string

type CancelledRide = {
    CancallationId: CancallationId
    Ride: PendingRide
}

type InRoute = {
    RideId: RideId
}

type RideEnded = {
    RideId: RideId
}

