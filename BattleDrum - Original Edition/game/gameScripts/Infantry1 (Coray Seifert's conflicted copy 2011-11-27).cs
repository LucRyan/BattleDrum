
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

