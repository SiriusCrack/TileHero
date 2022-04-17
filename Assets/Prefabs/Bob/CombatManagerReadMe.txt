Prefab Name: Combat Manager

Summary:
Facilitates communication between npcs and handles all combat related activities. This is essentially an empty object with just the combatmanager script attached.

Use: 
Use: Before running the game, you must ensure that the hero, an object of type Hero which will be the main character, and an attack command, which is just an attack command object, are added into the combat manager. The manager should be able to handle the rest.

Components:
CombatManager (Script) - the combat manager script. if you have questions the script is heavily commented.
AudioSource - The first one should hold the bell sound effect used for when the hero makes an attack, the second should be the sound effect from runescape used when the enemies make an attack. NOTE: I don't know how to make sounds overlap, so the sounds are out of sync with the attacks since they have to wait for the previous sound to finish.

TroubleShooting:
Most errors from within this script come from null errors, so make sure that all the enemies and the hero have weapons set. I should have used Oscar's Null Weapon, but I never got around to it. If you've double checked all the NPCs and you're still having issues, everything is broken up into functions so you can isolate the issue + there are plenty of comments.




