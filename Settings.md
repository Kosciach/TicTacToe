<h2 align="center">Settings</h2>


<br>
<h2 align="center">Color Picker</h2>
<p align="center">
3 sliders, Red, Green and Blue allow player to set desired background color.<br>
Each of those sliders has its own method to call on value change.<br>
All of those methods change respective part of the color and settings, update all backgrounds(camera, pause, credits), and save color settings.<br>
Sliders have min value 0.2f and max 0.8f to prevent to bright or to dark colors.<br>
</p>


<br>
<h2 align="center">Audio</h2>
<p align="center">
With 2 slider player can adjust Music and Sounds volume.<br>
Just like with colors, each slider has its own method.<br>
Both methods change respective volume in audio settings, update AudioSources volume and save audio settings.<br>
</p>


<br>
<h2 align="center">Starting character</h2>
<p align="center">
Starting character setting allows player to choose who should start O or X.<br>
To change starting character player uses 2 buttons O and X, both call their own method.<br>
This methods first check if choosen character is already starting one, and return if that is true, if not character is set, board method called, starting character settings saved and indicator moved.<br>
When starting character is changed when game has already started, it will be used when board resets.<br>
But if all board fields are empty, starting character will change normally, without waiting for next round, this is showed by turn indicator under score.<br>

</p>


<br>
<h2 align="center">Saving settings</h2>
<p align="center">
To save Color,Audio and StartingCharacter settings, game used 3 classes for each setting and corverts them into json files.
This files are used to check if player has entered the game for the first time, and to load saved settings.
</p>

<h3 align="center">
  <a href="README.md">ReadMe</a>
</h3>
