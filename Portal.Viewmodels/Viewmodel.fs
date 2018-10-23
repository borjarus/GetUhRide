namespace Portal.Viewmodels

open UILogic 
open System.Windows.Input
open Portal.Specification.Operations
open Portal.Specification.Language
open Portal.Domain.Converters
open GetRide.Core

type GetRide(passenger: Passenger, query: RideQuery) as x =
    let canRequest() =
        if x.Pickup <> "" &&
           x.Destination <> ""
        then true
        else false

    let mutable pickup = ""
    let mutable destination = ""
    let mutable ride = Error <| ErrorDescription "Waiting on input"
    let mutable isAvailable = false

    let requestRide() = 
        x.Ride <- (passenger, pickup |> generatePickup, destination |> generateDestination) |||> query

        x.Ride
          |> function
            | Ok result -> 
                result |> function
                        | Some _ -> x.IsRideAvailable <- true
                        | None -> x.IsRideAvailable <- false
                        
            | Error _ -> failwith ""

    member x.Pickup with get() = pickup
                       and set(v) = pickup <- v
    
    member x.Destination with get() = destination
                         and set(v) = destination <- v

    member x.Ride with get() = ride
                         and set(v) = ride <- v
                         
    member x.IsRideAvailable with get() = isAvailable
                                and set(v) = isAvailable <- v

                         
    member x.Request = DelegateCommand( (fun _ -> requestRide()), (fun _ -> canRequest())) :> ICommand