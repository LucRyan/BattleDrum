function DirectionBo::onLevelLoaded(%this, %scenegraph)
{
	$DirectionBo = %this;
   $DirectionBo.setVisible(false);
   %this.schedule(2 * 60000, "showUp");
}

function DirectionBo::onMouseDown(%this, %modifier, %worldPos)
{
   $DirectionBo.setVisible(false);
   $PauseImage.setVisible(false);
   $Resume.setVisible(false);
   $timescale = 1;
   $isPaused = 0;
}

function DirectionBo::showUp()
{
   $timescale = 0;
   $isPaused = 1;
   $Resume.setVisible(true);
   $PauseImage.setVisible(true);
   $DirectionBo.setVisible(true);
}