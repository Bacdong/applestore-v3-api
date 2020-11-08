#use PascalCasing for class names and method names
 
 Exp: 
 
 public class ClientActivity 
 {
    public void CleanStatics () 
    {
         //...
    }
    public void CalculateStatics () 
    {
        //...
    }
 }

#use camelCasing for variables and method arguments.

Exp:

public class UserLog 
{
    public void Add(LogEvent logEvent) {
        int itemCount = logEvent.Items.Count;
    } 
}

#prefix interfaces with letter I. Interfaces names are noun (phrases) or adjectives.

Exp:
public interface Ishape 
{
}
public interfaces IShapeCollection
{
}
public interfaces IGroupable
{
}

#name source files according to their main classes.Exception: file names with partial classes
reflect their source or purpose, e.g. designer, generated, etc.

Exp:
// located in Task.cs
public partial Task 
{
    //...
}
//located in Task.generate.cs
public partial Task 
{
    //...
}

#use singular names for enums. Exception: bit fields enums.

Exp:
//Correct
public enum Color {
    Red,
    Green,
    Blue,
    Yellow,
}

//Exception
[Flags]
public enum Dockings {
    None = 0,
    Top = 1,
    Right = 2,
    Bottom = 4,
    Left = 8,
}

#explicit specify a type of an enum or values of enum (except field bit)

Exp:
// Don't
public enum Direction : long {
    North = 0,
    East = 1,
    South = 2, 
    West = 3,
}

// Correct 
public enum Direction
{
    North,
    East, 
    South,
    West,
}

