# era — Repository Overview

This repository contains the original eratohoK assets together with a modern .NET 10 refactor called `DotNet10Refactor`.

The refactor aims to provide a maintainable, testable, and playable C# implementation

## Repository layout

- `DotNet10Refactor/` — .NET 10 refactor (C# projects: `eratohoK.Core`, `eratohoK.Data`, `eratohoK.Semantics`, `eratohoK.GameEngine`, `eratohoK.Cli`). See `DotNet10Refactor/README.md` for details.
- `ERB/` — original ERB assets (口上, SLG scripts, skill scripts etc.). These are the textual resources from the original project.
- `CSV/` — data files (Train.csv, Item.csv, Talent.csv, Chara/…); used by the refactor CSV loader.
- `docs/` — additional documentation and guides.
- `saves/` — example save files.
- `パッチのReadme/` and other localized patch docs — community patches and notes.

## DotNet10Refactor (quick start)

Prerequisites:

- .NET 10 SDK

Build:

```bash
cd DotNet10Refactor
dotnet build
```

Run the CLI (point to your CSV folder):

```bash
dotnet run --project src/eratohoK.Cli/eratohoK.Cli.csproj -- ../CSV
```

If `../CSV` is missing the CLI will fall back to built-in demo data.

For more details about the refactor design, CSV handling, and internals, open `DotNet10Refactor/README.md`.

## CSV compatibility

The refactor includes a CSV reader (`eratohoK.Data/CsvDataReader.cs`) that handles quoted fields and common quirks of the original CSVs. If you add or modify CSVs, please keep a backup and test by running the CLI.

## Notes about original assets

This project preserves original ERB assets under `ERB/`. The refactor does not attempt to relicense or alter the original content; it only reads those assets as data during conversion and testing. Respect the original project's license when redistributing.

## Special thanks

Special thanks to the original eratohoK project and its contributors for creating the content and inspiration this repository builds upon.

---

If you'd like, I can also:

- add a root-level `CONTRIBUTING.md` and `CODE_OF_CONDUCT.md`;
- add small unit tests for the CSV parser to ensure quoted-field handling across typical CSVs in this repo; or
- implement an ERB → semantic-text conversion prototype to start migrating `ERB/口上` into `eratohoK.Semantics` assets.

Pick one and I will proceed.
