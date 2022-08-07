# KnightTourPuzzle

This C# console program help to solve Knight Tour Puzzle. The program have 2 solutions: Back-Tracking algorithm and Warnsdorff's Rule algorithm

# Back-Tracking Algorithm:

The program implemented Back-Tracking algorithm in the file **'BacktrackingSolution.cs'**. The idea of using Back-Tracking is we will try every possible moves of Knight on the board, with each move, if the move can't lead to the solution, then we will trace back to the previous move and try with another possible move (this is the reason we call it Back-Tracking). Continue to doing this process until we reach the solution.

This approach is not recommended on big boards (like 8x8 and above) due to it's time complexity. With N is the size of the board, we have N^2 is the total square on the board, and for each square, we have maximum 8 possible moves to choose. Let assume N = 8, in the worst scenario, time complexity for this approach is **O(8^8^2)**, **~6.27E+57** possible operations can be made. This really a bad running time for any modern computer.

# Warnsdorff's Rule Algorithm:

The program implemented Warnsdorff's Rule in the file **'WarnsdorffRuleSolution.cs'**. The idea of Warnsdorff's Rule is:
- We can start from any initial position of the knight on the board
- The knight is moved so that it always proceeds to the square from which the knight will have the fewest onward moves. When calculating the number of onward moves for each candidate square, we do not count moves that revisit any square already visited

This approach is recommended on any kind of boards and will found the solution in linear time. Let assume N = 8, time complexity for this approach is **O(8^4)**, **~4096** operations. This approach can found the solution in just milliseconds.

By default, the program will use Warnsdorff's Rule algorithm.

# Enviroment required to build and run application

- .Net Core 3.1 SDK
- Visual Studio 2019 or higher
