namespace Account.Specification.Language

open GetRide.Core
open System.ComponentModel.Design

type CardNumber = CardNumber of int
type SecurityCode = SecurityCode of int

type Month = | January | February | March | April 
                     | May | June |July | August 
                     | September | October | November | December 


type ExpirationDate = {
    MM: Month
    YY: TwoDigitYear
}

type CardType = | Mastercard | Visa | AmericanExpress | Discover

type Card = private {
    Type: CardType
    Holder: Person
    CardNumber: CardNumber
    ExpirationDate: ExpirationDate
    BillingAddress: Address
    SecurityCode: SecurityCode
}

type NotValidatedCardType = {
    Card: Card
}

type ValidatedCardType = {
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