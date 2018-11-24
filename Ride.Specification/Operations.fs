module Ride.Specification.Operations

open Ride.Specification.Language
open GetRide.Core

type Login = Credentials -> Account
type Logout = Credentials -> Account

type RequestRide = Passenger -> Pickup -> Destination -> Result<PendingRide option, ErrorDescription>

type CancelRide = PendingRide -> CancelledRide option

type Request = {
    Ride: RequestRide
    Cancel: CancelRide
}
