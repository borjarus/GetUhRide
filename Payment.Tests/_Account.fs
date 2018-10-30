module _Account.Tests

open NUnit.Framework
open FsUnit
open Account.Viewmodels
open TestAPI


[<Test>]
let ``Valid card result in successful 'Add paymant type' operation`` () =
    // Setup
    let viewmodel = PaymantTypes(Mock.someAccount, Mock.successfulAttempt, [])
    viewmodel.PaymantType <- "Visa"
    viewmodel.FirstName <- Mock.someFirstName
    viewmodel.LastName <- Mock.someLastName
    viewmodel.SecurityNumber <- Mock.someSecurityNumber
    viewmodel.ExpirationMonth <- Mock.someExpirationMonth
    viewmodel.ExpirationYear <- Mock.someExpirationYear
    viewmodel.CardNumber <- Mock.someCardNumber

    // Test
    viewmodel.AddPaymentType.Execute()

    // Verify
    viewmodel.PaymantTypeAccepted |> should equal  true