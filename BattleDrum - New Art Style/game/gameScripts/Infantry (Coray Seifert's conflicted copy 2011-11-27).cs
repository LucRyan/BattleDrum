
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

