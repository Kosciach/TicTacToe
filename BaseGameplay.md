<h2 align="center">BaseGameplay</h2>


<br>
<h2 align="center">Selecting board field</h2>
<p align="center">
Board contains 9 field to player to press, which have their representation in for of and array in BoardController.<br>
When player presses the not empty field, button passes its index to methods and method uses it to assing current character to correct array slot.<br>
Player can't press the field if game is over or if field is not empty(determined by array field).<br>
</p>


<br>
<h2 align="center">Turns</h2>
<p align="center">
When player succesfully selects field, BoardController must assign new character.<br>
This is handled by SetNextTurn method, which sets new turn pedending on current turn(O-X, X-O), and tells turn indicator to move.<br>
BoardController keeps track of turn count to make sure draw is correctly checked.<br>
</p>



<br>
<h2 align="center">GameOver</h2>
<p align="center">
There are 3 types of GameOver(O wins - point for O, X wins - point for X, Draw - point for both).<br>
Each turn, after new character is set in array, CheckOutcome method check if current turn formed a line, if true this character wins, else method checks for draw(turnCount is 9).<br>
To show who has won last selected characters controller is used to play animation(move to center, increase size, decrease size, explode).<br>
In case of a draw random O and X are selected and play similar animation to win, except this time one is moved to right and one to left.<br>
In order to easily selectet random O and X, BoardController uses List in List as a track all the characters selected.<br>
After GameOver animation, game values reset to default and player can play again.<br>
</p>


<h3 align="center">
  <a href="README.md">ReadMe</a>
</h3>
