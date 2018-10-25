module Account.Specification.Operations

open Account.Specification.Language
open GetRide.Core

type AddPaymantType = Account -> NotValidatedCardType -> Result<ValidatedCardType, ErrorDescription>
type RemovePaymantType = Account -> ValidatedCardType -> unit 

type Pay = ValidatedCardType ->  Fee -> Result<TransactionId, ErrorDescription>

type QueryHistory = Account -> TransactionHistory