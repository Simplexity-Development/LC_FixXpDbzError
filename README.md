# Fix XP Divide By Zero Error

## The Problem

During our modding and gameplay throughout Lethal Company, we regularly suffered from issues like desync and the game just outright hanging and stopping.

While we are not convinced that the XP Divide By Zero error necessarily caused desync, there were a few things that were odd...

- The host would hear a "clicking" sound (we later found out it was the XP Bar increase sound).
  - This indicated to the host that there was desync.
  - Sometimes we could still leave the planet and the game would save.
- Sometimes, when leaving the planet, it would go through all the motions but fail right before saving.
  - We later found out that it was because of the Divide By Zero error.

## The Workaround

The code divides by "XPMax" which, for whatever reason during something in our games, would get set to 0.

This mod simply goes to the HUDManager and before doing SetPlayerLevel, sets XPMax to 1 if it is 0.

I do not know if this mod is necessary when you are not the host.

## The Result

So far, we have not suffered from desync problems or issues with the game.

- The game no longer will hang when it usually did (tested on a save file we kept where the problem was).
- We are not suffering from desync problems anymore.
  - This is not necessarily a fix for desync, we did a few things to also minimize the chance for desync.
  - We just believe there may be a correlation due to the earlier problem listed.

I do not know what mods or corruption or whatever could have happened to cause XPMax to be set to 0.