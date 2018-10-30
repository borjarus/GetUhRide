namespace Account.Viewmodels

open System
open System.Windows.Input
open GetRide.Core
open UILogic
open Account.Specification.Language
open Account.Specification.Operations



type PaymantTypes(account: Account, attempt: Attempt, handlers) as x =
    let mutable cardType = ""
    let mutable cardNumber = ""
    let mutable securityNumber = ""
    let mutable expirationMonth = ""
    let mutable expirationYear = ""
    let mutable paymantTypeAccepted = false
    let mutable firstName = ""
    let mutable lastName = ""
    let mutable expirationMonth = ""
    let mutable expirationYear = ""
    let mutable cardNumber = ""

    let toType (text: string) = text.ToLower() |> function
        | "visa" -> Visa
        | "mastercard" -> Mastercard
        | "american express" -> AmericanExpress
        | "discover" -> Discover
        | _ -> Invalid
   
    let toMonth (text: string) = text.ToLower() |> function
            | "01" -> January | "02" -> February | "03" -> March | "04" -> April
            | "05" -> May | "06" -> June | "07" -> July | "08" -> August
            | "09" -> September | "10" -> October | "11" -> November | "12" -> December
            | _ -> Undefined

    let holder = account.Holder

    let notValidatedCard()=
        let card = {Type = cardType |> toType
                    Holder= holder
                    CardNumber= CardNumber <| Int64.Parse(cardNumber)
                    ExpirationDate= { MM = expirationMonth |> toMonth 
                                      YY = TwoDigitYear <| Int32.Parse(expirationYear) }
                    BillingAddress= account.BillingAddress
                    SecurityCode= SecurityCode <| Int32.Parse(securityNumber) }

        { NotValidatedCard.Card = card }

    let broadcast handlers msg = 
        () // todo

    let submit() = 
        (account, notValidatedCard()) 
        ||> attempt.AddPaymantType
        |> function
            | Ok _ -> x.PaymantTypeAccepted <- true
            | Error msg -> msg |> broadcast handlers


    member x.PaymantType with get() = cardType
                         and set(v) = cardType <- v

    member x.FirstName with get () = firstName
                        and set(v) = firstName <- v

    member x.LastName with get () = lastName
                        and set(v) = lastName <- v

    member x.SecurityNumber with get () = securityNumber
                            and set(v) = securityNumber <- v

    member x.ExpirationMonth with get() = expirationMonth
                                and set(v)= expirationMonth <- v

    member x.ExpirationYear with get() = expirationYear
                                and set(v)= expirationYear <- v

    member x.CardNumber with get() = cardNumber
                                and set(v)= cardNumber <- v

    member x.AddPaymentType = DelegateCommand((fun _ -> submit()),(fun _ -> true)) :> ICommand

    member x.PaymantTypeAccepted with get() = paymantTypeAccepted
                                 and set (v) = paymantTypeAccepted <- v