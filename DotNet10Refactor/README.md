# eratohoK Reborn — .NET 10 Refactor

This repository contains a .NET 10 refactoring of the eratohoK codebase. The goal is to replace legacy ERB scripts with a modern, modular C# implementation while keeping compatibility with original CSV data assets.

The refactor splits responsibilities into small projects:

- `eratohoK.Core` — core entities and immutable records (Character, Country, City, etc.)
- `eratohoK.Data` — CSV data access and loaders (character CSVs, definitions, items)
- `eratohoK.Semantics` — semantic text model and asset management (口上/portrayal)
- `eratohoK.GameEngine` — game systems (training, SLG, battle, events, save/load)
- `eratohoK.Cli`  — simple command-line front-end for testing and playing

## Project layout

```
DotNet10Refactor/
├── eratohoK.Reborn.sln
└── src/
    ├── eratohoK.Core/
    ├── eratohoK.Data/
    │   └── CsvDataReader.cs      # CSV loader and parsers
    ├── eratohoK.Semantics/
    ├── eratohoK.GameEngine/
    └── eratohoK.Cli/
```

## What changed in this update

- README translated to English and reorganized.
- CSV parsing improved: `CsvDataReader` now includes a robust line splitter that supports quoted fields and escaped quotes (RFC-like behavior). This makes the loader more tolerant of commas inside quoted text.
- Minor documentation to show how to build and run the CLI.

## Build and run

Prerequisites:
- .NET 10 SDK

Build:

```bash
cd DotNet10Refactor
dotnet build
```

Run CLI (point to the CSV folder):

```bash
dotnet run --project src/eratohoK.Cli/eratohoK.Cli.csproj -- ../CSV
```

If `../CSV` is missing, the CLI will fall back to built-in demo data.

## CSV parsing details

`eratohoK.Data/CsvDataReader.cs` provides utilities to read definition CSVs (Train, Item, Talent, etc.) and character CSVs under `Chara/`.

- The reader now uses an internal `SplitCsvLine(string)` method that correctly handles fields surrounded by double quotes and escaped quotes (`""`).
- Fields are returned raw and callers trim values as needed. The parser ignores lines starting with `;` and empty lines.

Example usage:

```csharp
using var csv = new CsvDataReader("../CSV");
var trainDefs = csv.ReadTrainDefinitions();
var characters = csv.LoadAllCharacters();
```

## Next steps / roadmap

1. Complete automatic conversion of ERB mouth/lines (口上) to semantic assets.
2. Expand CSV field coverage to match every CSV used by the original project.
3. Add a conversion tool for legacy saves (if required).
4. Provide a GUI front-end (Blazor/Avalonia) and automated test coverage.

## Contributing

Issues and pull requests are welcome. If you add CSV parsing for additional files, please include sample CSVs and unit tests demonstrating correct parsing of quoted fields.

## License

This project follows the licensing terms of the original eratohoK project.
