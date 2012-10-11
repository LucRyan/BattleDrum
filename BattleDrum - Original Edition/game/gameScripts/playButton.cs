function PlayButton::onLevelLoaded(%this, %scenegraph)
{
	$PlayButton = %this;
	$PlayButton.setBlendAlpha(0.2);
   $PlayButton.setVisible(true);
}

function PlayButton::onMouseDown(%this, %modifier, %worldPos)
{
    playGame(); 
}

function PlayButton::onMouseEnter(%this, %modifier, %worldPos)
{
    $PlayButton.setBlendAlpha(0.9); 
}

function PlayButton::onMouseLeave(%this, %modifier, %worldPos)
{
    $PlayButton.setBlendAlpha(0.2); 
}

function playGame(){
   $timescale = 1;
   $StartImage.setVisible(false);
   $PlayButton.setVisible(false);
   $DirectionButtonStart.setVisible(false);
   
}