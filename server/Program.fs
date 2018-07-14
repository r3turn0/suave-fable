open Suave
open Suave.Operators
open Suave.Filters

let directoryOf path = System.IO.Path.GetDirectoryName path
let combinePath suffix prefix = System.IO.Path.Combine(prefix,suffix)
let homeFolder = 
    let assm = System.Reflection.Assembly.GetExecutingAssembly()
    assm.Location |> directoryOf |> directoryOf |> directoryOf |> directoryOf |> directoryOf |> combinePath @"client\public"

let gotHere (msg:string) =
    fun ctx ->
        printfn "Got Here: %s" msg
        async {
            return Some ctx
        }

let app =
    choose [
        path "/" >=> gotHere "matched /" >=> Files.sendFile (System.IO.Path.Combine(homeFolder,"index.html")) false >=> gotHere "sending index.html"
        path "/root" >=> gotHere "matched /root" >=> Files.sendFile (System.IO.Path.Combine(homeFolder,"index.html")) false
        GET  >=> Files.browseHome
        gotHere "Opps I'm about to fail since there's nothing left to match"
        RequestErrors.NOT_FOUND "Page not found."
    ]

let config =
    { defaultConfig with
        homeFolder = homeFolder |> Some
        // bindings =
        //     [
        //         HttpBinding.createSimple Protocol.Http "0.0.0.0" 80
        //         HttpBinding.createSimple Protocol.Https sslCert "0.0.0.0" 443us
        //     ]        
    }

[<EntryPoint>]
let main(args:string[]) =
    startWebServer config app
    0
