module Ride.Domain.Converters

open Ride.Specification.Language

let generatePickup (pickup:string):Pickup =
    let isGPSCordinate text = false // TODO

    if pickup |> isGPSCordinate
    then Current <| (Latitude 123, Longtitude 456) 
    else Address { Address1 =   "not implemented"
                   Address2 =   "not implemented"
                   City =       "not implemented"
                   State =      "not implemented"
                   Postal =     "not implemented"}

let generateDestination (destination:string): Destination =
    {   Address1 =   "not implemented"
        Address2 =   "not implemented"
        City =       "not implemented"
        State =      "not implemented"
        Postal =     "not implemented"}