# Renshen Defender SL5
[![license](https://img.shields.io/github/license/Genius-Society/renshen_defender)](https://github.com/Genius-Society/renshen_defender/blob/master/LICENSE)
[![Build status](https://img.shields.io/badge/build-passing-4dc81f)](https://ci.appveyor.com/project/Genius-Society/Renshen-Defender)
[![itch](https://img.shields.io/badge/release-itch.io-fa5c5c.svg)](https://genius-society.itch.io/renshen-defender-sl5)

This is a save-load patch for game `みらくる超パーティー 早苗と天子の幻想迷宫 PLUS.G.` on Windows PC.

![](https://img.itch.zone/aW1nLzE4OTU4NDA1LnBuZw==/original/nctZzb.png)

This patch comes with built-in transcoding functionality, so there's no need to install an external transcoder. Important usage notes:

- When you enter a new level and wish to save the initial state, you can save directly using the tool's save button without exiting the game normally.
- However, if you want to save mid-level, you need to exit the game normally before saving, then click “Resume” to continue playing.

The patch also includes modifications for HP, hunger, strength, and money, along with a locking feature—please use these functions with caution.

![](https://img.itch.zone/aW1nLzIwNDY4MzQ2LnBuZw==/original/NsJoV7.png)

## Download
```bash
git clone -b sl5 git@github.com:Genius-Society/renshen_defender.git
cd renshen_defender
```

## Requirements
1. Compatible with Windows 7+
2. Microsoft. NET Framework 3.5+ required
3. [DirectX](https://download.microsoft.com/download/1/7/1/1718CCC4-6315-4D8E-9543-8E28A4E18C4C/dxwebsetup.exe) required
4. Make sure installation path is only composed of English or Japanese letters

## Debugging
1. Clone the repo to local
2. Install Microsoft Visual Studio 2010+
3. Download and unzip the game body into `./SL5/bin/Debug`
4. Open _SL5.sln_ as admin
5. Perform _build_ action

## Thanks
- <https://www.aquastyle.org/miracho/top.html>
- <https://www.cheatengine.org>