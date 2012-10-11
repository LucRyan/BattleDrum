function Pa::onLevelLoaded(%this, %scenegraph)
{

   $Pa = %this;   
   
   %this.enableUpdateCallback();
   
   %this.startSize = %this.size;
   %this.targetSize = %this.startSize;
   
   %this.scaleAmount = t2dVectorSub(t2dVectorScale(%this.startSize,5.0), %this.startSize);
}

function Pa::showPa()
{
   $Pa.setVisible(true);
   $Pa.targetSize = t2dVectorScale($Pa.startSize, 5.0);
}

function Pa::hidePa()
{
   $Pa.setVisible(false);
   $Pa.targetSize = $Pa.startSize;
}

function Pa::onUpdate(%this)
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
