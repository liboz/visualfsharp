module M
type EnumABC = A = 0 | B = 1 | C = 42
type UnionAB = A | B

module FS0025 =
    // All of these should emit warning FS0025 ("Incomplete pattern match....")
        

    let f1 = function
        | UnionAB.A -> "A"

    let f2 = function
        | 42 -> "forty-two"

    let f3 = function
        | EnumABC.A -> "A"
    
    let f4 = function
        | EnumABC.A -> "A"
        | EnumABC.B -> "B"

    let f5 = function
        | Some(EnumABC.A) | Some(EnumABC.B) -> "A|B"
        | None -> "neither"

module FS0104 =
    // These should emit warning FS0104 ("Enums may take values outside of known cases....")

    let f1 = function
        | EnumABC.A -> "A"
        | EnumABC.B -> "B"
        | EnumABC.C -> "C"

    let f2 = function
        | Some(EnumABC.A) -> "A"
        | Some(EnumABC.B) -> "B"
        | Some(EnumABC.C) -> "C"
        | None -> "none"