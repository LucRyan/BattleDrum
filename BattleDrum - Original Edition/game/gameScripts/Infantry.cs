
function Infantry::onLevelLoaded(%this, %scenegraph)
{
	$Infantry = %this;	
}

function Infantry::InfantryBoost()
{  
   $Infantry.setAnimation(InfantryAnimationBoost);
   %flipX = $Infantry.getFlipX();


   if(%flipX)
   {
      %hSpeed = $Infantry.hSpeed * 2;
   } else
   {
      %hSpeed = -$Infantry.hSpeed * 2;
   }


   $Infantry.setLinearVelocityX(%hSpeed);
}

function Infantry::InfantryBoostStop()
{
   $Infantry.setAnimation(InfantryStandAnimation);
   $Infantry.setLinearVelocityX(0);
}


function Infantry::updateMovement(%this)
{
   if(%this.moveLeft)
   {
      $Infantry.setAnimation(InfantryMoveAnimation);
      $Infantry.setFlipX(false);
      $Infantry.setLinearVelocityX( -$Infantry.hSpeed );
   }
   
   if(%this.moveRight)
   {
      $Infantry.setAnimation(InfantryMoveAnimation);
      $Infantry.setFlipX(true);
      $Infantry.setLinearVelocityX( $Infantry.hSpeed );
   }

   if(%this.moveUp)
   {
      $Infantry.setAnimation(InfantryMoveAnimation);
      %this.setLinearVelocityY( -$Infantry.vSpeed );
   }


   if(%this.moveDown)
   {
      $Infantry.setAnimation(InfantryMoveAnimation);
      %this.setLinearVelocityY( $Infantry.vSpeed );
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

function Infantry::InfantryUp()
{
   $Infantry.moveUp = true;
   $Infantry.updateMovement();
}


function Infantry::InfantryDown()
{
   $Infantry.moveDown = true;
   $Infantry.updateMovement();
}


function Infantry::InfantryLeft()
{
   $Infantry.moveLeft = true;
   $Infantry.updateMovement();
}


function Infantry::InfantryRight()
{
   $Infantry.moveRight = true;
   $Infantry.updateMovement();
}


function Infantry::InfantryUpStop()
{
   $Infantry.setAnimation(InfantryStandAnimation);
   $Infantry.moveUp = false;
   $Infantry.updateMovement();
}


function Infantry::InfantryDownStop()
{
   $Infantry.setAnimation(InfantryStandAnimation);
   $Infantry.moveDown = false;
   $Infantry.updateMovement();
}

function Infantry::InfantryLeftStop()
{
   $Infantry.setAnimation(InfantryStandAnimation);
   $Infantry.moveLeft = false;
   $Infantry.updateMovement();
}


function Infantry::InfantryRightStop()
{
   $Infantry.setAnimation(InfantryStandAnimation);
   $Infantry.moveRight = false;
   $Infantry.updateMovement();
}

// Let Infantry to attack
function Infantry::InfantryAttack()
{
   $Infantry.setAnimation(InfantryAttackAnimation);
}

function Infantry::InfantryAttackStop()
{
   $Infantry.setAnimation(InfantryStandAnimation);
}

function Infantry::Fire(%this, %val)
{
   //This can be a bit confusing, but it's to ensure that the firing mechanism
   // works as expected, so that the player cannot fire more bullets by tapping the
   // key really fast (the waitSchedule ensures that) - when the wait finishes, it
   // uses the fireCond method to see if the key was pressed again during the wait.
   %this.tryingToFire = false;
   %this.tryingToFire = %val;
   %this.projectile = $BladeI;
   
  // echo("1: projectile = arrow");
   if (%val == 0) 
   {
      cancel(%this.fireSchedule);
      if( !isEventPending(%this.waitSchedule)){
       //  echo("2: waitSchedule.");
         %this.waitSchedule = %this.schedule( 0.25 * 1000, $Infantry , "Infantry::FireCond");
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
   %projectile.setRotation(90);
   %projectile.setLinearVelocityPolar(90, 18);
   %projectile.setWorldLimit(KILL,%this.getPositionX() - 50,%this.getPositionY()- 50, %this.getPositionX() + 20, %this.getPositionY() + 20, 0);
   
   //echo("5: New Arrow");
   
   if (!isEventPending(%this.fireSchedule)){
      %this.fireSchedule = %this.schedule(0.25 * 1000,  $Infantry, "Infantry::Fire", 1);
      //echo("6: set fireRate");
   }
}

function Infantry::FireCond(%this)
{
   if( %this.tryingToFire )
      %this.Fire( %this.tryingToFire );
      
}

