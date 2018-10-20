module Portal.Specification.Operations

open Portal.Specification.Language

type RideQuery = Passenger -> Pickup -> Destination -> Result<Ride option, string>
