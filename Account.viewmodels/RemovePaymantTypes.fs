namespace Account.Viewmodels

open System.Windows.Input
open GetRide.Core
open UILogic
open Account.Specification.Operations



type RemovePaymantTypes(account: Account, attempt: Attempt, handlers) as x  =
    let mutable card = None
    let mutable cards= []

    let mutable paymantTypeRemoved = false

    let submit = function
        | Some card -> (account, card) ||> attempt.RemovePaymantType
                            |> function 
                                | Ok cards -> x.Cards <- cards; x.PaymantTypeRemoved <- true
                                | Error msg -> broadcast msg handlers
        | None -> x.PaymantTypeRemoved <- false

    member x.Card with get() = card
                  and set(v) = card <- v

    member x.Cards with get() = cards
                   and set(v)= cards <- v

    member x.RemovePaymentType = DelegateCommand((fun _ -> submit x.Card),(fun _ -> true)) :> ICommand

    member x.PaymantTypeRemoved with get() = paymantTypeRemoved
                                 and set (v) = paymantTypeRemoved <- v