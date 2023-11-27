# Class-like objects in .net

 In C#, understanding the differences between classes, records, and structs is important. Each serves a different purpose and has unique characteristics:

### Classes
- **Type**: Reference type.
- **Usage**: Used for defining objects that require complex behaviors, inheritance, and extensive functionality.
- **Memory Allocation**: Allocated on the heap.
- **Copying**: When copied, only the reference is copied, not the actual object.
- **Mutation**: Can be mutable; their state can change after creation.
- **Inheritance**: Supports inheritance and polymorphism.

### Records
- **Type**: Reference type, introduced in C# 9.0.
- **Usage**: Ideal for immutable objects and for simplifying value-based equality checks.
- **Memory Allocation**: Allocated on the heap, like classes.
- **Copying**: Supports with-expressions for non-destructive mutation.
- **Mutation**: Primarily designed to be immutable; however, mutable records can be created.
- **Equality**: By default, provides value-based equality, unlike classes.
- **Inheritance**: Supports inheritance, but primarily designed for immutable data models.

### Structs
- **Type**: Value type.
- **Usage**: Best suited for small, lightweight objects.
- **Memory Allocation**: Allocated on the stack, which can offer performance benefits for small objects.
- **Copying**: When copied, the entire structure is copied, not just a reference.
- **Mutation**: Can be mutable, but often used as immutable.
- **Inheritance**: Cannot inherit from other structs or classes, but can implement interfaces.

### Key Differences
- **Classes vs Records**:
  - Classes are mutable by default and use reference-based equality.
  - Records are intended for immutability and value-based equality.
- **Classes vs Structs**:
  - Classes are reference types and are more versatile for complex data structures.
  - Structs are value types and better for small, simple data.
- **Records vs Structs**:
  - Both can be used for value-based data handling, but records provide built-in functionality for immutability and value-based equality.
  - Records are reference types, whereas structs are value types.

Understanding these differences is crucial when deciding how to structure data and behavior in your C# applications. Classes offer the most functionality, structs provide efficient ways to handle small data structures, and records offer a modern approach to immutable data models with value-based equality.