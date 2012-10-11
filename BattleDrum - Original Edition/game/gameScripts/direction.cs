function Direction::onLevelLoaded(%this, %scenegraph)
{
	$Direction = %this;
   $Direction.setVisible(false);
}

function Direction::onMouseDown(%this, %modifier, %worldPos)
{
    $Direction.setVisible(false);
    $Resume.setVisible(true);
    $DirectionButton.setVisible(true);
}

