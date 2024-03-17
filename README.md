# Band Live

A band management game based on the core gameplay of Rock Band and Guitar Hero.

![Logo here](/page/title.jpg)

Still in a very early state with "beautiful" placeholder graphics. (You thought OpenGL Immediate Mode died decades ago? Nope, it's still convenient for quick and dirty prototypes)

## See it in action
[![](/page/yt_thumb.jpg)](https://www.youtube.com/watch?v=1sE4Zg6Y-NQ)

## What's in the box (so far)?

* All instruments
* Vocals and Harmonies
* Support for MIDI instruments
* Support for RB3 Keyboard
* Support for RB3 Pro Guitar
* Support for songs in .mid format
* Support for CON files (single song and packs)
* Trills, strum lanes, glissandos (experimental)

## How do I try it?

Download, extract, run. Well, almost. Unless you want to copy your song library into the songs directory, you will need to edit the config.ini.

Either change the existing song_folder entry or add a new one. Song location is a filter and sorting criteria in the song list, so having multiple folders configured can be useful to get the songs you want more quickly.

## I have a proper MIDI keyboard/drum kit, but lost my adapter

Good. No, seriously. Just connect them directly to your PC. In fact, that will solve quite a few quirks with drums that result from the way Harmonix added ProDrums. If you ever noticed the wrong inputs triggering when hitting a tom and a cymbal at exactly the same time, you know what I mean.

## Okay, I'm all setup, started it and.. what now?

By default, a randomly selected song should start playing and you are ready to join. Only press Space if you have no instruments, want to use a MIDI instrument or play vocals (or you're a masochist and really want to play guitar or 5 button keyboard that way).

Tab or the Start button on your instrument will open the song list. Please note that if you select a song and exit the song list (Esc, "Red" or Start), the song will keep playing from it's current point (usually the preview). Press Enter or "Green" to properly start the song.

Controls in the menu are color coded (orange opens the filters, blue scrolls faster, etc.).

## Can I play with friends?

Sure. Bring them all...

![Almost full band](https://github.com/afestini/BandLive/blob/main/page/fullband.jpg)

## Anything special beyond the other clones?

Maybe. The current state is more of a practice mode to allow for debugging and developing. That gives you a lot of options you won't have when playing properly, like:
* up/down cursor keys to fast forward/backward
* +/- num keys to skip forward/backward 10s
* left_right cursor keys to quick change difficulties for all players
* quick song select (insert/delete for next/previous song, home/end jumps 20 songs, page up/down jumps 200 songs)
* 'Tab' to open/close song list
* 'S' to toggle slow-mo. This is really just to debug and will make you fall asleep otherwise
* 'M' to mute/unmute a song that really annoys you
* 'C', 'V' to place loop markers. The song will loop the selected section until you clear the markers with 'X'
* 'R' to quickly restart the song
* 'K' to calibrate audio, video and microphone
* 'J' to auto calibrate (only PS3 pro guitar controller for now)
* 'L' to reload config.ini without restarting
* 'T' will show some realtime profiling info. If you have lousy performance, this is where you go and let me know which one is the problem
* 'F' if you want to see how the pitch detection sausage is made. The waveform at the top might be useful to troubleshoot your microphone.

## Tried it. Done with it. What now?

Feedback. Feedback... and maybe more Feedback

* Vocals: different microphones can behave very differently (base noise, volume, how well they pick up background noise). If you had trouble, let me know what your setup was (dynamic or condenser microphone, proper microphone or webcam/notebook mic, etc.)
 
* Menus: how well did the UI work for you, particularly when using an instrument? Was it intuitive or confusing, did it feel easy to use or clunky and making things hard?

* Performance: I can only test on my own PC, which is fairly beefy. Especially AMD/ATI might have some unexpected performance issues when a game isn't following all the "best practices", which this one is most definitely not (don't worry, proper graphics are on the list and to be started soon).

* Load times: they shouldn't be too bad, but since it's only tested on SSDs, old school hard drives might be slow when loading too much at once

##Not much there yet. What's the plan for this?

While Quick Play is always nice for some quick fun, I want to have more focus on the band. Managing band members with different skills, aquiring (aka unlocking) more songs in various ways, playing songs in other contexts than gigs and concerts with different options/rules.
