module Ride.Specification.Events

type RideState =
    | RideRequested     // of Passenger
    | PendingRide       // of PendingRide
    | RideCancelled     // of RideCancelled
    | InRoute           // of InRoute
    | RideEnded         // of RideEnded

