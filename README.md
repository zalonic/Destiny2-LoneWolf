# Destiny 2 - Lone Wolf (for Windows PC)

# What does this do?
This tool disables matchmaking in Destiny 2, allowing the player to play Strikes by themselves as if you are like me you sometimes don't want to speed through the stike and getting matched with speedrunners is a pain.

**I recommend being in Orbit, before turning on Lone Wolf mode.**

## **DO NOT TRY AND USE THIS WITH CRUCIBLE/TRIALS OR GAMBIT**
1. I have no idea what this would do as it is not tested due to reason 2.
2. I would imaging this counts as cheating so could be a banable offence.

# How does this work?
It adds and removes custom inbound and outbound rules to the Windows Firewall to block [ISteamNetworkingSockets](https://github.com/ValveSoftware/GameNetworkingSockets).

[FirewallCommands.cs](https://github.com/zalonic/Destiny2-LoneWolf/blob/main/Source/Destiny2-LoneWolf/Models/FirewallCommands.cs)
credit goes to
[Matthew Lee (fmmmlee/D2Solo)](https://github.com/fmmmlee/D2Solo)
, I just wanted a smaller design and wrote a new frontend using
[PrismLibrary](https://github.com/PrismLibrary/Prism)
, with some personally prefered cosmetic tweeks and an additional port.

# What does it look like?
The app is run at the top most level of the screen so it will show on top right of the Destiny 2 game screen.

The below images represent what state Lone Wolf is in. Clicking the image in the top right will swap between the two modes.
|   Disabled   |    Enabled   |
| ------------ | ------------ |
| ![lwDisabled]| ![lwEnabled] |

Right clicking the icon will show the below contect menu.

![contextMenu]

# Help Section

## Closed the app but forgot to turn off Lone Wolf mode first?
No problem, the app will automatically remove the blocked firewall ports when it closed.

## Had to kill the app via Task Manager?
This means Lone Wolf mode is still activate, just open the app again and it is designed to check and remove the firewall rules when it first opens, if they are found. The application can then be closed again.

## Want to delete the ports manually? What they are called in the Firewall:
```
Destiny 2 - Lone Wolf (UDP-Out)

Destiny 2 - Lone Wolf (TCP-Out)

Destiny 2 - Lone Wolf (UDP-In)

Destiny 2 - Lone Wolf (TCP-In)
```

##### Disclaimer: This might be against the Destiny 2 Terms of Service and as such is to be used at your own risk. This is an unofficial tool and the author is not affiliated with or endorsed by Bungie Inc. All trademarks, registered trademarks, logos, art, etc are the property of their respective owners.

[lwDisabled]: https://raw.githubusercontent.com/zalonic/Destiny2-LoneWolf/main/Resources/lwDisabled.png
[lwEnabled]: https://raw.githubusercontent.com/zalonic/Destiny2-LoneWolf/main/Resources/lwEnabled.png
[contextMenu]: https://raw.githubusercontent.com/zalonic/Destiny2-LoneWolf/main/Resources/contextMenu.png
