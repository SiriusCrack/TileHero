Prefab Name: Health Bar Canvas

Summary:
Canvas holding onto the health bar object, the health bar will not work without it.

Use: 
Must be attached to a CombatAI in order to function.

Child Objects:
Health Bar - The health bar contains the rest of these objects. It has a slider which will be updated by a CombatAI. The slider determines how much red and how much gray are displayed on the health bar.

Health Bar Red/Gray - Two images, the red is on top of the gray, and the red will be hidden as the npc takes damage.

Components:
There are many graphics components which I do not understand. Do not worry about them.

TroubleShooting:
If there are issues with the health bar canvas, it's probably because of the CombatAI. I would check there.