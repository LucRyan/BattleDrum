function Restart::onLevelLoaded(%this, %scenegraph)
{
	$Restart = %this;
   $Restart.setVisible(false);
   $Restart.setBlendAlpha(0.2); 
}

function Restart::onMouseDown(%this, %modifier, %worldPos)
{
   sceneWindow2D.endLevel();
   
   sceneWindow2D.loadLevel( expandFilename( "game/data/levels/battlefield.t2d"));
   
   //sceneWindow2D.schedule( 2500, loadLevel, "~/data/levels/battlefield.t2d" );  
  //  if( isEventPending($changeLevel))  
  //  {  
  //    return;  //check for debugging if the event is scheduled   
  //  }  
}

function Restart::onMouseEnter(%this, %modifier, %worldPos)
{
    $Restart.setBlendAlpha(1.0); 
}

function Restart::onMouseLeave(%this, %modifier, %worldPos)
{
    $Restart.setBlendAlpha(0.2); 
}