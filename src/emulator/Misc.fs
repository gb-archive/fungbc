﻿module Misc

open Microsoft.FSharp.Reflection

///Returns the case name of the object with union type 'ty.
let GetUnionCaseName (x:'a) = 
    match FSharpValue.GetUnionFields(x, typeof<'a>) with
    | case, _ -> case.Name  

///Returns the case names of union type 'ty.
let GetUnionCaseNames<'ty> () = 
    FSharpType.GetUnionCases(typeof<'ty>) |> Array.map (fun info -> info.Name)

let parseHex str = try Some <| System.Int64.Parse(str, System.Globalization.NumberStyles.HexNumber) with | _ -> None

let inline (|Range|_|) from _to value =
    if value >= from && value <= _to then
        Some (value - from)
    else
        None