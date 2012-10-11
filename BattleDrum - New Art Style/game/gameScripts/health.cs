function Health::onLevelLoaded(%this, %scenegraph)
{
	$Health = %this;
	%this.displayScore = "100";
	%this.text = "Base Health: " @ %this.displayScore @ ".";
}

function Health::updateText(%int)
{
   $Health.text = "Base Health: " @ %int @ ".";
}