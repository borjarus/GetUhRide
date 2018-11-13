namespace TestAPI



module Mock =
    open Portal.Specification.Language
    open Portal.Specification.Operations
    open GetRide.Core
    open Account.Specification.Operations
    open Account.Specification.Language
    open Account.Viewmodels

    let someLocation = "21 Jump st"
    let someUnsupportedLocation = "E 100th & Hough"
    let someDestination = "E99 & St Claaire"

    let someName = "Mike Jones"
    let someFirstName = "Mike"
    let someLastName = "Jones"
    let someSecurityNumber = "123"
    let someCardNumber = "12345678912345"

    let someExpirationMonth = "01"
    let someExpirationYear= "22"

    let someCardName = "visa"
    let someOtherCardName = "mastercard"
    
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
    
    let someAccountId = AccountId 123
    let someAddress = {
        Address1= "21 jump St"
        Address2= ""
        City = "East Cleveland"
        State = "Ohio"
        Postal = "90210"
    }

    let someAccount:Account = {
        Id = someAccountId
        Holder = { FirstName = FirstName "John";LastName = LastName "Roach" }
        BillingAddress = someAddress
    }
    let successfulAttempt:Attempt = {
        AddPaymantType= fun _ notValidatedCard -> Ok { ValidatedCard.Card= notValidatedCard.Card}
        RemovePaymantType= fun _ _ -> Ok []
    }

    let setPaymantType (viewmodel: AddBankCard) cardType = 
        viewmodel.BankCard <- cardType
        viewmodel.Name <-someName
        viewmodel.SecurityNumber <- someSecurityNumber
        viewmodel.ExpirationMonth <- someExpirationMonth
        viewmodel.ExpirationYear <- someExpirationYear
        viewmodel.CardNumber <- someCardNumber
    
    let validatedCard cardType = 
        let viewmodel = AddBankCard(someAccount, successfulAttempt, [])
    
        cardType |> setPaymantType viewmodel 
        viewmodel.AddBankCard.Execute()
        viewmodel.AddedCard
