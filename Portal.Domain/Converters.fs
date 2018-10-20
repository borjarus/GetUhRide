module Portal.Domain.Converters

open Portal.Specification.Language

let generatePickup (pickupText:string):Pickup =
    let isGPSCordinate text = false

    if pickupText |> isGPSCordinate
    then Current <| (Latitude 123, Longtitude 456) 
    else Address { Address1 =   "not implemented"
                   Address2 =   "not implemented"
                   City =       "not implemented"
                   State =      "not implemented"
                   Postal =     "not implemented"}

let generateDestination (destinationText:string): Destination =
    {   Address1 =   "not implemented"
        Address2 =   "not implemented"
        City =       "not implemented"
        State =      "not implemented"
        Postal =     "not implemented"}