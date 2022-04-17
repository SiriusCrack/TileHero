Prefab Name: AttackCommandPrefab

Summary:
Basically acts as a struct which stores all relevant information about an attack. You cannot instantiate a monobehavior, so we need to create a prefab that we can instantiate.

Use: 
Must be attached to the CombatManager.

Components:
AttackCommand (Script) - The script. If you have questions please see the comments in that script.

TroubleShooting:
Issues arising from this are likely in the RecieveAttack function in the NPC class, or in the SendAttack function in the CombatManager class. This object is really not complex enough to where issues should arise.