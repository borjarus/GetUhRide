namespace TestAPI



module Mock =
    open Portal.Specification.Language
    open Portal.Specification.Operations
    open GetRide.Core

    let someLocation = "21 Jump st"
    let someUnsupportedLocation = "E 100th & Hough"
    let someDestination = "E99 & St Claaire"
    
    let somePassenger = Passenger {
        FirstName = FirstName "Scott"
        LastName = LastName "Nimrod"
    }

    let someDriver = Driver {
        FirstName = FirstName "John"
        LastName = LastName "Roach"
    }

    let someVehicle = {
        Make = Make "Honda"
        Model = Model "Accord"
        Year = TwoDigitYear 99
        Color = Red
    }

    let someRideId = RideId "some_ride_id"
    
    let someRide = {
        RideId = someRideId
        Driver = someDriver
        Vehicle = someVehicle
    }

    let rideQuery: RideQuery =
        fun _ _ _ -> Ok <| Some someRide

    let nonfavorableRideQuery: RideQuery =
        fun _ _ _ -> Ok None