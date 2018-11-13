module Account.Specification.Operations

open Account.Specification.Language
open GetRide.Core

type AddBankCard = Account -> NotValidatedCard -> Result<ValidatedCard, AddPaymantTypeFailureReason>
type RemoveBankCard = Account -> ValidatedCard -> Result<ValidatedCard list, ErrorDescription> 

type Pay = ValidatedCard ->  Fee -> Result<TransactionId, ErrorDescription>

type QueryHistory = Account -> TransactionHistory

type Attempt = {
    AddPaymantType: AddBankCard
    RemovePaymantType: RemoveBankCard
}