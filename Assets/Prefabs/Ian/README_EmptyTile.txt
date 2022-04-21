// README FILE FOR EMPTYTILE PREFAB // Author: Ian Fleming

Prefab Name: EmptyTile

Prefab Type: GameObject

Tag(s): EmptyTile

Prefab Variant: False (Actually the parent to other prefabs)

Contained Children Objects: NorthDoor, EastDoor, SouthDoor, WestDoor, Select, Highlight

Synopsis/Purpose:
This prefab is responsible to be the initial game object tile that the grid manager will initialize.
This prefab lays the foundation for the initial grid (apart from the Start and End Tiles).
It's children objects are the doors that point to all directions (compass format) and
two additional game objects, Select and Highlight, that are responsible for producing
visual interactive effects in the game, e.g. player selects or highlights a tile.
This prefab is a parent to all the other tiles that are variants of it.
This prefab is very important and imperative to the function of the game.