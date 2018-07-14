# Basic Sauve Fable Scafold Project

This project implements a simple [Suave](https://suave.io/) - [Fable](http://fable.io/) web application scafold. Suave is the web server backend and Fable is used to compile the Website UI from F# to Javascript.

To Build this application you must:

1) Install [Daily .Net CORE 2.0.0 (Lastest Service Release)](https://github.com/dotnet/cli/blob/release/2.0.0/README.md#installers-and-binaries) or later first [Release .Net Core 2.0.0 (As of Aug 22 2017)](https://www.microsoft.com/net/core#windowscmd)
2) Install [Node.Js](https://nodejs.org)
3) Install [Yarn](https://yarnpkg.com/) package management tool as a global command line
4) run the build.cmd script (this will restore the project and then build it)
5) All other tools ([FAKE](https://fake.build), [Paket](http://fsprojects.github.io/Paket/)) are pulled down for you within the project.


## Notes about the server.fsproj and dotnet CLI tool

1. The dotnet CLI documentation can be found [here](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet).
1. To change the application from console to DLL simply remove the `<OutputType>` tag from the main `<PropertyGroup>` tag.
2. To generate an actual exe to run you must provide a `--runtime` argument to the `dotnet build` command.

    `dotnet build --runtime win10-x64`

    will generate a exe that supports running on 64bit Windows 10 devices. The list of possible runtimes is located here: [RIDs](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)

    this is only supported for `<OutputType>Exe</OutputType`

3. To specify a particular configuration to build or run specify the `-c` or `--configuration` argument. `Debug` is the default, specify `Release` to build the Release configuration.

4. `dotnet publish` can be used to generate a complete version of the application that can be run independent of anything else installed on the machine. I've used this for Azure Website Continuous Integration deployments since I can use versions of the dotnet framework that MAY or MAYNOT be installed yet. Alternatively you could then FTP this output directory to an Azure Website as well.

5. `dotnet clean` removes the generated files produced by a build in the `bin` and `obj` directories. Once the clean is done the directories WILL REMAIN, but the contents are cleaned up.

7. You can download an dotnet install script from the CLI repo [here](https://github.com/dotnet/cli/tree/rel/1.0.0/scripts/obtain) these scripts can be used to download and install any particular version of the sdk you need. See [`donet-install`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script) for details.