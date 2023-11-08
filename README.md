# AspNetCore EntityChangeTracking
Quick solution to add fields to EF Core entities for tracking changes to them. Adds CreatedDateTime, CreatedBy, EditedDateTime, EditedBy

See [1f5d59a](https://github.com/Connor-R-McNeely/AspNetCore_EntityChangeTracking/commit/1f5d59a646b79c0285317ec55e6afc1407993143) for necessary code changes.
To use it on a model, the model should implement ITimestamp. This will require adding 4 properties. Updating of all 4 properties is handled automatically by the database context upon calling SaveChanges() or SaveChangesAsync().

See [d4cb2fa](https://github.com/Connor-R-McNeely/AspNetCore_EntityChangeTracking/commit/d4cb2fadded47c9488c76c2038e5297c4bab5d6c) for an example implementation.
