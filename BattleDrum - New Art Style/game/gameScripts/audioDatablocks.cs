new AudioDescription(AudioNonLooping)

{

volume = 5.0;

isLooping= false;

is3D = false;

type = $GuiAudioType;

};




new AudioDescription(AudioLooping)

{

volume = 0.8;

isLooping= true;

is3D = false;

type = $GuiAudioType;

};
 



// --------------------------------------------------------------------

// Background Loop.

// --------------------------------------------------------------------

new AudioProfile(backgroundAudio)

{

filename = "~/data/audio/background.wav";

description = "AudioLooping";

preload = true;

};




// --------------------------------------------------------------------

// Single Blip.

// --------------------------------------------------------------------

new AudioProfile(blipAudio)

{

filename = "~/data/audio/BLIP.wav";

description = "AudioNonLooping";

preload = true;

};

new AudioProfile(DjembeDAudio)

{

filename = "~/data/audio/djembe7.wav";

description = "AudioNonLooping";

preload = true;

};


new AudioProfile(DjembeWAudio)

{

filename = "~/data/audio/djembe8.wav";

description = "AudioNonLooping";

preload = true;

};


new AudioProfile(DjembeAAudio)

{

filename = "~/data/audio/djembe9.wav";

description = "AudioNonLooping";

preload = true;

};


new AudioProfile(DjembeSAudio)

{

filename = "~/data/audio/djembe10.wav";

description = "AudioNonLooping";

preload = true;

};

// --------------------------------------------------------------------

// Play Audio.

// --------------------------------------------------------------------

function playBackground()
{
   alxPlay("backgroundAudio");
}

function playBlip()
{
   alxPlay("blipAudio");
}

function playDjembeD()
{
   alxPlay("DjembeDAudio");
}
function playDjembeA()
{
   alxPlay("DjembeAAudio");
}
function playDjembeS()
{
   alxPlay("DjembeSAudio");
}
function playDjembeW()
{
   alxPlay("DjembeWAudio");
}