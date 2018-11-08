namespace Account.Viewmodels

open System
open System.Windows.Input
open GetRide.Core
open UILogic
open Account.Specification.Language
open Account.Specification.Operations
open Account.Domain



type AddPaymantTypes(account: Account, attempt: Attempt, handlers) as x =
    let mutable cardType = ""
    let mutable name = ""
    let mutable cardNumber = ""
    let mutable securityCode = ""
    let mutable expirationMonth = ""
    let mutable expirationYear = ""

    let mutable paymantTypeAccepted = false
    let mutable addedCard = None

    let holder = account.Holder

    let notValidatedCard ()=
        let card = {Type = cardType |> toType
                    Holder= holder
                    CardNumber= CardNumber <| Int64.Parse(cardNumber)
                    ExpirationDate= { MM = expirationMonth |> toMonth 
                                      YY = TwoDigitYear <| Int32.Parse(expirationYear) }
                    BillingAddress= account.BillingAddress
                    SecurityCode= SecurityCode <| Int32.Parse(securityCode) }

        { NotValidatedCard.Card = card }

    let submit() = 
        (account, notValidatedCard()) 
        ||> attempt.AddPaymantType
        |> function
            | Ok card -> x.PaymantTypeAccepted <- true
                         x.AddedCard <- Some card

            | Error msg -> msg |> broadcast handlers


    member x.PaymantType with get() = cardType
                         and set(v) = cardType <- v

    member x.Name with get () = name
                        and set(v) = name <- v

    member x.SecurityNumber with get () = securityCode
                            and set(v) = securityCode <- v

    member x.ExpirationMonth with get() = expirationMonth
                                and set(v)= expirationMonth <- v

    member x.ExpirationYear with get() = expirationYear
                                and set(v)= expirationYear <- v

    member x.CardNumber with get() = cardNumber
                                and set(v)= cardNumber <- v
                                
    member x.PaymantTypeAccepted with get() = paymantTypeAccepted
                                    and set (v) = paymantTypeAccepted <- v

    member x.AddedCard with get() = addedCard
                                and set (v) = addedCard <- v

    member x.AddPaymentType = DelegateCommand((fun _ -> submit()),(fun _ -> true)) :> ICommand

