# AsciiArtGenerator

This is a project I am writing in c# to generate ascii art from an image in command line c#.

The aim is to select an image, by typing in an autocomplted path, evaluating the image for how light or dark each section is, and turning it into ascii art with similar denisty.

At this time I am not following any guides, just expermenting with different techniques, so the final product may not be the most optimal version. 

## Read vs Readkey
A major choice I had was to use either read or readkey for sampling keystrokes. At first read seemed eaiser, as it keeps case, but due to it blocking its return, as well as marked not preferable by microsoft, lead me to use readkey. An advantage of this is that I am able to use "ConsoleKey.xxx" to check for certain button presses, instead of using ascii codes which look less clear.