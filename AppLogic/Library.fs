namespace AppLogic.Ride
open Ride.Specification.Events

module Notifications =
    



    let rideStateHandler = function
        | RideRequested   _ -> () 
        | PendingRide     _ -> () 
        | RideCancelled   _ -> () 
        | InRoute         _ -> () 
        | RideEnded       _ -> () 