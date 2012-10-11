
function Player::onLevelLoaded(%this, %scenegraph)
{
	$Player = %this;

}

function Player::PlayerBoost()
{
   %flipX = $Player.getFlipX();


   if(!%flipX)
   {
      %hSpeed = $Player.hSpeed * 3;
   } else
   {
      %hSpeed = -$Player.hSpeed * 3;
   }


   $Player.setLinearVelocityX(%hSpeed);
}

function Player::PlayerBoostStop()
{
   $Player.setLinearVelocityX(0);
}


function Player::updateMovement(%this)
{
   if(%this.moveLeft)
   {
      $Player.setFlipX(true);
      $Player.setLinearVelocityX( -$Player.hSpeed );
   }
   
   if(%this.moveRight)
   {
      $Player.setFlipX(false);
      $Player.setLinearVelocityX( $Player.hSpeed );
   }

   if(%this.moveUp)
   {
      %this.setLinearVelocityY( -$Player.vSpeed );
   }


   if(%this.moveDown)
   {
      %this.setLinearVelocityY( $Player.vSpeed );
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

function Player::PlayerUp()
{
   $Player.moveUp = true;
   $Player.updateMovement();
}


function Player::PlayerDown()
{
   $Player.moveDown = true;
   $Player.updateMovement();
}


function Player::PlayerLeft()
{
   $Player.moveLeft = true;
   $Player.updateMovement();
}


function Player::PlayerRight()
{
   $Player.moveRight = true;
   $Player.updateMovement();
}


function Player::PlayerUpStop()
{
   $Player.moveUp = false;
   $Player.updateMovement();
}


function Player::PlayerDownStop()
{
   $Player.moveDown = false;
   $Player.updateMovement();
}

function Player::PlayerLeftStop()
{
   $Player.moveLeft = false;
   $Player.updateMovement();
}


function Player::PlayerRightStop()
{
   $Player.moveRight = false;
   $Player.updateMovement();
}

