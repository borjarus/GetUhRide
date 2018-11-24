module Ride.Tests.CancelRide

open NUnit.Framework
open FsUnit
open Ride.Viewmodels
open TestAPI

[<Test>]
let ``Cancel pending Ride``() = 
    //Setup
    let viewmodel = GetRide(Mock.somePassenger, Mock.request)

    viewmodel.Pickup <- Mock.someLocation
    viewmodel.Destination <- Mock.someDestination
    viewmodel.Request.Execute()
    
    // Test
    viewmodel.Cancel.Execute()

    // Test

    // Verify
    viewmodel.Cancelled |> should equal true
