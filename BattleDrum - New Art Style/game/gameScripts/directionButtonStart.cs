function DirectionButtonStart::onLevelLoaded(%this, %scenegraph)
{
	$DirectionButtonStart = %this;
	$DirectionButtonStart.setBlendAlpha(0.2);
   $DirectionButtonStart.setVisible(true);
}

function DirectionButtonStart::onMouseDown(%this, %modifier, %worldPos)
{
    $DirectionS.setVisible(true);
    $PlayButton.setVisible(false);
    $DirectionButtonStart.setVisible(false);
}

function DirectionButtonStart::onMouseEnter(%this, %modifier, %worldPos)
{
    $DirectionButtonStart.setBlendAlpha(0.9); 
}

function DirectionButtonStart::onMouseLeave(%this, %modifier, %worldPos)
{
    $DirectionButtonStart.setBlendAlpha(0.2); 
}