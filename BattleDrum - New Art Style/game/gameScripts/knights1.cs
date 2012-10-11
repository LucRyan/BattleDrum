
function Knight1::onLevelLoaded(%this, %scenegraph)
{
	$Knight1 = %this;
}




function Knight1::KnightBoost()
{  
   $Knight1.setAnimation(knightAnimationBoost);
   %flipX = $Knight1.getFlipX();


   if(%flipX)
   {
      %hSpeed = $Knight1.hSpeed * 3;
   } else
   {
      %hSpeed = -$Knight1.hSpeed * 3;
   }


   $Knight1.setLinearVelocityX(%hSpeed);
}

function Knight1::KnightBoostStop()
{
   $Knight1.setAnimation(knightAnimationStand);
   $Knight1.setLinearVelocityX(0);
}


function Knight1::updateMovement(%this)
{
   if(%this.moveLeft)
   {
      $Knight1.setAnimation(knightAnimation);
      $Knight1.setFlipX(false);
      $Knight1.setLinearVelocityX( -$Knight1.hSpeed );
   }
   
   if(%this.moveRight)
   {
      $Knight1.setAnimation(knightAnimation);
      $Knight1.setFlipX(true);
      $Knight1.setLinearVelocityX( $Knight1.hSpeed );
   }

   if(%this.moveUp)
   {
     // %size = $Knight1.getSize();
     // %size = %size - 0.5;
      $Knight1.setAnimation(knightAnimation);
     // $Knight1.setSize(%size);
      %this.setLinearVelocityY( -$Knight1.vSpeed );
   }


   if(%this.moveDown)
   {
     // %size = $Knight.getSize();
     // %size = %size + 0.5;
      $Knight1.setAnimation(knightAnimation);
     // $Knight1.setSize(%size);
      %this.setLinearVelocityY( $Knight1.vSpeed );
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

function Knight1::KnightUp()
{
   $Knight1.moveUp = true;
   $Knight1.updateMovement();
}


function Knight1::KnightDown()
{
   $Knight1.moveDown = true;
   $Knight1.updateMovement();
}


function Knight1::KnightLeft()
{
   $Knight1.moveLeft = true;
   $Knight1.updateMovement();
}


function Knight1::KnightRight()
{
   $Knight1.moveRight = true;
   $Knight1.updateMovement();
}


function Knight1::KnightUpStop()
{
   $Knight1.setAnimation(knightAnimationStand);
   $Knight1.moveUp = false;
   $Knight1.updateMovement();
}


function Knight1::KnightDownStop()
{
   $Knight1.setAnimation(knightAnimationStand);
   $Knight1.moveDown = false;
   $Knight1.updateMovement();
}

function Knight1::KnightLeftStop()
{
   $Knight1.setAnimation(knightAnimationStand);
   $Knight1.moveLeft = false;
   $Knight1.updateMovement();
}


function Knight1::KnightRightStop()
{
   $Knight1.setAnimation(knightAnimationStand);
   $Knight1.moveRight = false;
   $Knight1.updateMovement();
}

// Let knight to attack
function Knight1::KnightAttack()
{
   $Knight1.setAnimation(knightAnimationAttack);
}

function Knight1::KnightAttackStop()
{
   $Knight1.setAnimation(knightAnimationStand);
}

function Knight1::KnightDefense()
{
   $Knight1.setAnimation(KnightAnimationDefense);
}

function Knight1::KnightDefenseStop()
{
   $Knight1.setAnimation(knightAnimationStand);
}

function Knight1::Fire(%this, %val)
{
   //This can be a bit confusing, but it's to ensure that the firing mechanism
   // works as expected, so that the player cannot fire more bullets by tapping the
   // key really fast (the waitSchedule ensures that) - when the wait finishes, it
   // uses the fireCond method to see if the key was pressed again during the wait.
   %this.tryingToFire = false;
   %this.tryingToFire = %val;
   %this.projectile = $BladeK;
   
  // echo("1: projectile = arrow");
   if (%val == 0) 
   {
      cancel(%this.fireSchedule);
      if( !isEventPending(%this.waitSchedule)){
       //  echo("2: waitSchedule.");
         %this.waitSchedule = %this.schedule( 0.25 * 1000, $Knight1 , "Knight1::FireCond");
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
   %projectile.setLinearVelocityPolar(90, 30);
   %projectile.setWorldLimit(KILL,%this.getPositionX() - 50,%this.getPositionY()- 50, %this.getPositionX() + 30, %this.getPositionY() + 30, 0);
   
   //echo("5: New Arrow");
   
   if (!isEventPending(%this.fireSchedule)){
      %this.fireSchedule = %this.schedule(0.25 * 1000,  $Knight1, "Knight1::Fire", 1);
      //echo("6: set fireRate");
   }
}

function Knight1::FireCond(%this)
{
   if( %this.tryingToFire )
      %this.Fire( %this.tryingToFire );
      
}

