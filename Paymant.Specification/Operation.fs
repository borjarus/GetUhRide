module Account.Specification.Operations

open Account.Specification.Language
open GetRide.Core

type AddPaymantType = Account -> NotValidatedCard -> Result<ValidatedCard, AddPaymantTypeFailureReason>
type RemovePaymantType = Account -> ValidatedCard -> Result<ValidatedCard list, ErrorDescription> 

type Pay = ValidatedCard ->  Fee -> Result<TransactionId, ErrorDescription>

type QueryHistory = Account -> TransactionHistory

type Attempt = {
    AddPaymantType: AddPaymantType
    RemovePaymantType: RemovePaymantType
}