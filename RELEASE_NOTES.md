### Breaking Changes
- Ensures PDF objects can only be written once
  - Attempting to do so more than once will throw an exception
- Prevents usage of a Stream returned from QPdf after the QPdf instance has been disposed

### Features
- Allows passing in a QPdfWriteOptions instance to set various PDF properties

### Adjustments
- Improves interop code
