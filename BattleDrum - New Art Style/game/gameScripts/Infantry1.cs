
function Infantry1::onLevelLoaded(%this, %scenegraph)
{
	$Infantry1 = %this;	
}

function Infantry1::InfantryBoost()
{  
   $Infantry1.setAnimation(InfantryAnimationBoost);
   %flipX = $Infantry1.getFlipX();


   if(%flipX)
   {
      %hSpeed = $Infantry1.hSpeed * 2;
   } else
   {
      %hSpeed = -$Infantry1.hSpeed * 2;
   }


   $Infantry1.setLinearVelocityX(%hSpeed);
}

function Infantry1::InfantryBoostStop()
{
   $Infantry1.setAnimation(InfantryStandAnimation);
   $Infantry1.setLinearVelocityX(0);
}


function Infantry1::updateMovement(%this)
{
   if(%this.moveLeft)
   {
      $Infantry1.setAnimation(InfantryMoveAnimation);
      $Infantry1.setFlipX(false);
      $Infantry1.setLinearVelocityX( -$Infantry1.hSpeed );
   }
   
   if(%this.moveRight)
   {
      $Infantry1.setAnimation(InfantryMoveAnimation);
      $Infantry1.setFlipX(true);
      $Infantry1.setLinearVelocityX( $Infantry1.hSpeed );
   }

   if(%this.moveUp)
   {
      $Infantry1.setAnimation(InfantryMoveAnimation);
      %this.setLinearVelocityY( -$Infantry1.vSpeed );
   }


   if(%this.moveDown)
   {
      $Infantry1.setAnimation(InfantryMoveAnimation);
      %this.setLinearVelocityY( $Infantry1.vSpeed );
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

function Infantry1::InfantryUp()
{
   $Infantry1.moveUp = true;
   $Infantry1.updateMovement();
}


function Infantry1::InfantryDown()
{
   $Infantry1.moveDown = true;
   $Infantry1.updateMovement();
}


function Infantry1::InfantryLeft()
{
   $Infantry1.moveLeft = true;
   $Infantry1.updateMovement();
}


function Infantry1::InfantryRight()
{
   $Infantry1.moveRight = true;
   $Infantry1.updateMovement();
}


function Infantry1::InfantryUpStop()
{
   $Infantry1.setAnimation(InfantryStandAnimation);
   $Infantry1.moveUp = false;
   $Infantry1.updateMovement();
}


function Infantry1::InfantryDownStop()
{
   $Infantry1.setAnimation(InfantryStandAnimation);
   $Infantry1.moveDown = false;
   $Infantry1.updateMovement();
}

function Infantry1::InfantryLeftStop()
{
   $Infantry1.setAnimation(InfantryStandAnimation);
   $Infantry1.moveLeft = false;
   $Infantry1.updateMovement();
}


function Infantry1::InfantryRightStop()
{
   $Infantry1.setAnimation(InfantryStandAnimation);
   $Infantry1.moveRight = false;
   $Infantry1.updateMovement();
}

// Let Infantry to attack
function Infantry1::InfantryAttack()
{
   $Infantry1.setAnimation(InfantryAttackAnimation);
}

function Infantry1::InfantryAttackStop()
{
   $Infantry1.setAnimation(InfantryStandAnimation);
}


function Infantry1::Fire(%this, %val)
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
         %this.waitSchedule = %this.schedule( 0.25 * 1000, $Infantry1 , "Infantry1::FireCond");
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
      %this.fireSchedule = %this.schedule(0.25 * 1000,  $Infantry1, "Infantry1::Fire", 1);
      //echo("6: set fireRate");
   }
}

function Infantry1::FireCond(%this)
{
   if( %this.tryingToFire )
      %this.Fire( %this.tryingToFire );
      
}