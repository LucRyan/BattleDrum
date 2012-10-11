function cloudsClass::setSpeed(%this)
{
   %this.speed = getRandom(%this.minSpeed, %this.maxSpeed);
}


function cloudsClass::onLevelLoaded(%this, %scenegraph)
{
   %this.setSpeed();
   %this.setLinearVelocityX(%this.speed);
}


function cloudsClass::onWorldLimit(%this, %mode, %limit)
{
   %this.setSpeed();

   switch$ (%limit)
   {

      case "left":
         %this.setLinearVelocityX(%this.speed);
         %this.setFlipX(true);
	 %this.setPositionY(getRandom(-38, -1));

      case "right":
         %this.setLinearVelocityX(-%this.speed);
         %this.setFlipX(false);
	 %this.setPositionY(getRandom(-38, -1));
   }

}





