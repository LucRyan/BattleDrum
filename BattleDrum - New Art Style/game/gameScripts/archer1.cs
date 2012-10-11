
function Archer1::onLevelLoaded(%this, %scenegraph)
{
	$Archer1 = %this;
}


function Archer1::updateMovement(%this)
{
   if(%this.moveLeft)
   {
      $Archer1.setAnimation(ArchermoveAnimation);
      $Archer1.setFlipX(false);
      $Archer1.setLinearVelocityX( -$Archer1.hSpeed );
   }
   
   if(%this.moveRight)
   {
      $Archer1.setAnimation(ArchermoveAnimation);
      $Archer1.setFlipX(true);
      $Archer1.setLinearVelocityX( $Archer1.hSpeed );
   }

   if(%this.moveUp)
   {
      $Archer1.setAnimation(ArchermoveAnimation);
      %this.setLinearVelocityY( -$Archer1.vSpeed );
   }


   if(%this.moveDown)
   {
      $Archer1.setAnimation(ArchermoveAnimation);
      %this.setLinearVelocityY( $Archer1.vSpeed );
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

function Archer1::ArcherUp()
{
   $Archer1.moveUp = true;
   $Archer1.updateMovement();
}


function Archer1::ArcherDown()
{
   $Archer1.moveDown = true;
   $Archer1.updateMovement();
}


function Archer1::ArcherLeft()
{
   $Archer1.moveLeft = true;
   $Archer1.updateMovement();
}


function Archer1::ArcherRight()
{
   $Archer1.moveRight = true;
   $Archer1.updateMovement();
}


function Archer1::ArcherUpStop()
{
   $Archer1.setAnimation(ArcherstandAnimation);
   $Archer1.moveUp = false;
   $Archer1.updateMovement();
}


function Archer1::ArcherDownStop()
{
   $Archer1.setAnimation(ArcherstandAnimation);
   $Archer1.moveDown = false;
   $Archer1.updateMovement();
}

function Archer1::ArcherLeftStop()
{
   $Archer1.setAnimation(ArcherstandAnimation);
   $Archer1.moveLeft = false;
   $Archer1.updateMovement();
}


function Archer1::ArcherRightStop()
{
   $Archer1.setAnimation(ArcherstandAnimation);
   $Archer1.moveRight = false;
   $Archer1.updateMovement();
}

// Let knight to attack
function Archer1::ArcherFire()
{
   $Archer1.setAnimation(ArcherfireAnimation);
}

function Archer1::ArcherFireStop()
{
   $Archer1.setAnimation(ArcherstandAnimation);
}



function  Archer1::Fire(%this, %val)
{
   //This can be a bit confusing, but it's to ensure that the firing mechanism
   // works as expected, so that the player cannot fire more bullets by tapping the
   // key really fast (the waitSchedule ensures that) - when the wait finishes, it
   // uses the fireCond method to see if the key was pressed again during the wait.
   %this.tryingToFire = false;
   %this.tryingToFire = %val;
   %this.projectile = $Arrow1;
   
  // echo("1: projectile = arrow");
   if (%val == 0) 
   {
      cancel(%this.fireSchedule);
      if( !isEventPending(%this.waitSchedule)){
       //  echo("2: waitSchedule.");
         %this.waitSchedule = %this.schedule( 0.25 * 1000, %this ,"Archer1::FireCond");
      }
      return;
   }
   
   if (isEventPending(%this.fireSchedule) || isEventPending( %this.waitSchedule)){
      return;
     // echo("3: find pending");
   }

   if (!isObject(%this.projectile) || !%this.enabled || !%this.getVisible()){
     // echo("4: set visible");
      return;
   }

   
   %projectile = %this.projectile.cloneWithBehaviors();
   
   %projectile.setPosition(%this.position);
   %projectile.setRotation(90);
   %projectile.setLinearVelocityPolar(90, 50);
   %projectile.setWorldLimit(KILL,%this.getPositionX() - 50,%this.getPositionY()- 50, 35, 35, 0);
   
  // echo("5: New Arrow");
   
   if (!isEventPending(%this.fireSchedule)){
      %this.fireSchedule = %this.schedule(0.25 * 1000, %this,"Archer1::Fire", 1);
      //echo("6: set fireRate");
   }
}

function Archer1::FireCond(%this)
{
   if( %this.tryingToFire )
      %this.Fire( %this.tryingToFire );
      
}
