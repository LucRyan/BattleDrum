//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------
//
// This is the file you should define your custom datablocks that are to be used
// in the editor.
//
datablock t2dSceneObjectDatablock(CloudsDatablock) {
   Class = "cloudsClass";
   Layer = "21";
   WorldLimitMode = "NULL";
   WorldLimitMin = "-69.2102 -38";
   WorldLimitMax = "69.1003 -1";
   WorldLimitCallback = "1";
      minSpeed = "1";
      maxSpeed = "10";
};


datablock t2dSceneObjectDatablock(KnightDatablock) {
   Class = "Knight";
   Layer = "5";
   WorldLimitMode = "CLAMP";
   WorldLimitMin = "-51.2102 5";
   WorldLimitMax = "52 37";

      vSpeed = "10";
      hSpeed = "15";
      life = "80";
      strength ="5";
};

datablock t2dSceneObjectDatablock(ArcherDatablock) {
   Class = "Archer";
   Layer = "6";
   WorldLimitMode = "CLAMP";
   WorldLimitMin = "-51.2102 5";
   WorldLimitMax = "52 37";

      vSpeed = "10";
      hSpeed = "15";
      life = "50";
      strength ="8";
};

datablock t2dSceneObjectDatablock(InfantryDatablock) {
   Class = "Infantry";
   Layer = "7";
   WorldLimitMode = "CLAMP";
   WorldLimitMin = "-51.2102 5";
   WorldLimitMax = "52 37";

      vSpeed = "10";
      hSpeed = "15";
      life = "70";
      strength ="5";
};
datablock t2dSceneObjectDatablock(ShieldDatablock) {
   Class = "Shield";
   Layer = "7";
   WorldLimitMode = "CLAMP";
   WorldLimitMin = "-51.2102 5";
   WorldLimitMax = "52 37";

      vSpeed = "10";
      hSpeed = "15";
      life = "90";
      strength ="3";
};


datablock t2dSceneObjectDatablock(EnemyDatablock) {
   Class = "Enemy";
   Layer = "10";
   WorldLimitMode = "CLAMP";
   WorldLimitMin = "-51.2102 5";
   WorldLimitMax = "52 37";

      vSpeed = "10";
      hSpeed = "15";
      life = "100";
      strength ="2";
};

datablock t2dSceneObjectDatablock(EnemyKnightDatablock) {
   Class = "EnemyKnight1";
   Layer = "5";
   WorldLimitMode = "CLAMP";
   WorldLimitMin = "-51.2102 5";
   WorldLimitMax = "70 37";

      vSpeed = "10";
      hSpeed = "15";
      life = "80";
      strength ="5";
};