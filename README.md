# LP2 Project 2

## Moon Buggy

### Authors

**Ana Dos Santos** - a21900297 [AnSantos99](https://github.com/AnSantos99)

**Catarina Matias** - a21801693 [StarryNight00](https://github.com/StarryNight00)

**Diana Levay** - a21801515 [nanilevay](https://github.com/nanilevay)

### Tasks of each group member

**Ana Dos Santos** (list of things done - Adding colors and sound to the project, Linux platform conversion, UML, Flowchart, Operating System dependency, Doxygen Setup, Readme)

Changed visual aspects of game by adding colors and sound to the game. Setup of linux platform for testing purposes of the game on a different platform. Designed UML class diagram and simple flowchart to show the programs functionality. Helped group members finding solutions for given problems by the program. Created Operating dependency class that checks the current operating system and acts corresponding to it.

**Catarina Matias** (Menu, MenuPrints, HighScore, GameLoop exit incorporation, displayed information handling)

Responsible for the `Menu` logic and its overall appearance and displayed information, along with its exceptions. These information screens were made on a different static class, `MenuPrints`, to make them available in all the code and make them easier to call on and use. Also responsible for the `HighScore` class, it's file handling and the incorporation of the score passing on to this list. Was responsible for the incorporation of the game's end within the program loop back to the Main Menu in `GameLoop` (__was not__ responsible for this class in itself, just the mentioned incorporation and worked alongside Diana to correct the code where needed and handling all the needed steps to avoid exceptions).

Was responsible for creating the basic template for the README report, from the last project delivery. Completed the report with needed information and links searched.

Note: also did a `Score` class that was unused in the final product, and therefor erased. Although it can be found in the code's history, it was ultimately scratched out as the score incorporation was made directly in the game screen by Diana.

**Diana Levay** (Game Logic, Player and Platforms updates, Renders, Conditions for movements and game over):

Created, referenced and adapted the main logic for the gameloop, player, platforms and the display of each component on the screen, worked on fixing errors and finding exceptions throughout the program as well as creating the necessary methods for everything to work and look more like the original game (printing the game over over the game screen, help messages showing up at random, colours for each printed character), helped joining the score and menu logic along with Catarina with the working gameloop.

Tried to implement GameObject class and associate it with collider logic for all different components when platforms had a more complex logic, but ended up scratching it because of time constraints and the approach chosen.

Revision of documents and contributing to the organization of the repository and writing the solution approach in the report.

Classes created and worked on: Player, DoubleBuffer2D (Directly based on the one given by the professor found in the references), Platforms, GameLoop, InputSystem (also based on professor's solution, modified accordingly to allow better adaptation to our game), Jump, Map, Positions, Characters

Revision of documents and contributing to the organization of the repository and writing the solution approach in the report.

Classes created and worked on: Player, DoubleBuffer2D (Directly based on the one given by the professor found in the references), Platforms, GameLoop, InputSystem (also based on professor's solution, modified accordingly to allow better adaptation to our game), Jump, Map, Positions, Characters

### Project's Git Repository

<https://github.com/StarryNight00/lp2_project2/tree/master>

### Describing Solution approach

We first approached this solution by following a logic that required GameLoop and Update methods, in order to function like a console game we also chose to use the DoubleBuffer approach taught by the professor with the necessary modifications to adapt to a Moon Buggy styled game.

The program begins by setting the console size and creating a Menu instance to call the IntroMenu() function and show the player a list of options to choose from. Here, the player's input will be read and they can exit the program, access the rules, see the highscores menu or beginning a new game, the Menu class accesses the MenuPrints static class in order to print the different menus and access them when needed.

If the player chooses to play the game, a new GameLoop class will be instantiated and started and we will enter the Loop(), where we'll create instances of Player, Platforms, a DoubleBuffer2D to store chars, a Map and and an input System. All components to be printed on the screen will be assigned positions inside their own classes in order to keep track of their movements for the updates.

In the game loop we constantly show the player information such as how to move, how to leave the game and some small help messages that were present in the original Moon Buggy, as well as constantly printing the player and Platforms (and some stars changing in the background, for visual effect) with different colours using the Console, that are constantly being Rendered on the screen via the DoubleBuffer.

We start the thread and set the player's motion to Idle (found in an enum with different states) and begin a while loop that will be active as long as our game is set to running (the losing conditions haven't been met nor has there been an ESCAPE key press on the input) followed by processing the player's input and sending it to the update, in order to change positions or show messages as they're due.
After, the Render method is called and this one will take all the chars given to the doublebuffer and will print them on the screen according to their position, character and colour, each getting defined within it's own class.
Finally the loop has a Thread.Sleep() method that allows us to control how we render the simulated time and how fast everything is happening.

If the player chooses to leave or loses the game we will exit the loop and print a game over screen, as well as sending the current score (measured by each successful jump) and send it to the HighScore class where it will be stored inside a .txt file and if the user chooses to see the scores a list of the top 10 scores will be displayed.

We tried to keep classes and methods simple and as independent from eachother as possible as well as using design patterns given in class (GameLoop logic, Update) all the while following SOLID principles and good practices.

### Flow Chart

The following flowchart represents the basic structure of the program by separating the background functionalities of the Game Engine with the Game itself and how they come together.

![Flow Chart](programFlowChart.png)

### UML Diagram

The following class diagram represents associations between classes. The are more Dependency arrows but to make the diagram readable only the most important arrows are available.

![UML Diagram](uml_proj2.png)

## References

The following references where used during this project.

**[1]** Class Power-points

**[2]** Code available at the File class C# API documentation was used as a stepping stone for the file handling in the program. - <https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=netframework-4.8>

**[3]** Re-used code from teachers solution from <https://github.com/VideojogosLusofona/lp2_2019_aulas.git> (Aula11, Exercise 3).

**[4]** Game logic based on the game Moon Buggy, Linux console edition found in <https://www.seehuhn.de/pages/moon-buggy>

**[5]** Referenced tutorial for initial logic intended for platforms and movement found it <https://www.youtube.com/watch?v=dXng0W0R_Ks>

**For Diagrams and FlowCharts:**

**[1]** The following site was used for both flowchart and UML class diagram.
<https://www.draw.io/>
