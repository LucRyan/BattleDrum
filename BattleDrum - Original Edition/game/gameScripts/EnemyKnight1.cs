
function EnemyKnight1::onLevelLoaded(%this, %scenegraph)
{
	$EnemyKnight1 = %this;
}




function EnemyKnight1::KnightBoost()
{  
   $EnemyKnight1.setAnimation(knightAnimationBoost);
   %flipX = $EnemyKnight1.getFlipX();


   if(%flipX)
   {
      %hSpeed = $EnemyKnight1.hSpeed * 3;
   } else
   {
      %hSpeed = -$EnemyKnight1.hSpeed * 3;
   }


   $EnemyKnight1.setLinearVelocityX(%hSpeed);
}

function EnemyKnight1::KnightBoostStop()
{
   $EnemyKnight1.setAnimation(EnemyKnightAnimationStand);
   $EnemyKnight1.setLinearVelocityX(0);
}


function EnemyKnight1::updateMovement(%this)
{
   if(%this.moveLeft)
   {
      $EnemyKnight1.setAnimation(EnemyKnightWalkAnimation);
      $EnemyKnight1.setFlipX(true);
      $EnemyKnight1.setLinearVelocityX( -$EnemyKnight1.hSpeed );
   }
   
   if(%this.moveRight)
   {
      $EnemyKnight1.setAnimation(EnemyKnightWalkAnimation);
      $EnemyKnight1.setFlipX(false);
      $EnemyKnight1.setLinearVelocityX( $EnemyKnight1.hSpeed );
   }

   if(%this.moveUp)
   {
     // %size = $EnemyKnight1.getSize();
     // %size = %size - 0.5;
      $EnemyKnight1.setAnimation(EnemyKnightWalkAnimation);
     // $EnemyKnight1.setSize(%size);
      %this.setLinearVelocityY( -$EnemyKnight1.vSpeed );
   }


   if(%this.moveDown)
   {
     // %size = $Knight.getSize();
     // %size = %size + 0.5;
      $EnemyKnight1.setAnimation(EnemyKnightWalkAnimation);
     // $EnemyKnight1.setSize(%size);
      %this.setLinearVelocityY( $EnemyKnight1.vSpeed );
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

function EnemyKnight1::KnightUp()
{
   $EnemyKnight1.moveUp = true;
   $EnemyKnight1.updateMovement();
}


function EnemyKnight1::KnightDown()
{
   $EnemyKnight1.moveDown = true;
   $EnemyKnight1.updateMovement();
}


function EnemyKnight1::KnightLeft()
{
   $EnemyKnight1.moveLeft = true;
   $EnemyKnight1.updateMovement();
}


function EnemyKnight1::KnightRight()
{
   $EnemyKnight1.moveRight = true;
   $EnemyKnight1.updateMovement();
}


function EnemyKnight1::KnightUpStop()
{
   $EnemyKnight1.setAnimation(EnemyKnightAnimationStand);
   $EnemyKnight1.moveUp = false;
   $EnemyKnight1.updateMovement();
}


function EnemyKnight1::KnightDownStop()
{
   $EnemyKnight1.setAnimation(EnemyKnightAnimationStand);
   $EnemyKnight1.moveDown = false;
   $EnemyKnight1.updateMovement();
}

function EnemyKnight1::KnightLeftStop()
{
   $EnemyKnight1.setAnimation(EnemyKnightAnimationStand);
   $EnemyKnight1.moveLeft = false;
   $EnemyKnight1.updateMovement();
}


function EnemyKnight1::KnightRightStop()
{
   $EnemyKnight1.setAnimation(EnemyKnightAnimationStand);
   $EnemyKnight1.moveRight = false;
   $EnemyKnight1.updateMovement();
}

// Let knight to attack
function EnemyKnight1::KnightAttack()
{
   $EnemyKnight1.setAnimation(EnemyKnightAttackAnimation);
}

function EnemyKnight1::KnightAttackStop()
{
   $EnemyKnight1.setAnimation(EnemyKnightAnimationStand);
}


function EnemyKnight1::KnightDefenseStop()
{
   $EnemyKnight1.setAnimation(EnemyKnightAnimationStand);
}

