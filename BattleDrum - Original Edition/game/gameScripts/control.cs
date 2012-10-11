$count = 0;
$rhythm = 0;

$DrumCount[0] = 0;
$DrumCount[1] = 0;
$DrumCount[2] = 0;
$DrumCount[3] = 0;

$Time[0] = 0;
$Time[1] = 0;
$Time[2] = 0;
$Time[3] = 0;


function Control::onLevelLoaded(%this, %scenegraph)
{	
	moveMap.bindCmd(keyboard, "w", "Wcount(); DrumCommand(); playDjembeW(); $Sun.growSun();$Ta.showTa();", "$Sun.backSun();$Ta.hideTa();");
	moveMap.bindCmd(keyboard, "s", "Scount(); DrumCommand(); playDjembeS(); $Sun.growSun();$Don.showDon();", "$Sun.backSun();$Don.hideDon();");		
	moveMap.bindCmd(keyboard, "a", "Acount(); DrumCommand(); playDjembeA(); $Sun.growSun();$Pa.showPa();", "$Sun.backSun();$Pa.hidePa();");
	moveMap.bindCmd(keyboard, "d", "Dcount(); DrumCommand(); playDjembeD(); $Sun.growSun();$Pon.showPon();", "$Sun.backSun();$Pon.hidePon();");
	
	moveMap.bindCmd(keyboard, "left", "$EnemyKnight1.KnightLeft();", "$EnemyKnight1.KnightLeftStop();");
	moveMap.bindCmd(keyboard, "right", "$EnemyKnight1.KnightRight();", "$EnemyKnight1.KnightRightStop();");
	moveMap.bindCmd(keyboard, "up", "$EnemyKnight1.KnightUp();", "$EnemyKnight1.KnightUpStop();");
	moveMap.bindCmd(keyboard, "down", "$EnemyKnight1.KnightDown();", "$EnemyKnight1.KnightDownStop();");
	moveMap.bindCmd(keyboard, "enter", "$EnemyKnight1.KnightAttack();", "$EnemyKnight1.KnightAttackStop();");
	moveMap.bindCmd(keyboard, "space", "ResetTime();ResetCount();", "");
	
}



function Wcount(){
   $count = $count + 1;
   $DrumCount[$count - 1] = "w";
   $Time[$count - 1] = getRealTime() / 1000;
   echo("Count: " SPC $count);
   echo("Time: " SPC $Time[$count - 1]);
}

function Scount(){
   $count = $count + 1;
   $DrumCount[$count - 1] = "s";
   $Time[$count - 1] = getRealTime() / 1000;
   echo("Count: " SPC $count);
   echo("Time: " SPC $Time[$count - 1]);
}
function Acount(){
   $count = $count + 1;
   $DrumCount[$count - 1] = "a";
   $Time[$count - 1] = getRealTime() / 1000;
   echo("Count: " SPC $count);
   echo("Time: " SPC $Time[$count - 1]);
}
function Dcount(){
   $count = $count + 1;
   $DrumCount[$count - 1] = "d";
   $Time[$count - 1] = getRealTime() / 1000;
   echo("Count: " SPC $count);
   echo("Time: " SPC $Time[$count - 1]);
}

function checkRhythm(){
   if($Time[1] - $Time[0] < 1.5 && $Time[1] - $Time[0] > 0.5
   && $Time[2] - $Time[1] < 1.5 && $Time[2] - $Time[1] > 0.5
   && $Time[3] - $Time[2] < 1.5 && $Time[3] - $Time[2] > 0.5){
      $rhythm = 1;
   }else if($Time[1] - $Time[0] > 1.5 
   || $Time[2] - $Time[1] > 1.5
   || $Time[3] - $Time[2] > 1.5){
      ResetCount();
      ResetTime();
   }
}

function DrumCommand(){
   
   checkRhythm();
   
   if($count == 4 
   && $DrumCount[0] $= "a" 
   && $DrumCount[1] $= "a" 
   && $DrumCount[2] $= "a" 
   && $DrumCount[3] $= "d"
   && $rhythm){
      ResetTime();
      ResetCount();
      MoveRight();
   }
   
   else if($count == 4 
   && $DrumCount[0] $= "d" 
   && $DrumCount[1] $= "d" 
   && $DrumCount[2] $= "a" 
   && $DrumCount[3] $= "a"
   && $rhythm){
      ResetTime();
      ResetCount();
      MoveLeft();
   }
   
   else if($count == 4 
   && $DrumCount[0] $= "d" 
   && $DrumCount[1] $= "d" 
   && $DrumCount[2] $= "a" 
   && $DrumCount[3] $= "d"
   && $rhythm){
      ResetTime();
      ResetCount();
      Attack();
   }
   else if($count == 4 
   && $DrumCount[0] $= "w" 
   && $DrumCount[1] $= "w" 
   && $DrumCount[2] $= "s" 
   && $DrumCount[3] $= "d"
   && $rhythm){
      ResetTime();
      ResetCount();
      Special();
   }
   
   
   else if($count == 4){
      ResetTime();
      ResetCount();
   }
   
   
}


function ResetCount(){
   $count = 0;
   $DrumCount[0] = "n" ;
   $DrumCount[1] = "n" ;
   $DrumCount[2] = "n" ;
   $DrumCount[3] = "n" ;
}
function ResetTime(){
   $Time[0] = 0;
   $Time[1] = 0;
   $Time[2] = 0;
   $Time[3] = 0;
   $rhythm = 0;
}

function MoveUp()
{
	if($count == 4){
	   $Knight.KnightUp();
	   $Knight1.KnightUp();
	   $Archer.ArcherUp();
	   $Archer1.ArcherUp();
	   $Archer2.ArcherUp();
	   $Infantry.InfantryUp();
	   $Infantry1.InfantryUp();
	   
	   $Shield.ShieldUp();
	   
	   $count = 0;
   
	   schedule(500, $Knight, "Knight::KnightUpStop");
	   schedule(500, $Knight1, "Knight1::KnightUpStop");
	   schedule(500, $Archer, "Archer::ArcherUpStop"); 
	   schedule(500, $Archer1, "Archer1::ArcherUpStop");
	   schedule(500, $Archer2, "Archer2::ArcherUpStop");
	   schedule(500, $Infantry, "Infantry::InfantryUpStop"); 
	   schedule(500, $Infantry1, "Infantry1::InfantryUpStop");
	   
	   schedule(500, $Shield, "Shield::ShieldUpStop"); 
	}   
}

function MoveDown()
{
	if($count == 4){
	   $Knight.KnightDown();
	   $Knight1.KnightDown();
	   $Archer.ArcherDown();
	   $Archer1.ArcherDown();
      $Archer2.ArcherDown();
	   $Infantry.InfantryDown();
      $Infantry1.InfantryDown();
	   
	   $Shield.ShieldDown();
	   
	   $count = 0;
   
	   schedule(500, $Knight, "Knight::KnightDownStop");
	   schedule(500, $Knight1, "Knight1::KnightDownStop");
	   schedule(500, $Archer, "Archer::ArcherDownStop"); 
	   schedule(500, $Archer1, "Archer1::ArcherDownStop");
	   schedule(500, $Archer2, "Archer2::ArcherDownStop");
	   schedule(500, $Infantry, "Infantry::InfantryDownStop"); 
      schedule(500, $Infantry1, "Infantry1::InfantryDownStop"); 
	   
	   schedule(500, $Shield, "Shield::ShieldDownStop"); 
	}   
}

function MoveLeft()
{
	   $Knight.KnightLeft();
	   $Knight1.KnightLeft();
	   $Archer.ArcherLeft();
	   $Archer1.ArcherLeft();
      $Archer2.ArcherLeft();
	   $Infantry.InfantryLeft();
      $Infantry1.InfantryLeft();
	   $Shield.ShieldLeft();
	   
	   //stop 
	   schedule(500, $Knight, "Knight::KnightLeftStop");
	   schedule(500, $Knight1, "Knight1::KnightLeftStop");
	   schedule(500, $Archer, "Archer::ArcherLeftStop"); 
	   schedule(500, $Archer1, "Archer1::ArcherLeftStop");
      schedule(500, $Archer2, "Archer2::ArcherLeftStop");
	   schedule(500, $Infantry, "Infantry::InfantryLeftStop");
      schedule(500, $Infantry1, "Infantry1::InfantryLeftStop");
      schedule(500, $Shield, "Shield::ShieldLeftStop");
      
      //turn right
      schedule(500, $Knight, "Knight::KnightRight");
      schedule(500, $Knight, "Knight::KnightRightStop");
	   schedule(500, $Knight1, "Knight1::KnightRight");
	   schedule(500, $Knight1, "Knight1::KnightRightStop");
	   schedule(500, $Archer, "Archer::ArcherRight"); 
	   schedule(500, $Archer, "Archer::ArcherRightStop"); 
	   schedule(500, $Archer1, "Archer1::ArcherRight");
	   schedule(500, $Archer1, "Archer1::ArcherRightStop");
      schedule(500, $Archer2, "Archer2::ArcherRight");
	   schedule(500, $Archer2, "Archer2::ArcherRightStop");
	   schedule(500, $Infantry, "Infantry::InfantryRight");
      schedule(500, $Infantry, "Infantry::InfantryRightStop");
      schedule(500, $Infantry1, "Infantry1::InfantryRight");
      schedule(500, $Infantry1, "Infantry1::InfantryRightStop");
      schedule(500, $Shield, "Shield::ShieldRight");
      schedule(500, $Shield, "Shield::ShieldRightStop");
	   
	     
}

function MoveRight()
{
	   $Knight.KnightRight();
	   $Knight1.KnightRight();
	   $Archer.ArcherRight();
	   $Archer1.ArcherRight();
	   $Archer2.ArcherRight();
	   $Infantry.InfantryRight();
	   $Infantry1.InfantryRight();
	   
	   $Shield.ShieldRight();
   
	   schedule(500, $Knight, "Knight::KnightRightStop");
	   schedule(500, $Knight1, "Knight1::KnightRightStop");
	   schedule(500, $Archer, "Archer::ArcherRightStop"); 
	   schedule(500, $Archer1, "Archer1::ArcherRightStop");
	   schedule(500, $Archer2, "Archer2::ArcherRightStop");
	   schedule(500, $Infantry, "Infantry::InfantryRightStop");
	   schedule(500, $Infantry1, "Infantry1::InfantryRightStop");
	    
	   schedule(500, $Shield, "Shield::ShieldRightStop");
	   
}

function Attack()
{
      $Infantry.InfantryBoost();
      $Infantry1.InfantryBoost();
      $Archer.ArcherFire();
      $Archer1.ArcherFire();
      $Archer2.ArcherFire();
      $Knight.KnightBoost();
      $Knight1.KnightBoost();
      
     

      //Knight 1
      schedule(500, $Knight, "Knight::KnightBoostStop");
      schedule(500, $Knight, "Knight::KnightAttack");
      schedule(1000, $Knight, $Knight.Fire($Knight,true));
      schedule(1700, $Knight, "Knight::KnightAttackStop");
      
      schedule(1800, $Knight, "Knight::KnightLeft");
      schedule(3300, $Knight, "Knight::KnightRight");
      schedule(3300, $Knight, "Knight::KnightLeftStop");
      schedule(3300, $Knight, "Knight::KnightRightStop");   
      
      //Knight 2 
      schedule(500, $Knight1, "Knight1::KnightBoostStop");
      schedule(500, $Knight1, "Knight1::KnightAttack");
      schedule(1000, $Knight1, $Knight1.Fire($Knight1,true));
      schedule(1700, $Knight1, "Knight1::KnightAttackStop");
      
      schedule(1800, $Knight1, "Knight1::KnightLeft");
      schedule(3300, $Knight1, "Knight1::KnightRight");
      schedule(3300, $Knight1, "Knight1::KnightLeftStop");
      schedule(3300, $Knight1, "Knight1::KnightRightStop"); 
    
      //Archer 1
      schedule(1000, $Archer, "Archer::ArcherFireStop"); 
      schedule(2000, $Archer, $Archer.Fire($Archer,true));
      //schedule(2300, $Archer, $Archer.Fire()); 
      
      //Archer 2
      schedule(1000, $Archer1, "Archer1::ArcherFireStop"); 
      schedule(2000, $Archer1, $Archer1.Fire($Archer1,true));
      //schedule(2300, $Archer1, $Archer1.Fire()); 
      
      //Archer 3
      schedule(1000, $Archer2, "Archer2::ArcherFireStop"); 
      schedule(2000, $Archer2, $Archer2.Fire($Archer1,true));
      //schedule(2300, $Archer1, $Archer1.Fire()); 
      
      //Infantry 1
      schedule(500, $Infantry, "Infantry::InfantryBoostStop");
      schedule(500, $Infantry, "Infantry::InfantryAttack");
      schedule(1000, $Infantry, $Infantry.Fire($Infantry,true));
      schedule(1700, $Infantry, "Infantry::InfantryAttackStop");
      
      schedule(1800, $Infantry, "Infantry::InfantryLeft");
      schedule(2800, $Infantry, "Infantry::InfantryRight");
      schedule(2800, $Infantry, "Infantry::InfantryLeftStop");
      schedule(2800, $Infantry, "Infantry::InfantryRightStop");  
      
      //Infantry 2
      schedule(500, $Infantry1, "Infantry1::InfantryBoostStop");
      schedule(500, $Infantry1, "Infantry1::InfantryAttack");
      schedule(1000, $Infantry1, $Infantry1.Fire($Infantry1,true));
      schedule(1700, $Infantry1, "Infantry1::InfantryAttackStop");
      
      schedule(1800, $Infantry1, "Infantry1::InfantryLeft");
      schedule(2800, $Infantry1, "Infantry1::InfantryRight");
      schedule(2800, $Infantry1, "Infantry1::InfantryLeftStop");
      schedule(2800, $Infantry1, "Infantry1::InfantryRightStop");  

}

function Special()
{
   $Shield.Fire($Shield, true);

   $Shield.ShieldDefense();
   schedule(1000, $Shield, "Shield::ShieldDefenseStop");
}
