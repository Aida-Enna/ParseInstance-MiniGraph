# ParseInstance & MiniGraph

This was an idea that came about while working on PSO2ACT v2 and wanted to make the graph be separate and "perhaps an overlay type program would be nice..." and that brought forth this... abomination... :x
Thanks to Variant for the PSO2 Damage Plugin since none of this would exist without that in the first place.


## WARNING! - WARNING! - WARNING!
Please note that using this kinds of programs actually violate's PSO2's terms of services and according to them, it is a bannable offense, so please use this responsibly.
We're all here to have fun, right?  To improve our gameplay and experience but most important of all, to have fun so please use this responsibly!  Thanks!


## MIT License

**Copyright (c) 2020 Maemi Aenia**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.



### Installation :

Put the following files in the same folder/directory :

* MiniGraph.exe
* ParseInstance.exe
* skills.csv
* skills-Main.csv
* skills-noJA.csv
* skills-Weapon.csv

### Running :

To start it all, just run ParseInstance.exe
  
  
  
## ParseInstance :

This program will generate InstanceData.csv and InstanceData.skilldb files according to the PSO2's battle instance.
It will automatically generate it per Instance ID as set by PSO2, thus you don't have to manually end encounters (Can't anyways).
![Generated files](/Images/ParseInstance-GeneratedFiles.png)

It will make a sub-folder/directory named "PreviousInstances" where the previous instances that this program generates will get backed up to.
The current/latest run will always be in "InstanceData.csv" and "InstanceData.skilldb" files.


At first run, it will ask you to select where the pso2_bin\damagelog folder is at so please select it to make it run correctly.
![Select folder](/Images/ParseInstance-SelectFolder.png)

This program will install a tray-icon, thus you can re-select the damagelog folder path through the tray-icon menu.
![Tray Menu](/Images/ParseInstance-TrayMenu.png)

It will also automatically start MiniGraph program when run and try to automatically close it as well when exiting.

*If you can't select the pso2_bin\damagelog folder/directory through the browse folder dialog for some reason, then select just any folder and then edit the ParseInstance.ini file to point at the correct folder/directory.*
![Edit ini file](/Images/ParseInstance-Ini.png)
  
  
  
## MiniGraph - DPS Overlay window

![MiniGraph Window](/Images/MainWindow-BOn.png)

This will make a small window appear as "Always On Top" so that it will stay on top of the game window so you can see this.

This has an idle time-out of 60 seconds so 1 minute after the last "log" to display, if nothing else happens, then it'll automatically hide itself.
It will also automatically show itself whenever a run has started.

You can show/hide the window with the keyboard shortcut Ctrl+TAB so please take note of that as well.

This will show a Tray Icon and doubleclicking on the tray-icon will show/hide the window.

![Tray menu](/Images/MiniGraph-TrayMenu.png)

The Border Yes/No option is to show or hide the border of the window.  You want to have it show border to resize it to however you want it to be and then turn it off to hide the borders.
![Border Off](/Images/MainWindow-BOff.png)
- By click-dragging the Black Square on the top-left corner of the window, you can move the window about.
- The slider on the top-right corner of the window controls the window's opacity.

From the graph, player names have been removed, but YOU are being displayed with a yellow star to differentiate from the others since what people would use this most is to see how you are doing compared to the rest, right?

Also, for easier reference sake, if you hover your mouse on top of a person's graph, it will show you that person's name in a mouse tooltip so please take note.

**THIS EXECUTABLE HAS TO STAY WITHIN THE SAME FOLDER AS PARSEINSTANCE.EXE FILE!!!**  
**THIS EXECUTABLE HAS TO STAY WITHIN THE SAME FOLDER AS PARSEINSTANCE.EXE FILE!!!**  
**THIS EXECUTABLE HAS TO STAY WITHIN THE SAME FOLDER AS PARSEINSTANCE.EXE FILE!!!**


The MiniGraph program will try to read the files generated by ParseInstance and show you the graph based on its contents.



The Border On/Off button is also from the main window without having to go through the tray menu so please take note.

"Pause" button pauses the reading of InstanceData files.  It will rename itself to "Resume".
If you click on "Resume", then it will resume watching for changes in the InstanceData files.

"Load Prev." is used for opening previous InstanceData files such as the ones that are backed up in the PreviousInstances folder.
This is for when you want to load up data of a previous run.  It's best to pause the reading of InstanceData files when loading previous encounter data so as to give you time to browse through that data.


### Skill Window

![Skill Window](/Images/SkillWindow.png)

Double-click on a player's data row to bring up the Skill window.

It will display another separate window but this time this details that player's PA/Tech/Specials used data.
This window is separate per player so if you had space, you could open up 12 windows for all players as well.

This Skill window will follow main window's opacity and border settings.

Double-clicking on the Skill items does nothing.

Click on "Close" to close the skill window.

If you leave a player's skill window open, provided you keep capturing data from that player (meaning that player is in your MPA or party), that skill window will update itself as well, so you could open up your own skill window and see it update according to what you use.


### Basic View Mode

![Basic mode](/Images/MainWindow-Basic.png)

On the Main window, there's a button named "Basic".  Clicking on this makes the main window smaller, hides max hit data and shortens the player info on the graph so as to provide a "basic" display mode so as to make the window smaller.
The button will rename itself to "Full" when in Basic mode and clicking on this button will restore it to Full display mode.
