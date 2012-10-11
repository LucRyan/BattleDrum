function DirectionS::onLevelLoaded(%this, %scenegraph)
{
	$DirectionS = %this;
   $DirectionS.setVisible(false);
}

function DirectionS::onMouseDown(%this, %modifier, %worldPos)
{
    $DirectionS.setVisible(false);
    $PlayButton.setVisible(true);
    $DirectionButtonStart.setVisible(true);
}

