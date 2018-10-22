module Portal.Specification.Operations

open Portal.Specification.Language
open GetRide.Core

type RideQuery = Passenger -> Pickup -> Destination -> Result<Ride option, ErrorDescription>
