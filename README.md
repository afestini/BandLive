# Band Live

A band management game based on the core gameplay of Rock Band and Guitar Hero.

![Logo here](https://github.com/afestini/BandLive/blob/main/page/title.jpg)

Still in a very early state with "beautiful" placeholder graphics. (You thought OpenGL Immediate Mode died decades ago? Nope, it's still convenient for quick and dirty prototypes)

[![See it in action](https://img.youtube.com/vi/1sE4Zg6Y-NQ/maxresdefault.jpg)](https://www.youtube.com/watch?v=1sE4Zg6Y-NQ)

## What's in the box (so far)?

* All instruments (except Pro Guitar)
* Vocals and Harmonies
* Support for MIDI instruments
* Support for RB3 Keyboard
* Support for songs in .mid format

## How do I try it?

Download, extract, run. Well, almost. Unless you want to copy your song library into the songs directory, you will need to edit the config.ini.

Either change the existing song_folder entry or add a new one. Song location is a filter and sorting criteria, so having multiple folders configured can be useful.

If you also want to use a Rock Band keyboard without going through MIDI, you need to force Windows to use WinUSB drivers. The short version:
* Device Manager -> Harmonix RB3 Keyboard
* Update Drivers
* Browse My Computer...
* Let me pick from a list...
* Uncheck "Show compatible hardware"
* WinUsb Device -> WinUsb Device

Only tested with the PS3 version, but there is a good chance the Wii version will work as well.

## I have a proper MIDI keyboard/drum kit, but lost my adapter

Good. No, seriously. Just connect them directly to your PC. In fact, that will solve quite a few quirks with drums that result from the way Harmonix added ProDrums. If you ever noticed the wrong inputs triggering when hitting a tom and a cymbal at exactly the same time, you know what I mean.

## Okay, I'm all setup, started it and.. what now?

By default, a randomly selected song should start playing and you are ready to join. Only press Space if you have no instruments, want to use a MIDI instrument or play vocals (or you're a masochist and really want to play guitar or 5 button keyboard that way).

Tab or the Start button on your instrument will open the song list. Please note that if you select a song and exit the song list (Esc, "Red" or Start), the song will keep playing from it's current point (usually the preview). Press Enter or "Green" to properly start the song.

Controls in the menu are color coded (orange opens the filters, blue scrolls faster, etc.).

## Can I play with friends?

Sure. Bring them all...

![Almost full band](https://github.com/afestini/BandLive/blob/main/page/fullband.jpg)

Better bring a big ultra wide screen, though. There are some limits, however. SFML can only handle 8 controllers. On the bright side, the RB3 Keyboards are handled differently and don't count. So the theoretical limit is currently 10 players with instruments, up to three of those could also sing harmonies.

## Anything special beyond the other clones?

Maybe. The current state is more of a practice mode to allow for debugging and developing. That gives you a lot of options you won't have when playing properly, like:
* fast forward/backward with up/down keys
* skip forward/backward 10s with +/- keys
* quick change difficulties for all players with left/right keys
* quick song select (insert/del for next/previous song, home/end jumps 20 songs, page up/down jumps 200 songs)
* slow-mo.. press 'S' to go extra slow. This is really just to debug and will make you fall asleep otherwise
* mute game.. press 'M' to mute/unmute if a song just really annoys you
* 'C', 'V' to place loop markers. The song will loop the selected section until you clear the markers with 'X'
* 'R' to quickly restart the song
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
