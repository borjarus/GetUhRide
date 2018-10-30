namespace Account.Specification.Language

open GetRide.Core
open System.Reflection
open System.Runtime.CompilerServices

[<assembly:InternalsVisibleTo("TestAPI")>]
do()

type CardNumber = CardNumber of int64
type SecurityCode = SecurityCode of int

type Month = | January | February | March | April 
             | May | June |July | August 
             | September | October | November | December 
             | Undefined


type ExpirationDate = {
    MM: Month
    YY: TwoDigitYear
}

type CardType = | Mastercard | Visa | AmericanExpress | Discover | Invalid

type Card = {
    Type: CardType
    Holder: Person
    CardNumber: CardNumber
    ExpirationDate: ExpirationDate
    BillingAddress: Address
    SecurityCode: SecurityCode
}

type NotValidatedCard = {
    Card: Card
}

type ValidatedCard = internal {
    Card: Card
}

type TransactionId = private TransactionId of string

type PaymentTransaction = {
    RideId: RideId
    TransactionId: TransactionId
    Ride: Ride
}

[<Measure>]
type USD

type Fee = decimal<USD>



type TransactionHistory = PaymentTransaction list

type AddPaymantTypeFailureReason =
    | Connection of string
    | HolderName' of string
    | ExpirationMonth' of string
    | ExpirationYear' of string
    | SecurityCode' of string
    | CardNumber' of string
    | CardType' of string