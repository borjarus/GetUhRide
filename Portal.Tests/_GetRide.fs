module Portal.Tests.GetRide

open NUnit.Framework
open FsUnit
open Portal.Viewmodels
open TestAPI

[<Test>]
let ``Providing pickup and destination result ina ride`` () = 
    // Setup
    let viewmodel = GetRide(Mock.somePassenger, Mock.rideQuery)

    viewmodel.Pickup <- Mock.somePickup
    viewmodel.Destination <- Mock.someDestination
    
    // Test
    viewmodel.Request.Execute()
    

    // Verify
    viewmodel.Ride 
        |> function 
            | Some v -> should equal Mock.someRide
            | None -> failwith ""
