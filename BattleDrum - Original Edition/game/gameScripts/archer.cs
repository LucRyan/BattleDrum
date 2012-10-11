
function Archer::onLevelLoaded(%this, %scenegraph)
{
	$Archer = %this;
}


function Archer::updateMovement(%this)
{
   if(%this.moveLeft)
   {
      $Archer.setAnimation(archermoveAnimation);
      $Archer.setFlipX(false);
      $Archer.setLinearVelocityX( -$Archer.hSpeed );
   }
   
   if(%this.moveRight)
   {
      $Archer.setAnimation(archermoveAnimation);
      $Archer.setFlipX(true);
      $Archer.setLinearVelocityX( $Archer.hSpeed );
   }

   if(%this.moveUp)
   {
      $Archer.setAnimation(archermoveAnimation);
      %this.setLinearVelocityY( -$Archer.vSpeed );
   }


   if(%this.moveDown)
   {
      $Archer.setAnimation(archermoveAnimation);
      %this.setLinearVelocityY( $Archer.vSpeed );
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

function Archer::ArcherUp()
{
   $Archer.moveUp = true;
   $Archer.updateMovement();
}


function Archer::ArcherDown()
{
   $Archer.moveDown = true;
   $Archer.updateMovement();
}


function Archer::ArcherLeft()
{
   $Archer.moveLeft = true;
   $Archer.updateMovement();
}


function Archer::ArcherRight()
{
   $Archer.moveRight = true;
   $Archer.updateMovement();
}


function Archer::ArcherUpStop()
{
   $Archer.setAnimation(archerstandAnimation);
   $Archer.moveUp = false;
   $Archer.updateMovement();
}


function Archer::ArcherDownStop()
{
   $Archer.setAnimation(archerstandAnimation);
   $Archer.moveDown = false;
   $Archer.updateMovement();
}

function Archer::ArcherLeftStop()
{
   $Archer.setAnimation(archerstandAnimation);
   $Archer.moveLeft = false;
   $Archer.updateMovement();
}


function Archer::ArcherRightStop()
{
   $Archer.setAnimation(archerstandAnimation);
   $Archer.moveRight = false;
   $Archer.updateMovement();
}

// Let knight to attack
function Archer::ArcherFire()
{
   $Archer.setAnimation(archerfireAnimation);
}

function Archer::ArcherFireStop()
{
   $Archer.setAnimation(archerstandAnimation);
}



function Archer::Fire(%this, %val)
{
   //This can be a bit confusing, but it's to ensure that the firing mechanism
   // works as expected, so that the player cannot fire more bullets by tapping the
   // key really fast (the waitSchedule ensures that) - when the wait finishes, it
   // uses the fireCond method to see if the key was pressed again during the wait.
   %this.tryingToFire = false;
   %this.tryingToFire = %val;
   %this.projectile = $Arrow;
   
  // echo("1: projectile = arrow");
   if (%val == 0) 
   {
      cancel(%this.fireSchedule);
      if( !isEventPending(%this.waitSchedule)){
       //  echo("2: waitSchedule.");
         %this.waitSchedule = %this.schedule( 0.25 * 1000, $Archer , "Archer::FireCond");
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
   %projectile.setLinearVelocityPolar(90, 50);
   %projectile.setWorldLimit(KILL,%this.getPositionX() - 5,%this.getPositionY()- 5, 35, 35, 0);
   
   //echo("5: New Arrow");
   
   if (!isEventPending(%this.fireSchedule)){
      %this.fireSchedule = %this.schedule(0.25 * 1000,  $Archer, "Archer::Fire", 1);
      //echo("6: set fireRate");
   }
}

function Archer::FireCond(%this)
{
   if( %this.tryingToFire )
      %this.Fire( %this.tryingToFire );
      
}
