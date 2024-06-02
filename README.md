Rubik's Cube Console App
========================

## Concept

This console application simulates a Rubik's Cube and allows the user to manipulate it using various commands.

## Project Structure

The application is divided into several classes and namespaces:

### Namespaces

1. **RubiksCube**: This is the main namespace containing all the classes required for the application.

### Classes

1. **Program**
   - The entry point of the application.
   - Contains the `Main` method which initializes the cube and processes user commands.

2. **Cube**
   - Represents the Rubik's Cube.
   - Contains methods for rotating the cube faces, displaying the cube, restarting the cube, and handling the 'explode' command which shows all faces simultaneously.

3. **Side**
   - Represents a single side of the Rubik's Cube.
   - Contains methods for displaying the side, updating rows and columns, and rotating the side clockwise or anti-clockwise.

4. **Cell**
   - Represents a single cell on a side of the Rubik's Cube.
   - Contains properties for the cell's color and symbol.

### Enums

1. **FacingDirection**
   - Represents the different faces of the Rubik's Cube (Front, Back, Left, Right, Top, Bottom).

2. **Command**
   - Represents the possible commands that can be executed on the Rubik's Cube (FrontClockwise, RightAntiClockwise, UpClockwise, BackAntiClockwise, LeftClockwise, DownAntiClockwise).

## How to Use

1. **Running the Application**
   - Execute the application. The cube will be initialized and the front face will be displayed.

2. **Commands**
   - The application will prompt you to select a command or explode the cube:
     - `1`: Rotate the front face 90° clockwise.
     - `2`: Rotate the right face 90° anti-clockwise.
     - `3`: Rotate the up face 90° clockwise.
     - `4`: Rotate the back face 90° anti-clockwise.
     - `5`: Rotate the left face 90° clockwise.
     - `6`: Rotate the down face 90° anti-clockwise.
   - Enter the corresponding number to execute a command.
   - Enter `r` to restart the cube to its initial state.
   - Enter `e` to explode the cube, displaying all faces.

3. **Display**
   - The cube will be displayed after each command, showing the front face. If the explode command is chosen, all faces will be displayed simultaneously.


## Code Overview

1. **Program.cs**
   - Contains the `Main` method that drives the application loop, handling user input and executing commands on the Rubik's Cube.

2. **Cube.cs**
   - Implements the `Cube` class, which manages the cube's state and contains methods for rotating faces, restarting the cube, displaying faces, and the explode functionality.
   - Includes private helper methods to perform the actual rotations.

3. **Side.cs**
   - Defines the `Side` class, managing the individual sides of the cube, including methods for rotating and displaying rows and columns.

4. **Cell.cs**
   - Defines the `Cell` class, representing a single cell on a cube side, including its color and symbol.

5. **Enums.cs**
   - Defines the `FacingDirection` and `Command` enums, used to represent the directions of the cube faces and the commands for manipulating the cube.
