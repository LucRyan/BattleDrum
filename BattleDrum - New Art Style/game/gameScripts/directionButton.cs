function DirectionButton::onLevelLoaded(%this, %scenegraph)
{
	$DirectionButton = %this;
	$DirectionButton.setBlendAlpha(0.2);
   $DirectionButton.setVisible(false);
}

function DirectionButton::onMouseDown(%this, %modifier, %worldPos)
{
    $Direction.setVisible(true);
    $Resume.setVisible(false);
    $DirectionButton.setVisible(false);
}

function DirectionButton::onMouseEnter(%this, %modifier, %worldPos)
{
    $DirectionButton.setBlendAlpha(1.0); 
}

function DirectionButton::onMouseLeave(%this, %modifier, %worldPos)
{
    $DirectionButton.setBlendAlpha(0.2); 
}