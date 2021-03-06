﻿module Ride.Tests.GetRide

open NUnit.Framework
open FsUnit
open Ride.Viewmodels
open TestAPI

[<Test>]
let ``Providing pickup and destination result in ride`` () = 
    // Setup
    let viewmodel = GetRide(Mock.somePassenger, Mock.request)

    viewmodel.Pickup <- Mock.someLocation
    viewmodel.Destination <- Mock.someDestination
    
    // Test
    viewmodel.Request.Execute()
    

    // Verify
    viewmodel.Ride 
        |> function
            | Ok result -> result |> function
                                    | Some v -> v |> should equal Mock.someRide
                                    | None -> failwith ""
            | Error _ -> failwith ""

[<Test>]
let ``Providing not supported pickup and destination doesn't result in ride`` () = 
    // Setup
    let request = { Mock.request with Ride = Mock.nonFavorableRideQuery}
    let viewmodel = GetRide(Mock.somePassenger, request)

    viewmodel.Pickup <- Mock.someUnsupportedLocation
    viewmodel.Destination <- Mock.someDestination
    
    // Test
    viewmodel.Request.Execute()
    

    // Verify
    viewmodel.Ride 
      |> function
            | Ok result -> 
                result |> function
                        | None -> ()
                        | Some _ -> failwith ""
                        
            | Error _ -> failwith ""


[<Test>]
let ``Providing not supported pickup communicates no ride available`` () = 
    // Setup
    let viewmodel = GetRide(Mock.somePassenger, Mock.request)

    viewmodel.Pickup <- Mock.someUnsupportedLocation
    viewmodel.Destination <- Mock.someDestination
    
    // Test
    viewmodel.Request.Execute()
    

    // Verify
    //viewmodel.IsRideAvailable |> should equal false


[<Test>]
let ``Providing supported pickup communicates ride available`` () = 
    // Setup
    let viewmodel = GetRide(Mock.somePassenger, Mock.request)

    viewmodel.Pickup <- Mock.someLocation
    viewmodel.Destination <- Mock.someDestination
    
    // Test
    viewmodel.Request.Execute()
    

    // Verify
    viewmodel.IsRideAvailable |> should equal true