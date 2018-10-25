module Portal.Specification.Operations

open Portal.Specification.Language
open GetRide.Core

type Login = Credentials -> Account
type Logout = Credentials -> Account

type RideQuery = Passenger -> Pickup -> Destination -> Result<Ride option, ErrorDescription>
