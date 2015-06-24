
# Making Minecraft

This tutorial shows a way to create the very basic game mechanics of Minecraft:
blocks that can be broken to drop items, a first person player who can pick up
the dropped item. (Pending: ability to place blocks.)

*Unity Version 5.1.0f3 Personal*

*MonoDevelop-Unity Version 4.0.1*

## Preliminaries

Create a 3D project and select the default layout in the editor.

  1. 3D project

     ![3D Project](./ScreenCaps/project_3d.png "3D Project")

  2. Default layout

     ![Defaut Layout](./ScreenCaps/layout_default.png "Default Layout")

## Basic Objects and Mechanics

Here we build the ground, the block prefab, and the item drop prefab.

### Ground

You can think of the following as a quick and dirty substitute for a layer of
bedrock.

  1. `Hierarchy | Create | 3D Object | Plane`
  
     ![Plane](./ScreenCaps/plane.png "Plane")

     In the `Hierarchy View`, click the `Create` dropdown, select `3D Object`
     and then `Plane`.

  2. `Inspector | Transform | Scale ( 16, 1, 16)`

     ![Select the plane](./ScreenCaps/plane_select.png "Select")
     ![Scale the plane](./ScreenCaps/plane_scale.png "Scale")

     Scale the plane in the `x` and `z` directions for plenty of room to play
     on.  The `Inspector` shows the components of the game object that is
     selected in the `Hierarchy View`, so make sure the `Plane` game object is
     selected in the `Hierarchy View` before modifying the `Transform`
     component.

  3. `Inspector | Transform | Position ( 0, -0.5, 0)`

     ![Shift the plane down](./ScreenCaps/plane_shift_down.png "Shift Down")

     Lower the plane by half a unit.
     Doing this leaves space for unit cubes centered at `y=0` so they will be
     on top of the plane.

### Blocks

We will make a block prefab, add a script to it, and add a material to it.
Explanations of prefabs, scripts, and materials are provided below as
encountered.

#### Making a Block Prefab

  1. `Hierarchy | Create | 3D Object | Cube`

     ![Create a Cube](./ScreenCaps/cube_create.png "Cube Create")

     Create a `Cube` game object.

  2. In the `Inspector`, rename `Cube` to `Block`.

     ![Select the Cube](./ScreenCaps/cube_select.png "Cube Select")

     Select the `Cube` game object in the `Hierarchy View` first.

     ![Cube name](./ScreenCaps/cube_name.png "Cube Name")

     Click on `Cube` in the field at the very top of the `Inspector View`.

     ![Cube renamed to Block](./ScreenCaps/block_name.png "Block Name")

     Change it to `Block`.

     Note that we can name it whatever we want or even leave it with the
     default name. We just have to be consistent with what we call it thereafter.
     Since cubes in Minecraft are called &ldquo;blocks&rdquo;, it makes sense
     to call them that in this project.

  3. Drag the `Block` game object from the `Hierarchy View` into the `Assets`
     folder of the `Project View`.

     ![Block prefab](./ScreenCaps/block_prefab.png "Block Prefab")

     This makes it a &ldquo;prefab&rdquo;.
     Prefabs can be added to the game multiple times resulting in multiple game
     objects that are clones of the prefab. Then changes to the prefab apply to
     all of those game objects. This is very useful to avoid having to modify
     loads of game objects just to make a simple change.  It is also useful to
     make prefabs because they can be &ldquo;instantiated&rdquo; from scripts
     dynamically at run time.  We will eventually want to do this in order to
     produce a procedurally generated terrain of blocks.

  4. Drag a few `Block` prefabs into the scene.

     ![Scene with some blocks](./ScreenCaps/scene_with_some_cubes.png "Scene With Some Blocks")

  5. In the `Inspector` for each block, manually assign their position
     coordinates to be integers and make them all have `y=0` in particular.

     ![Block1 select](./ScreenCaps/block1_select.png "Block1 Select")
     ![Block1 position](./ScreenCaps/block1_position.png "Block1 Position")

     Observe that Unity automatically numbers the game objects generated from
     prefabs.

     ![Block2 select](./ScreenCaps/block2_select.png "Block2 Select")
     ![Block2 position](./ScreenCaps/block2_position.png "Block2 Position")

     ![Block3 select](./ScreenCaps/block3_select.png "Block3 Select")
     ![Block3 position](./ScreenCaps/block3_position.png "Block3 Position")

#### Save the Scene and the Project

  1. `File | Save Scene`

     Select `File` and `Save Scene`.

     ![Save Scene](./ScreenCaps/scene_save.png "Save Scene")

     We will only have the one scene, so no need for a very purposeful name.
     Let's just name it `Scene`.

     Now a scene asset named `Scene` will appear in the `Assets` folder of the
     `Project View`.

     ![Scene Asset](./ScreenCaps/scene_asset.png "Scene Asset")

  2. `File | Save Project`
  
     Select `File` and `Save Project`.

     ![Save Project](./ScreenCaps/project_save.png "Save Project")

     The project already has a name from when we created it, so there will not
     be a prompt for naming it.

#### Adding a Script to the Block Prefab

  6. In the `Assets` folder of the `Project View`, right-click and select
     `Create | C# Script`

     ![Create MineBlock.cs script](./ScreenCaps/script_mineblock_create.png "Create MineBlock.cs Script")

  7. Rename it to `MineBlock`.

     ![Newly created MineBlock.cs script](./ScreenCaps/script_mineblock_created.png "Newly Created MineBlock.cs Script")

     Its default name is `NewBehavior`.
     Just type over that to change it to `MineBlock`.

     ![Renamed MineBlock.cs script](./ScreenCaps/script_mineblock_renamed.png "Renamed MineBlock.cs Script")

     Now double-click the `MineBlock` C# asset. That will cause the script to be loaded in Mono.

     ![Mono MineBlock initial script](./ScreenCaps/mono_mineblock_initial.png "Initial Mineblock Script In Mono")

     There is a `Start` function and an `Update` function. They are empty to
     start with. We could write code in them, but we won't for now.
     We can also add other functions. We will add another function soon.

     It is important to realize first and foremost, however, that this script
     needs to be &ldquo;attached&rdquo; to a game object (or multiple game objects).
     Let's go ahead and attach it to our block prefab before
     delving into actual coding in the script.

  8. Go back to Unity and select the `Block` prefab.

     ![Select Block Prefab](./ScreenCaps/block_prefab_select.png "Select Block Prefab")

     Now click and drag the `MineBlock` script asset over to the `Add Component`
     button in the `Inspector View` for the `Block` prefab and drop it there.

     ![MineBlock Script Drop To Add](./ScreenCaps/script_mineblock_drop_to_add.png "MineBlock Script Drop To Add")

     The `MineBlock` script will be added as a component to the `Block` prefab.

     ![MineBlock Script Added](./ScreenCaps/script_mineblock_added.png "MineBlock Script Added")

     Note that the `Add Component` button activates a menu through which we could
     have added the script as well. (There are usually multiple different ways of
     accomplishing the same thing.)

  9. Go back to Mono and add the following `OnMouseDown` function to the `MineBlock` script.

     ![Mineblock Script OnMouseDown Destroy](./ScreenCaps/script_mineblock_onmousedown_destroy.png "Mineblock Script OnMouseDown Destroy")


     Here's the code for you to copy-and-paste if necessary:

           void OnMouseDown() {
               Destroy( gameObject);
           }

     However, it is recommended that you type the code yourself to help you
     learn the patterns.

  10. Go back to Unity and run the game by clicking on the play button.

     ![Run the Game](./ScreenCaps/game_run.png "Run the Game")

     After clicking play, the buttons will be colored blue signifying that the game is playing.

     ![Game Running](./ScreenCaps/game_running.png "Game Running")

     While the game is running, click on some of the blocks and watch them
     disappear. They disappear because of the `Destroy` statement in the
     `OnMouseDown` function of the `MineBlock` script that is attached to the
     block game objects via the `Block` prefab. Whenever the mouse button is
     clicked with the mouse cursor hovering over a block, the `OnMouseDown`
     function of that block executes and thus the `Destroy(gameObject)`
     statement executes. Note that `gameObject` refers to the game object to
     which the script that contains the function that's executing is attached.

     Click the play button again to stop the game.

     **WARNING:** If you fail to stop the game before going on to make changes
     to the game, your changes will be lost when the game is stopped.  You
     *must* stop the game before making changes that you want to keep.  Note
     that it can sometimes be useful to make temporary changes to the game
     while it is running just for the purpose of diagnostics and
     experimentation, but in any case you should always be alert to whether the
     game is running or not before making changes.

  11. Save the scene and the project.

#### Hide the original `Block` game object

In the next section we are going to add a new game object to the scene.
To keep the scene view clean in preparation for that, we will now hide the
original `Block` game object that we used to make the `Block` prefab. Also,
eventually, we will be placing multitudes of blocks from a script at run time
in some systematic way and will want to remove *all* of the hand-placed blocks
from the initial scene. For now, we will leave the other few blocks that were
added to the scene via the prefab just to have something there in the
meantime. We do want to hide the original one, though, because it occupies
the special origin location that other new game objects will occupy by default.
(Alternatively, we could just move it out of the way, but we are going to
want to hide it eventually anyway so let's just do it now.)

  1. In the `Hierarchy View`, select the `Block` game object.

     ![](./ScreenCaps/block_gameobject_select.png)

  2. In the `Inspector View`, uncheck the checkbox next to the game object's name field.

     ![](./ScreenCaps/block_gameobject_hide.png)

     That game object should no longer appear in the scene. It is still listed in the
     `Hierarchy View` although dimmed.

### Drops

In Minecraft, when a block is &ldquo;mined&rdquo; it can drop a resource which
appears as a smaller version of the block floating in the space that the
original block had occupied.  This section shows how to create a dropped block
prefab and cause it to be instantiated in place of blocks whenever blocks are
destroyed.

  1. `Hierarchy | Create | 3D Object | Cube`

     ![Create a Cube](./ScreenCaps/cube_create.png "Cube Create")

     Create another `Cube` game object.

  2. Rename it `DroppedBlock`.

     ![Rename to DroppedBlock](./ScreenCaps/droppedblock_renamed.png "Rename to DroppedBlock")

  3. `Inspector | Transform | Scale (0.5,0.5,0.5)`

     ![Scale the Dropped Block](./ScreenCaps/droppedblock_scale.png "Scale the Dropped Block")

     Make it smaller.

  4. `Inspector | Transform | Rotate (15,0,5)`

     ![Rotate the Dropped Block](./ScreenCaps/droppedblock_rotation.png "Rotate the Dropped Block")

     Rotate it.

     Feel free to adjust the scale and rotation as desired. To make it look like a dropped item, it just
     needs to be smaller and tilted.

  5. Make a prefab from the `DroppedBlock` game object by dragging it into the
     `Assets` folder of the `Project View`.

     ![DroppedBlock Prefab](./ScreenCaps/droppedblock_prefab.png "DroppedBlock Prefab")

  6. Select the source `DroppedBlock` Game Object and hide it.

     ![Select DroppedBlock Game Object](./ScreenCaps/droppedblock_select.png "Select DroppedBlock Game Object")
     ![Hide DroppedBlock Game Object](./ScreenCaps/droppedblock_hide.png "Hide DroppedBlock Game Object")

  7. Go to Mono and edit the `MineBlock` script by adding this line

           public GameObject droppedBlockPrefab;

     before the Start function:

     ![Script Object for DroppedBlock Prefab](./ScreenCaps/droppedblockprefab_script_object.png "Script Object for DroppedBlock Prefab")

  8. Go back to Unity and select the `Block` prefab.

     ![Select the Block Prefab](./ScreenCaps/block_prefab_select2.png "Select the Block Prefab")

     Look at the `Inspector View` and see the `Dropped Block Prefab` field in the `Mine Block (Script)` component.

     ![DroppedBlockPrefab Field](./ScreenCaps/droppedblockprefab_field.png "DroppedBlockPrefab Field")

     That field was put there automatically by the Unity editor after we
     declared the `droppedBlockPrefab` variable in the `MineBlock` script.

     Now drag the `DroppedBlock` prefab into that `Dropped Block Prefab` field.

     ![Dragging DroppedBlockPrefab](./ScreenCaps/droppedblockprefab_dragging.png "Dragging DroppedBlockPrefab")

     ![DroppedBlockPrefab Dropped](./ScreenCaps/droppedblockprefab_dropped.png "DroppedBlockPrefab Dropped")

     This will cause the `droppedBlockPrefab` variable in the `MineBlock`
     script to be initialized to the `DroppedBlock` prefab when the game runs.
     It is in this way that our script will have access to that prefab.

  9. Finally, add this line

           Instantiate( droppedBlockPrefab, transform.position, droppedBlockPrefab.transform.rotation);

     to the `OnMouseDown` function of the `MineBlock` script right before the `Destroy` statement.

     ![](./ScreenCaps/droppedblockprefab_onmousedown_instantiate.png)

     This causes the `DroppedBlock` prefab to be &ldquo;instantiated&rdquo; as a game object
     at the same position as the block that was clicked and with the rotation
     that we specified in the `Inspector` for the `DroppedBlock` prefab.

  10. Go back to Unity and play the game. See that when you click a `Block` game object, a
      `DroppedBlock` game object appears in its place.

  11. Stop the game.

  12. Save the scene and the project.

## First Person Character

### Import Assets

  1. `Assets | Import Package | Characters`

     ![Import Package Characters](./ScreenCaps/assets_characters.png "Import Package Characters")

  2. Click the "None" button to uncheck all of the options.

     ![Click None to Deselect All](./ScreenCaps/assets_characters_none.png "Click None to Deselect All")

  3. Click the checkbox next to `FirstPersonCharacter`.

     ![Select FirstPersonCharacter](./ScreenCaps/assets_characters_fpc_select.png "Select FirstPersonCharacter")

     Now just the FirstPersonCharacter asset is selected.

     ![FirstPersonCharacter Selected](./ScreenCaps/assets_characters_fpc_selected.png "FirstPersonCharacter Selected")

  4. Click the `Import` button.

     ![Click Import](./ScreenCaps/assets_characters_fpc_import.png "Click Import")

     Notice the new `StandardAssets` folder inside your `Assets` folder of the `Project View`.

     ![New StandardAssets Folder](./ScreenCaps/standardassets_folder.png "New StandardAssets Folder")

     You will also notice an error message in the Unity status bar. If you click the `Console` tab
     next to the `Project` tab, you will see other messages, too.
     There are a couple of dependencies that we need to import before we can use the
     `FirstPersonCharacter` standard asset.

  5. `Assets | Import Package | CrossPlatformInput`

     ![Import Package CrossPlatformInput](./ScreenCaps/assets_crossplatforminput.png "Import Package CrossPlatformInput")

     ![Click Import](./ScreenCaps/assets_crossplatforminput_import.png "Click Import")

     And now there is a new folder named `Editor` inside the `Assets` folder of the `Project View`.

     ![New Editor Folder](./ScreenCaps/editor_folder.png "New Editor Folder")

  6. `Assets | Import Package | Utility`

     ![Import the Utility Package](./ScreenCaps/assets_utility.png "Import the Utility Package")

     ![Click the Import Button](./ScreenCaps/assets_utility_import.png "Click the Import Button")

     No additional new folders will appear at the top level of the `Assets`
     folder this time, but you'll see that the error messages have disappeared
     now.

### Add to the Scene and Configure the FirstPersonCharacter

  1. Under the `Assets` folder in the `Project View`, expand `StandardAssets`,
     `Characters`, `FirstPersonCharacter`, and then select `Prefabs`.

     ![FPSController Prefab](./ScreenCaps/fpscontroller_prefab.png "FPSController Prefab")

     Notice the `FPSController` prefab. That's what we are going to use.

  2. Drag the `FPSController` prefab into the scene.

     ![Drag the FPSController into the Scene](./ScreenCaps/fpscontroller_prefab_dropping.png "Drag the FPSController into the Scene")

     Drop it somewhere near the current camera.

     ![Dropthe FPSController into the Scene](./ScreenCaps/fpscontroller_prefab_dropped.png "Drop the FPSController into the Scene")

  3. Remove the old camera which is called `Main Camera`.

     ![Delete the Old Main Camera](./ScreenCaps/maincamera_delete.png "Delete the Old Main Camera")

     The `FPSController` prefab comes with its own camera built in.

  7. Adjust the `y` coordinate of the `FPSController` position so that it is
     completely above the plane, e.g., `y=2`.

     ![Select the FPSController Game Object](./ScreenCaps/fpscontroller_selected.png "Select the FPSController Game Object")
     ![Adjust Position of FPSController](./ScreenCaps/fpscontroller_position.png "Adjust Position of FPSController")

     It's okay if it starts higher than the plane. It will fall to the surface
     when the game begins.

  4. Save the scene and project.

     ![Save Scene](./ScreenCaps/scene_save_cropped.png "Save Scene")
     ![Save Project](./ScreenCaps/project_save_cropped.png "Save Project")

  5. Run the game.

     ![Run the Game](./ScreenCaps/game_running.png "Run the Game")

     Notice that the camera follows the cursor as expected for a first person
     character. Also, you can use the `W` `A` `S` `D` keys to make the player walk and the
     `SPACE` bar to make it jump.

  6. Stop the game.

     ![Stop the Game](./ScreenCaps/game_stopped.png "Stop the Game")

  8. Adjust the scale of the `FPSController` to `(0.5,0.9,0.5)`.
  
     ![FPSController Selected](./ScreenCaps/fpscontroller_selected.png "FPSController Selected")
     ![Adjust the Scale of the FPSController](./ScreenCaps/fpscontroller_scale.png "Adjust the Scale of the FPSController")

     This will make it possible for the character to fit through one block wide
     and two block high openings (eventually).

     ![](./ScreenCaps)

## Pickup Mechanic

## Sound effects

## Terrain

## Optional Stuff

### Add a Material to the Block Prefab

### Add a Material to the DroppedBlock Prefab

### Turn off shadows?

### Outline Blocks on Focus
