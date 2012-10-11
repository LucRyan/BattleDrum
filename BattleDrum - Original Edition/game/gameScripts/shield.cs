
function Shield::onLevelLoaded(%this, %scenegraph)
{
	$Shield = %this;

	moveMap.bindCmd(keyboard, "1", "ShieldUp();", "ShieldUpStop();");
	moveMap.bindCmd(keyboard, "2", "ShieldDown();", "ShieldDownStop();");
	moveMap.bindCmd(keyboard, "3", "ShieldLeft();", "ShieldLeftStop();");
	moveMap.bindCmd(keyboard, "4", "ShieldRight();", "ShieldRightStop();");
	
   moveMap.bindCmd(keyboard, "5", "ShieldDefense();", "ShieldDefenseStop();");
	
}


function Shield::updateMovement(%this)
{
   if(%this.moveLeft)
   {
      $Shield.setAnimation(ShieldmoveAnimation);
      $Shield.setFlipX(true);
      $Shield.setLinearVelocityX( -$Shield.hSpeed );
   }
   
   if(%this.moveRight)
   {
      $Shield.setAnimation(ShieldmoveAnimation);
      $Shield.setFlipX(false);
      $Shield.setLinearVelocityX( $Shield.hSpeed );
   }

   if(%this.moveUp)
   {
      $Shield.setAnimation(ShieldmoveAnimation);
      %this.setLinearVelocityY( -$Shield.vSpeed );
   }


   if(%this.moveDown)
   {
      $Shield.setAnimation(ShieldmoveAnimation);
      %this.setLinearVelocityY( $Shield.vSpeed );
   }


   if(!%this.moveLeft && !%this.moveRight)
   {
      %this.setLinearVelocityX( 0 );
   }


   if(!%this.moveUp && !%this.moveDown)
   {
      %this.setLinearVelocityY( 0 );
   }
}

function Shield::ShieldUp()
{
   $Shield.moveUp = true;
   $Shield.updateMovement();
}


function Shield::ShieldDown()
{
   $Shield.moveDown = true;
   $Shield.updateMovement();
}


function Shield::ShieldLeft()
{
   $Shield.moveLeft = true;
   $Shield.updateMovement();
}


function Shield::ShieldRight()
{
   $Shield.moveRight = true;
   $Shield.updateMovement();
}


function Shield::ShieldUpStop()
{
   $Shield.setAnimation(ShieldstandAnimation);
   $Shield.moveUp = false;
   $Shield.updateMovement();
}


function Shield::ShieldDownStop()
{
   $Shield.setAnimation(ShieldstandAnimation);
   $Shield.moveDown = false;
   $Shield.updateMovement();
}

function Shield::ShieldLeftStop()
{
   $Shield.setAnimation(ShieldstandAnimation);
   $Shield.moveLeft = false;
   $Shield.updateMovement();
}


function Shield::ShieldRightStop()
{
   $Shield.setAnimation(ShieldstandAnimation);
   $Shield.moveRight = false;
   $Shield.updateMovement();
}

// Let Shield to defense

function Shield::ShieldDefense()
{
   $Shield.setAnimation(ShieldAnimationDefense);
}

function Shield::ShieldDefenseStop()
{
   $Shield.setAnimation(ShieldstandAnimation);
}

function Shield::Fire(%this, %val)
{
   //This can be a bit confusing, but it's to ensure that the firing mechanism
   // works as expected, so that the player cannot fire more bullets by tapping the
   // key really fast (the waitSchedule ensures that) - when the wait finishes, it
   // uses the fireCond method to see if the key was pressed again during the wait.
   %this.tryingToFire = false;
   %this.tryingToFire = %val;
   %this.projectile = $ShieldDefense;
   
  // echo("1: projectile = arrow");
   if (%val == 0) 
   {
      cancel(%this.fireSchedule);
      if( !isEventPending(%this.waitSchedule)){
       //  echo("2: waitSchedule.");
         %this.waitSchedule = %this.schedule( 0.25 * 1000, $Shield , "Shield::FireCond");
      }
      return;
   }
   
   if (isEventPending(%this.fireSchedule) || isEventPending( %this.waitSchedule)){
      return;
      echo("3: find pending");
   }

   if (!isObject(%this.projectile) || !%this.enabled || !%this.getVisible()){
     // echo("4: set visible");
      return;
   }

   
   %projectile = %this.projectile.cloneWithBehaviors();
   
   %projectile.setPosition(%this.position);
   %projectile.setLinearVelocityPolar(90, 30);
   %projectile.setWorldLimit(KILL,%this.getPositionX() - 5,%this.getPositionY()- 50, %this.getPositionX() + 20, %this.getPositionY() + 20, 0);
   
   //echo("5: New Arrow");
   
   if (!isEventPending(%this.fireSchedule)){
      %this.fireSchedule = %this.schedule(0.25 * 1000,  $Shield, "Shield::Fire", 1);
      //echo("6: set fireRate");
   }
}

function Shield::FireCond(%this)
{
   if( %this.tryingToFire )
      %this.Fire( %this.tryingToFire );
      
}
