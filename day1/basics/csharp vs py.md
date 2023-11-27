# Main Syntax Differences Between C# and Python

## Typing
> **C#:** Statically typed; variable types must be declared explicitly.

> **Python:** Dynamically typed; variable types are inferred and can change.

## Syntax for Defining Variables
- **C#:**
  ```csharp
  int number = 10;
  ```
- **Python:**
  ```python
  number = 10
  ```

## Functions/Methods
- **C#:**
  ```csharp
  public int AddNumbers(int a, int b) { return a + b; }
  ```
- **Python:**
  ```python
  def add_numbers(a, b): 
      return a + b
  ```

## Class Definition
- **C#:**
  ```csharp
  class MyClass { ... }
  ```
- **Python:**
  ```python
  class MyClass: 
      ...
  ```

## Constructor and Method Overloading
- **C#:** Supported.
- **Python:** Not supported natively; achieved through other means.

## Namespaces and Imports
- **C#:**
  ```csharp
  using System;
  ```
- **Python:**
  ```python
  import sys
  ```

## Error Handling
- **C#:**
  ```csharp
  try { ... } catch(Exception ex) { ... }
  ```
- **Python:**
  ```python
  try: 
      ...
  except Exception as ex: 
      ...
  ```

## Arrays and Collections
- **C#:** Arrays have fixed size. Use `List<T>` for dynamic size.
- **Python:** Lists are dynamic, `list = [1, 2, 3]`

## String Formatting
- **C#:**
  ```csharp
  $"Hello, {name}"
  ```
- **Python:**
  ```python
  f"Hello, {name}"
  ```

## Lambda Expressions
- **C#:**
  ```csharp
  (args) => expression
  ```
- **Python:**
  ```python
  lambda args: expression
  ```

## Property Definition
- **C#:**
  ```csharp
  public int MyProperty { get; set; }
  ```
- **Python:** Using decorators like `@property`

## Semicolons and Braces
- **C#:** Uses semicolons to terminate statements and braces for blocks.
- **Python:** Relies on indentation for blocks; no semicolons.

## Comments
- **C#:**
  ```csharp
  // single line
  /* multi-line */
  ```
- **Python:**
  ```python
  # single line
  ''' multi-line '''
  ```

## Main Entry Point
- **C#:**
  ```csharp
  static void Main(string[] args) { ... }
  ```
  > C# now also support clean entry point files without public static class as starter.
  
- **Python:**
  ```python
  if __name__ == "__main__": 
      ...
  ```

