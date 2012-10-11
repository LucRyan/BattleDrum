
function Knight::onLevelLoaded(%this, %scenegraph)
{
	$Knight = %this;
}




function Knight::KnightBoost()
{  
   $Knight.setAnimation(knightAnimationBoost);
   %flipX = $Knight.getFlipX();


   if(%flipX)
   {
      %hSpeed = $Knight.hSpeed * 3;
   } else
   {
      %hSpeed = -$Knight.hSpeed * 3;
   }


   $Knight.setLinearVelocityX(%hSpeed);
}

function Knight::KnightBoostStop()
{
   $Knight.setAnimation(knightAnimationStand);
   $Knight.setLinearVelocityX(0);
}


function Knight::updateMovement(%this)
{
   if(%this.moveLeft)
   {
      $Knight.setAnimation(knightAnimation);
      $Knight.setFlipX(false);
      $Knight.setLinearVelocityX( -$Knight.hSpeed );
   }
   
   if(%this.moveRight)
   {
      $Knight.setAnimation(knightAnimation);
      $Knight.setFlipX(true);
      $Knight.setLinearVelocityX( $Knight.hSpeed );
   }

   if(%this.moveUp)
   {
     // %size = $Knight.getSize();
      %size = %size - 0.5;
      $Knight.setAnimation(knightAnimation);
     // $Knight.setSize(%size);
      %this.setLinearVelocityY( -$Knight.vSpeed );
   }


   if(%this.moveDown)
   {
     // %size = $Knight.getSize();
      %size = %size + 0.5;
      $Knight.setAnimation(knightAnimation);
     // $Knight.setSize(%size);
      %this.setLinearVelocityY( $Knight.vSpeed );
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

function Knight::KnightUp()
{
   $Knight.moveUp = true;
   $Knight.updateMovement();
}


function Knight::KnightDown()
{
   $Knight.moveDown = true;
   $Knight.updateMovement();
}


function Knight::KnightLeft()
{
   $Knight.moveLeft = true;
   $Knight.updateMovement();
}


function Knight::KnightRight()
{
   $Knight.moveRight = true;
   $Knight.updateMovement();
}


function Knight::KnightUpStop()
{
   $Knight.setAnimation(knightAnimationStand);
   $Knight.moveUp = false;
   $Knight.updateMovement();
}


function Knight::KnightDownStop()
{
   $Knight.setAnimation(knightAnimationStand);
   $Knight.moveDown = false;
   $Knight.updateMovement();
}

function Knight::KnightLeftStop()
{
   $Knight.setAnimation(knightAnimationStand);
   $Knight.moveLeft = false;
   $Knight.updateMovement();
}


function Knight::KnightRightStop()
{
   $Knight.setAnimation(knightAnimationStand);
   $Knight.moveRight = false;
   $Knight.updateMovement();
}

// Let knight to attack
function Knight::KnightAttack()
{
   $Knight.setAnimation(knightAnimationAttack);
}

function Knight::KnightAttackStop()
{
   $Knight.setAnimation(knightAnimationStand);
}

function Knight::KnightDefense()
{
   $Knight.setAnimation(KnightAnimationDefense);
}

function Knight::KnightDefenseStop()
{
   $Knight.setAnimation(knightAnimationStand);
}


function Knight::Fire(%this, %val)
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
         %this.waitSchedule = %this.schedule( 0.25 * 1000, $Knight , "Knight::FireCond");
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
      %this.fireSchedule = %this.schedule(0.25 * 1000,  $Knight, "Knight::Fire", 1);
      //echo("6: set fireRate");
   }
}

function Knight::FireCond(%this)
{
   if( %this.tryingToFire )
      %this.Fire( %this.tryingToFire );
      
}