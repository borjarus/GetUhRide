module _Account.Tests

open NUnit.Framework
open FsUnit
open Account.Viewmodels
open TestAPI


[<Test>]
let ``Valid card result in successful 'Add paymant type' operation`` () =
    // Setup
    let viewmodel = AddPaymantTypes(Mock.someAccount, Mock.successfulAttempt, [])
    viewmodel.PaymantType <- "Visa"
    viewmodel.Name <- Mock.someName
    viewmodel.SecurityNumber <- Mock.someSecurityNumber
    viewmodel.ExpirationMonth <- Mock.someExpirationMonth
    viewmodel.ExpirationYear <- Mock.someExpirationYear
    viewmodel.CardNumber <- Mock.someCardNumber

    // Test
    viewmodel.AddPaymentType.Execute()

    // Verify
    viewmodel.PaymantTypeAccepted |> should equal  true

[<Test>]
let ``Remove paymant type`` () =
    // Setup
    let viewmodel = RemovePaymantTypes(Mock.someAccount, Mock.successfulAttempt, [])
    viewmodel.Card <- Mock.validatedCard

    // Test
    viewmodel.RemovePaymentType.Execute()

    // Verify
    viewmodel.PaymantTypeRemoved |> should equal  true


//[<Test>]
//let ``Adding new card result in successful updated list of paymentTypes `` () =
//    // Setup
//    let viewmodel = AddPaymantTypes(Mock.someAccount, Mock.successfulAttempt, [])
    
//    "Visa" |> Mock.setPaymantType viewmodel 
//    // Test
//    viewmodel.AddPaymentType.Execute()

//    // Verify
//    viewmodel.PaymantTypeAccepted |> should equal  true