function Resume::onLevelLoaded(%this, %scenegraph)
{
	$Resume = %this;
	$Resume.setBlendAlpha(0.2);
   $Resume.setVisible(false);
}

function Resume::onMouseDown(%this, %modifier, %worldPos)
{
    pauseGame(); 
}

function Resume::onMouseEnter(%this, %modifier, %worldPos)
{
    $Resume.setBlendAlpha(1.0); 
}

function Resume::onMouseLeave(%this, %modifier, %worldPos)
{
    $Resume.setBlendAlpha(0.2); 
}

function pauseGame()   
{   
   if($isPaused)   
   {      
      $timescale=1;
      $Resume.setVisible(false);
      $DirectionButton.setVisible(false);
      $PauseImage.setVisible(false);
      $DirectionBo.setVisible(false);
   }   
   else  
   {   
      $timescale=0; 
      $Resume.setVisible(true); 
      $DirectionButton.setVisible(true); 
      $PauseImage.setVisible(true);
   }   
      
   $isPaused = !$isPaused;   
}  