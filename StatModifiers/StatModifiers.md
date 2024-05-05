# Stat Modifiers
These files are all fairly tightly coupled and should **not** be extended from directly, rather they should be copy-pasted and the variants should be modified directly.

## Files to Modify
- `BaseStats.cs` -> update to include game specific stats
- `StatType.cs` -> update to include game specific stats
- `Stats.cs` -> update to include game specific stat getters and constructor
- `Query.cs` -> update to include new `StatType`
- `StatMediator.cs` -> update to include new `Query`
