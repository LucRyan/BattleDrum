function Sun::onLevelLoaded(%this, %scenegraph)
{

   $Sun = %this;   
   
   %this.enableUpdateCallback();
   
   %this.startSize = %this.size;
   %this.targetSize = %this.startSize;
   
   %this.scaleAmount = t2dVectorSub(t2dVectorScale(%this.startSize,1.50), %this.startSize);
}

function Sun::growSun()
{
   $Sun.targetSize = t2dVectorScale($Sun.startSize, 1.50);
}

function Sun::backSun()
{
   $Sun.targetSize = $Sun.startSize;
}

function Sun::onUpdate(%this)
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
