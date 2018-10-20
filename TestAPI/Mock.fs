namespace TestAPI

module Mock =
    open Portal.Specification.Language
    open Portal.Specification.Operations

    let somePickup = "21 Jump st"
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
    
    let someRide = {
        Driver = someDriver
        Vehicle = someVehicle
    }

    let rideQuery: RideQuery =
        fun _ _ _ -> Some someRide