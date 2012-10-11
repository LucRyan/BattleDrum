
function Archer2::onLevelLoaded(%this, %scenegraph)
{
	$Archer2 = %this;
}


function Archer2::updateMovement(%this)
{
   if(%this.moveLeft)
   {
      $Archer2.setAnimation(ArchermoveAnimation);
      $Archer2.setFlipX(false);
      $Archer2.setLinearVelocityX( -$Archer2.hSpeed );
   }
   
   if(%this.moveRight)
   {
      $Archer2.setAnimation(ArchermoveAnimation);
      $Archer2.setFlipX(true);
      $Archer2.setLinearVelocityX( $Archer2.hSpeed );
   }

   if(%this.moveUp)
   {
      $Archer2.setAnimation(ArchermoveAnimation);
      %this.setLinearVelocityY( -$Archer2.vSpeed );
   }


   if(%this.moveDown)
   {
      $Archer2.setAnimation(ArchermoveAnimation);
      %this.setLinearVelocityY( $Archer2.vSpeed );
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

function Archer2::ArcherUp()
{
   $Archer2.moveUp = true;
   $Archer2.updateMovement();
}


function Archer2::ArcherDown()
{
   $Archer2.moveDown = true;
   $Archer2.updateMovement();
}


function Archer2::ArcherLeft()
{
   $Archer2.moveLeft = true;
   $Archer2.updateMovement();
}


function Archer2::ArcherRight()
{
   $Archer2.moveRight = true;
   $Archer2.updateMovement();
}


function Archer2::ArcherUpStop()
{
   $Archer2.setAnimation(ArcherstandAnimation);
   $Archer2.moveUp = false;
   $Archer2.updateMovement();
}


function Archer2::ArcherDownStop()
{
   $Archer2.setAnimation(ArcherstandAnimation);
   $Archer2.moveDown = false;
   $Archer2.updateMovement();
}

function Archer2::ArcherLeftStop()
{
   $Archer2.setAnimation(ArcherstandAnimation);
   $Archer2.moveLeft = false;
   $Archer2.updateMovement();
}


function Archer2::ArcherRightStop()
{
   $Archer2.setAnimation(ArcherstandAnimation);
   $Archer2.moveRight = false;
   $Archer2.updateMovement();
}

// Let knight to attack
function Archer2::ArcherFire()
{
   $Archer2.setAnimation(ArcherfireAnimation);
}

function Archer2::ArcherFireStop()
{
   $Archer2.setAnimation(ArcherstandAnimation);
}



function  Archer2::Fire(%this, %val)
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
         %this.waitSchedule = %this.schedule( 0.25 * 1000, %this ,"Archer2::FireCond");
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
      %this.fireSchedule = %this.schedule(0.25 * 1000, %this,"Archer2::Fire", 1);
      //echo("6: set fireRate");
   }
}

function Archer2::FireCond(%this)
{
   if( %this.tryingToFire )
      %this.Fire( %this.tryingToFire );
      
}
