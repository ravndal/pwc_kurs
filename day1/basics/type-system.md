# .net Type system

In C#, understanding the difference between value types and reference types is crucial, especially for beginners. Here's a simple explanation:

### Value Types
- **What Are They?**: Value types hold data directly. They are stored in the stack memory, which means they're allocated and deallocated automatically when your program runs.
- **Examples**: `int`, `double`, `float`, `char`, `bool`, and all struct types.
- **Behavior**:
  - When you assign one value type to another, a copy of the value is created. Any changes made to one variable do not affect the other.
  - They have a default value; for example, an `int` defaults to `0`.

### Reference Types
- **What Are They?**: Reference types store a reference (or address) to the actual data. The data is stored in the heap memory, which is managed by the garbage collector.
- **Examples**: `string`, `arrays`, and all class types.
- **Behavior**:
  - When you assign one reference type to another, both references point to the same memory location. Changes made through one reference are reflected in the other.
  - The default value of a reference type is `null`, meaning it doesn't reference any object initially.

### Key Differences
- **Memory Allocation**:
  - Value Types: Stored in the stack, which usually allows faster access but has limited space.
  - Reference Types: Stored in the heap, which has more memory available but involves an additional layer of indirection.
- **Copying Behavior**:
  - Value Types: Copying a value type variable copies the data.
  - Reference Types: Copying a reference type variable copies the reference, not the actual data.
- **Default Values**:
  - Value Types: Have a default value based on their type (e.g., `0` for `int`).
  - Reference Types: Default to `null`, indicating they don't reference any object.

Understanding these differences is important for memory management and performance optimization in C#. It also helps in understanding how data is passed around in your code - whether by value (copying the actual data) or by reference (copying the address to the data).