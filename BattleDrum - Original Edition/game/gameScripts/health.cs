function Health::onLevelLoaded(%this, %scenegraph)
{
	$Health = %this;
	%this.displayScore = "100";
	%this.text = "Basement Health: " @ %this.displayScore @ ".";
}

function Health::updateText(%int)
{
   $Health.text = "Basement Health: " @ %int @ ".";
}