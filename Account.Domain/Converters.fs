module Account.Domain

open Account.Specification.Language

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