//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------------
// startGame
// All game logic should be set up here. This will be called by the level builder when you
// select "Run Game" or by the startup process of your game to load the first level.
//---------------------------------------------------------------------------------------------
function startGame(%level)
{

   exec("./clouds.cs");
   exec("./archer.cs");
   exec("./archer1.cs");
   exec("./archer2.cs");
   exec("./knights.cs");
   exec("./knights1.cs");
   exec("./shield.cs");
   exec("./Infantry.cs");
   exec("./Infantry1.cs");
   exec("./health.cs");
   exec("./shieldDefense.cs");
   
   exec("./sun.cs");
   exec("./pon.cs");
   exec("./ta.cs");
   exec("./pa.cs");
   exec("./don.cs");
   exec("./control.cs");
   exec("./audioDatablocks.cs");
   exec("./arrow.cs");
   exec("./arrow1.cs");
   exec("./bladeK.cs");
   exec("./pause.cs");
   exec("./resume.cs");
   exec("./direction.cs");
   exec("./directionButton.cs");
   exec("./pauseImage.cs");
   exec("./startImage.cs");
   exec("./playButton.cs");
   exec("./directionButtonStart.cs");
   exec("./EnemyKnight1.cs");
   exec("./directionS.cs");
   exec("./bladeI.cs");
   exec("./gameover.cs");
   exec("./restart.cs");
   exec("./directionBo.cs");
   
   

   Canvas.setContent(mainScreenGui);
   Canvas.setCursor(DefaultCursor);
   
   new ActionMap(moveMap);   
   moveMap.push();
   
   $enableDirectInput = true;
   activateDirectInput();
   enableJoystick();
   playBackground();
   sceneWindow2D.setUseObjectMouseEvents( true );
   sceneWindow2D.loadLevel(%level);
}

//---------------------------------------------------------------------------------------------
// endGame
// Game cleanup should be done here.
//---------------------------------------------------------------------------------------------
function endGame()
{
   sceneWindow2D.endLevel();
   moveMap.pop();
   moveMap.delete();
}
