# AsciiArt

## Instructions

Clone Repository

Open the .sln file in Visual Studio

Build the Solution

To use from Visual Studio (debugging)
* Add *Command line arguments* to the AsciiArt project
  * Right-click on the project AsciiArt and select _Properties_
  * Go to _Debug_
  * Under _Start Options_ is _Command line arguments_
  * Enter your image's filename
  * Optionally: add the output filename
* Press **Start**

To use from command line using its .exe:
* Move image file to same directory as the .exe
* Navigate to this directory
* Enter _AsciiArt.exe_ into console followed by the image's filename followed by its extension
  * Enter the filename **not** its path
* If you want to output the ascii to a text file, enter a filename after the image's filename
