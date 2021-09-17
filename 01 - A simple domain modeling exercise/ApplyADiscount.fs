// Learn more about F# at http://fsharp.org

open System

type RegisteredCustomer = {Id : string}
type UnregisteredCustomer = {Id : string}

type Customer = 
    | EligibleRegistered of RegisteredCustomer
    | Registered of RegisteredCustomer
    | Guest of UnregisteredCustomer

let calulateTotal customer spend =
    let discount =
        match customer with
         | EligibleRegistered _ when spend >= 100.0M -> spend * 0.1M
         | _ -> 0.0M  
    spend - discount

let john = EligibleRegistered { Id = "John"}
let mary = EligibleRegistered { Id = "Mary"}
let richard = Registered { Id = "Richard"}
let sarah = Guest { Id = "Sarah"}

let assertJohn = calulateTotal john 100.0M = 90.0M
let assertMary = calulateTotal mary 99.0M = 99.0M
let assertRichard = calulateTotal richard 100.0M = 100.0M
let assertSarah = calulateTotal sarah 100.0M = 100.0M



