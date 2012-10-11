function Pause::onLevelLoaded(%this, %scenegraph)
{
	$Pause = %this;
}

function Pause::onMouseDown(%this, %modifier, %worldPos)
{
    pauseGame(); 
}
