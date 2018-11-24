namespace Ride.Viewmodels

open UILogic 
open System.Windows.Input
open Ride.Specification.Operations
open Ride.Specification.Language
open Ride.Domain.Converters
open GetRide.Core

type GetRide(passenger: Passenger, request: Request (* query: RequestRide *)) as x =
    let canRequest() =
        if x.Pickup <> "" &&
           x.Destination <> ""
        then true
        else false

    let mutable pickup = ""
    let mutable destination = ""
    let mutable ride = Error <| ErrorDescription "Waiting on input"
    let mutable isAvailable = false
    let mutable cancelled = false

    let cancelRide() = 
        x.Ride |> function
                    | Ok result ->
                        result |> function 
                        | Some pending -> request.Cancel pending |> ignore
                                          x.Cancelled <- true
                        | None         -> x.Cancelled <- false                          
                    | Error _ -> ()  

    let requestRide() = 
        x.Ride <- (passenger, pickup |> generatePickup, destination |> generateDestination) |||> request.Ride

        x.Ride |> function
            | Ok _ -> x.IsRideAvailable <- true
            | Error _ -> x.IsRideAvailable <- false
                

    member x.Pickup             with get()  = pickup
                                and set(v)  = pickup <- v
     
    member x.Destination        with get()  = destination
                                and set(v)  = destination <- v

    member x.Ride               with get()  = ride
                                and set(v)  = ride <- v
                         
    member x.IsRideAvailable    with get()  = isAvailable
                                and set(v)  = isAvailable <- v

    member x.Cancelled          with get()  = cancelled
                                and set(v)  = cancelled <- v

                         
    member x.Request = DelegateCommand( (fun _ -> requestRide()), (fun _ -> canRequest())) :> ICommand
    member x.Cancel = DelegateCommand( (fun _ -> cancelRide(); x.Cancelled <- true), 
                                        fun _ -> true ) :> ICommand