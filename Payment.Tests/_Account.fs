module _Account.Tests

open NUnit.Framework
open FsUnit
open Account.Viewmodels
open TestAPI


[<Test>]
let ``Valid card result in successful 'add bank card' operation`` () =
    // Setup
    let viewmodel = AddBankCard(Mock.someAccount, Mock.successfulAttempt, [])
    viewmodel.BankCard <- "Visa"
    viewmodel.HolderName <- Mock.someName
    viewmodel.SecurityNumber <- Mock.someSecurityNumber
    viewmodel.ExpirationMonth <- Mock.someExpirationMonth
    viewmodel.ExpirationYear <- Mock.someExpirationYear
    viewmodel.CardNumber <- Mock.someCardNumber

    // Test
    viewmodel.AddBankCard.Execute()

    // Verify
    viewmodel.PaymantTypeAccepted |> should equal  true

[<Test>]
let ``Remove bank card`` () =
    // Setup
    let viewmodel = RemovePaymantTypes(Mock.someAccount, Mock.successfulAttempt, [])
    viewmodel.Card <- Mock.validatedCard "Visa"

    // Test
    viewmodel.RemoveBankCard.Execute()

    // Verify
    viewmodel.PaymantTypeRemoved |> should equal  true

[<Test>]
let ``Remove the only bank card results in no card`` () =
    // Setup
    let viewmodel = RemovePaymantTypes(Mock.someAccount, Mock.successfulAttempt, [])
    Mock.someCardName 
    |> Mock.validatedCard 
    |> function 
        | Some c -> viewmodel.Cards <- [c]
                    viewmodel.Card <- Some c
        | None -> failwith ""

    // Test
    viewmodel.RemoveBankCard.Execute()

    // Verify
    viewmodel.Cards |> should equal  []

[<Test>]
let ``Remove bank card results in one less card in set`` () =
    // Setup
    let viewmodel = RemovePaymantTypes(Mock.someAccount, Mock.successfulAttempt, [])

    let someCard = Mock.someCardName |> Mock.validatedCard 
    let otherCard = Mock.someOtherCardName |> Mock.validatedCard 

    viewmodel.Cards <- [someCard.Value; otherCard.Value]
    viewmodel.Card <- someCard

    // Test
    viewmodel.RemoveBankCard.Execute()

    // Verify
    viewmodel.Cards |> should equal  [otherCard.Value]
