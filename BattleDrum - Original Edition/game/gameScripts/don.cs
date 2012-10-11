function Don::onLevelLoaded(%this, %scenegraph)
{

   $Don = %this;   
   
   %this.enableUpdateCallback();
   
   %this.startSize = %this.size;
   %this.targetSize = %this.startSize;
   
   %this.scaleAmount = t2dVectorSub(t2dVectorScale(%this.startSize,5.0), %this.startSize);
}

function Don::showDon()
{
   $Don.setVisible(true);
   $Don.targetSize = t2dVectorScale($Don.startSize, 5.0);
}

function Don::hideDon()
{
   $Don.setVisible(false);
   $Don.targetSize = $Don.startSize;
}

function Don::onUpdate(%this)
{
   %currentX = %this.size.x;
   %targetX = %this.targetSize.x;
   %scaleX = %this.scaleAmount.x;
   
   %currentY = %this.size.y;
   %targetY = %this.targetSize.y;
   %scaleY = %this.scaleAmount.y;
   
   if ((%currentX == %targetX) && (%currentY == %targetY))
      return;
   
   if (%currentX < %targetX)
   {
      %this.setSizeX(%currentX + ((0.032 / 0.25) * %scaleX));
      if (%this.getSizeX() > %targetX)
         %this.setSizeX(%targetX);
   }
   else if (%currentX > %targetX)
   {
      %this.setSizeX(%currentX - ((0.032 /  0.25) * %scaleX));
      if (%this.getSizeX() < %targetX)
         %this.setSizeX(%targetX);
   }
   
   if (%currentY < %targetY)
   {
      %this.setSizeY(%currentY + ((0.032 /  0.25) * %scaleY));
      if (%this.getSizeY() > %targetY)
         %this.setSizeY(%targetY);
   }
   else if (%currentY > %targetY)
   {
      %this.setSizeY(%currentY - ((0.032 /  0.25) * %scaleY));
      if (%this.getSizeY() < %targetY)
         %this.setSizeY(%targetY);
   }
}
