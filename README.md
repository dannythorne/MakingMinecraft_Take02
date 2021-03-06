# Making Minecraft

This tutorial shows a way to create the most basic game mechanics of Minecraft:
blocks that can be broken to drop items and a first person player who can pick up
the dropped items.

Developed with

  * `Unity Version 5.1.0f3 Personal`
  * `MonoDevelop-Unity Version 4.0.1`.
  * `OS X Yosimite Version 10.10.3 (14D136)`

Should work the same in Windows just with the usual OS interface differences.

<a name="toc"></a>
## Table of Contents (TOC)

  * [Preliminaries](#prelims)
  * [Basic Objects and Mechanics](#basics)
    * [Ground](#ground)
    * [Blocks](#blocks)
    * [Drops](#drops)
  * [First Person Character](#fps)
    * [Import Assets](#import)
    * [Add and Configure Character](#character)
    * [Lock the Mouse](#mouselock)
  * [Build the Game](#build)
  * [Pickup Mechanic](#pickup)
  * [Sound Effects](#soundeffects)
    * [Add Sound Assets](#addsoundassets)
    * [Sound Effect for Mining Blocks](#mineblocksound)
    * [Sound Effect for Picking Up Dropped Blocks](#pickupsound)
    * [Balancing the Volume of Sound Effects](#volume)
  * [Terrain](#terrain)
  * [Optional Stuff](#optional)
    * [Turn off shadows?](#shadows)
    * [Animate Dropped Blocks](#animatedrops)
    * [Add a Material to the Block Prefab](#blockmaterial)
    * [Add a Material to the DroppedBlock Prefab](#dropmaterial)
    * [Score Counter / Inventory](#pickupcounter)
    * [More Elaborate Mouse Lock Mechanism](#bettermouselock)
      * [Replace Cursor Pointer with Crosshairs](#crosshairs)
      * [Mechanism to Relock Cursor After Unlocking](#relock)
    * [Outline Blocks on Focus](#focus)
    * [Texture Map the Blocks](#texturemapping)

<a name="prelims"></a>
[Back to TOC](#toc)
## Preliminaries

Create a 3D project and select the default layout in the editor.

  1. Click to start a new project. (The following is what you should see when you start Unity.
     If, on the other hand, you already started Unity and have an existing project open,
     select `New Project...` under the `File` menu.)

     ![New Project](./ScreenCaps/project_new.png "New Project")

     Name the project.

     ![Name the Project](./ScreenCaps/project_name.png "Name the Project")

     3D should be highlighted.

     ![3D Project](./ScreenCaps/project_3d.png "3D Project")

     Click the create the project.

     ![Click to Create the Project](./ScreenCaps/project_create.png "Click to Create the Project")

  2. Select the default layout.

     ![Defaut Layout](./ScreenCaps/layout_default.png "Default Layout")

<a name="basics"></a>
[Back to TOC](#toc)
## Basic Objects and Mechanics

Here we build the ground, the block prefab, and the item drop prefab.

<a name="ground"></a>
[Back to TOC](#toc)
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

<a name="blocks"></a>
[Back to TOC](#toc)
### Blocks

We will now make a block that disappears when clicked on.

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
     lots of game objects just to make a simple change.  Another reason it is
     useful to make prefabs is because they can be &ldquo;instantiated&rdquo;
     from scripts dynamically at run time.  We will eventually want to do this
     in order to produce a procedurally generated terrain of blocks.

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

  9. Save the script in Mono.

     ![Save the Script](./ScreenCaps/script_mineblock_file_save.png "Save the Script")

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

     ![Select the Block Game Object](./ScreenCaps/block_gameobject_select.png "Select the Block Game Object")

  2. In the `Inspector View`, uncheck the checkbox next to the game object's name field.

     ![Uncheck Checkbox Next to Name Field](./ScreenCaps/block_gameobject_hide.png "Uncheck Checkbox Next to Name Field")

     That game object should no longer appear in the scene. It is still listed in the
     `Hierarchy View` although dimmed.

<a name="drops"></a>
[Back to TOC](#toc)
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

     ![Instantiate On Mouse Down](./ScreenCaps/droppedblockprefab_onmousedown_instantiate.png "Instantiate On Mouse Down")

     This causes the `DroppedBlock` prefab to be &ldquo;instantiated&rdquo; as a game object
     at the same position as the block that was clicked and with the rotation
     that we specified in the `Inspector` for the `DroppedBlock` prefab.

  9. Save the script.

     ![Save the Script](./ScreenCaps/script_mineblock_file_save.png "Save the Script")

  9. Go back to Unity and save the scene and project.

     ![Save Scene](./ScreenCaps/scene_save_cropped.png "Save Scene")
     ![Save Project](./ScreenCaps/project_save_cropped.png "Save Project")

  9. Play the game.

     ![Run the Game](./ScreenCaps/game_running.png "Run the Game")
  
      See that when you click a `Block` game object, a
      `DroppedBlock` game object appears in its place.

  9. Stop the game.

     ![Stop the Game](./ScreenCaps/game_stopped.png "Stop the Game")

<a name="fps"></a>
[Back to TOC](#toc)
## First Person Character

This section adds a first person character to the scene so that the player can
look around and move around in a way similar to Minecraft.

Beware: *The first person character asset is provided by Unity in the
`Standard Assets` package, so `Standard Assets` must be installed. If they are
not, the `Import Package` menu in the very first step below will not contain
the shown options. In that case, go to the `Asset Store`:*

![Asset Store Under Window Menu](./ScreenCaps/asset_store.png "Asset Store Under Window Menu")

*and download/import `Standard Assets` from there instead.*

<a name="import"></a>
[Back to TOC](#toc)
### Import Assets

  1. `Assets | Import Package | Characters`

     ![Import Package Characters](./ScreenCaps/assets_characters.png "Import Package Characters")

     If you do not see the shown options in your `Import Package` menu, see the note above. You will
     need to install/import them from the `Asset Store`.

  2. Click the "None" button to uncheck all of the options.

     ![Click None to Deselect All](./ScreenCaps/assets_characters_none.png "Click None to Deselect All")

  3. Click the checkbox next to `FirstPersonCharacter`.

     ![Select FirstPersonCharacter](./ScreenCaps/assets_characters_fpc_select.png "Select FirstPersonCharacter")

     Now just the `FirstPersonCharacter` asset is selected.

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

<a name="character"></a>
[Back to TOC](#toc)
### Add and Configure Character

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

  4. Save.

     ![Save Scene](./ScreenCaps/scene_save_cropped.png "Save Scene")
     ![Save Project](./ScreenCaps/project_save_cropped.png "Save Project")

<a name="mouselock"></a>
[Back to TOC](#toc)
### Lock the Mouse

The way the player interacts with the scene will be more natural if the cursor is always in the center of the
screen (like the crosshairs of Minecraft).

  1. Select the `Assets` folder in the `Project View` and create a new `C# Script`.

     ![Create MouseLock Script](./ScreenCaps/script_mouselock_create.png "Create MouseLock Script")

  2. Rename the new script to `MouseLock`.

     ![New Script](./ScreenCaps/script_mouselock_new.png "New Script")
     ![Renaming Script](./ScreenCaps/script_mouselock_renaming.png "Renaming Script")
     ![Script Renamed](./ScreenCaps/script_mouselock_renamed.png "Script Renamed")

  3. Select the FPSController game object.

     ![Select FPSController Game Object](./ScreenCaps/fpscontroller_selected2.png "Select FPSController Game Object")

  4. Scroll down in the `Inspector View` until the `Add Component` button is
     visible.

     ![Button for Add Component](./ScreenCaps/addcomponent_button.png "Button for Add Component")

  5. Drag the `MouseLock` asset onto the `Add Component` button of the
     `Inspector` for the `FPSController`.

     ![Add MouseLock Script as Component of FPSController](./ScreenCaps/mouselock_adding.png "Add MouseLock Script as Component of FPSController")

     Now the `Mouse Lock (Script)` component should appear in the list of
     components for the `FPSController`.

     ![MouseLock Script Added](./ScreenCaps/mouselock_added.png "MouseLock Script Added")

  6. Double-click the `MouseLock` C# asset in the `Project View` to open it in Mono.

     ![Initial MouseLock Script](./ScreenCaps/mouselock_initial.png "Initial MouseLock Script")

     Notice that Mono now has two tabs, one for the `Mineblock` script that we
     edited previously (and will return to later) and one for the new `MouseLock`
     script that we will edit now.

  7. To lock the mouse cursor when the game begins, put this line

           Cursor.lockState = CursorLockMode.Locked;

     in the `Start` function.

     ![Cursor Lock in Start Function](./ScreenCaps/mouselock_start01.png "Cursor Lock in Start Function")

  8. To unlock the mouse cursor when the user presses the `ESC` key, put these
     lines

          if( Input.GetKeyDown("escape"))
          {
            Cursor.lockState = CursorLockMode.None;
          }

     in the `Update` function.

     ![Capture ESC in Update Function](./ScreenCaps/mouselock_update01.png "Capture ESC in Update Function")

  9. Save the script.

     ![Save the Script](./ScreenCaps/script_mineblock_file_save.png "Save the Script")

  9. Go back to Unity and save the scene and the project.

     ![Save Scene](./ScreenCaps/scene_save_cropped.png "Save Scene")
     ![Save Project](./ScreenCaps/project_save_cropped.png "Save Project")

  9. Run the game.

     ![Run the Game](./ScreenCaps/game_running.png "Run the Game")
  
     If you're lucky, the mouse cursor will lock in the middle of the `Game
     View` until you hit the `ESC` key.

     ![Cursor Centered in Game View](./ScreenCaps/mouselock_cursor_centered.png "Cursor Centered in Game View")

     The mouse lock mechanism can be a bit flakey in the `Game View`. Sometimes
     it doesn't work right. To see it work reliably, we might need to build the
     game as a native application.

  9. Stop the game.

     ![Stop the Game](./ScreenCaps/game_stopped.png "Stop the Game")

     In my experience, if the cursor lock doesn't work the first time the game is run, stopping it and
     then running it again will make it work, so try running it again at this point. (And then stop it
     before proceeding.)
     

<a name="build"></a>
[Back to TOC](#toc)
## Build the Game

  1. `File | Build Settings...`

     ![File | Build Settings...](./ScreenCaps/buildsettings_select.png "File | Build Settings...")

     From the `File` menu, select `Build Settings...`.

  2. `PC, Mac & Linux Standalone`.

     ![Platform](./ScreenCaps/buildsettings_standalone.png "Platform")

     From the `Platform` list, select `PC, Mac & Linux Standalone`.

  3. `Target Platform`

     ![Targer Platform](./ScreenCaps/buildsettings_targetplatform.png "Targer Platform")

     Select your operating system from the `Target Platform` menu.

  4. Click the `Build And Run` button.

     ![Click Build And Run](./ScreenCaps/buildsettings_buildandrun.png "Click Build And Run")

  5. Name the application something like `MakingMinecraft`.

     ![Name the Application](./ScreenCaps/buildsettings_appname.png "Name the Application")

  6. Click `Save`.

     ![Save the Application](./ScreenCaps/application_save.png "Save the Application")

  7. Select your desired resolution from the `Configuration` dialog that pops up.

     ![Choose Resolution](./ScreenCaps/buildsettings_configuration_resolution.png "Choose Resolution")

  8. Check the `Windowed` check box.

     ![Check Windowed](./ScreenCaps/buildsettings_configuration_windowed.png "Check Windowed")

     This will make the application run inside a window rather than in full screen.
     (Optionally, you can leave that checkbox unchecked to run in full screen mode, but it might be
     tricky to escape out of the game when it is running that way.)

  9. `Play!`

     ![Play!](./ScreenCaps/buildsettings_configuration_play.png "Play!")

     Click the `Play!` button and enjoy playing the game as a native
     application.

     ![Application Running](./ScreenCaps/application_running01.png "Application Running")

     When finished playing, press `ESC` to unlock the cursor and then close the
     application.

  9. Back in Unity, close the `Build Settings` window.

     ![Close Build Settings](./ScreenCaps/buildsettings_close.png "Close Build Settings")

<a name="pickup"></a>
[Back to TOC](#toc)
## Pickup Mechanic

When the player runs into a dropped block, the dropped block game object should disappear
as the player &ldquo;picks up&rdquo; the item.

  1. Select the `DroppedBlock` prefab in the `Assets` folder of the `Project View`.

     ![Select the DroppedBlock Prefab](./ScreenCaps/droppedblockprefab_select.png "Select the DroppedBlock Prefab")

  2. In the `Inspector View`, check the `Is Trigger` check box of the `Box Collider` component.

     ![Check the Is Trigger Check Box](./ScreenCaps/droppedblockprefab_boxcollider_istrigger.png "Check the Is Trigger Check Box")


  3. In the `Assets` folder, create a new C# Script.

     ![Create New C# Script Asset](./ScreenCaps/script_pickup_create.png "Create New C# Script Asset")

  4. Rename it to `PickUp`.

     ![New Script](./ScreenCaps/script_pickup_new.png "New Script")
     ![Renaming](./ScreenCaps/script_pickup_renaming.png "Renaming")
     ![Renamed](./ScreenCaps/script_pickup_renamed.png "Renamed")

  5. Select the `DroppedBlock` prefab again.

     ![Select the DroppedBlock Prefab](./ScreenCaps/droppedblockprefab_select2.png "Select the DroppedBlock Prefab")

  6. Drag the `PickUp` script over to the `Add Component` button in the `Inspector` for the `DroppedBlock` prefab.

     ![Adding PickUp Script Component to DroppedBlock Prefab](./ScreenCaps/droppedblockprefab_addcomponent.png "Adding PickUp Script Component to DroppedBlock Prefab")

     Then the `Pick Up (Script)` component should appear in the list of
     components in the `Inspector` for the `DroppedBlock` prefab.

     ![PickUp Script Added](./ScreenCaps/droppedblockprefab_component_added.png "PickUp Script Added")

  9. Save the scene and project.

     ![Save Scene](./ScreenCaps/scene_save_cropped.png "Save Scene")
     ![Save Project](./ScreenCaps/project_save_cropped.png "Save Project")

  7. Double-click the `PickUp` script to open it in Mono.

     ![Double Click the Pickup Script](./ScreenCaps/script_pickup_doubleclick.png "Double Click the Pickup Script")

     Now you will see three tabs in Mono with the one for the `PickUp` script in front.

     ![Initial PickUp Script](./ScreenCaps/script_pickup_initial.png "Initial PickUp Script")

  8. Add the following `OnTriggerEnter` function

           void OnTriggerEnter()
           {
               Destroy( gameObject);
           }

     after the `Update` function like this:

     ![OnTriggerEnter Function in PickUp Class](./ScreenCaps/script_pickup_ontriggerenter.png "OnTriggerEnter Function in PickUp Class")

  9. Save the script.

     ![Save the Script](./ScreenCaps/script_mineblock_file_save.png "Save the Script")

  9. Back in Unity, run the game.

     ![Run the Game](./ScreenCaps/game_running.png "Run the Game")

     Click on a block to make it drop a dropped block item and then run your
     character into the dropped block.  It should disappear.

  9. Stop the game.

     ![Stop the Game](./ScreenCaps/game_stopped.png "Stop the Game")

<a name="soundeffects"></a>
[Back to TOC](#toc)
## Sound Effects

Breaking blocks and collecting dropped items is much more satisfying with sound effects!

<a name="addsoundassets"></a>
[Back to TOC](#toc)
### Add Sound Assets.

  1. Download the following two `wav` files:

     [dig\_grass1.wav](http://dannythorne.github.io/MakingMinecraft_Take02/Assets/dig_grass1.wav)

     [pop.wav](http://dannythorne.github.io/MakingMinecraft_Take02/Assets/pop.wav)

     ![Save Link As](./ScreenCaps/wav_savelinkas.png "Save Link As")

     Save them in the `Assets` folder.

     ![Save in Assets Folder](./ScreenCaps/wav_saveinassets.png "Save in Assets Folder")

     Do that with both files: `dig_grass1.wav` and `pop.wav` .
     Then you will see both of those files in the `Assets` folder on your harddrive.

     ![Assets Folder Listing](./ScreenCaps/assets_folder_listing.png "Assets Folder Listing")

     They will also appear in the `Assets` folder inside the Unity editor.

     ![Assets Folder in Unity](./ScreenCaps/assets_folder_in_unity.png "Assets Folder in Unity")

<a name="mineblocksound"></a>
[Back to TOC](#toc)
### Sound Effect for Mining Blocks

  1. In the `MineBlock` script in Mono, add this line

           public AudioClip mineSound;

     at the top of the `MineBlock` class:

     ![MineSound Variable in MineBlock Class](./ScreenCaps/script_mineblock_minesound_variable.png "MineSound Variable in MineBlock Class")

  2. Save the `MineBlock` script in Mono.

     ![Save the MineBlock Script](./ScreenCaps/script_mineblock_file_save.png)

  3. Go back to Unity. Select the Block prefab from the `Assets` folder and
     notice the `Mine Sound` field in the `Mine Block (Script)` component
     in the `Inspector`.

     ![Mine Sound Field in Mine Block Script Component](./ScreenCaps/script_mineblock_component_with_minesound_field.png "Mine Sound Field in Mine Block Script Component")

  4. Drag the `dig_grass1` asset into that field.

     ![Adding dig_grass1 Asset to Mine Sound Field](./ScreenCaps/dig_grass_sound_dragging.png "Adding Dig Grass Sound to Mine Sound Field")
     ![dig_grass1 Asset Added to Mine Sound Field](./ScreenCaps/dig_grass_sound_dropped.png)

  5. Go back to Mono and add this line

           AudioSource.PlayClipAtPoint( mineSound, transform.position);

     inside the `OnMouseDown` function before the `Destroy` statement.

     ![PlayClip](./ScreenCaps/script_mineblock_onmousedown_playclip.png "PlayClip")

  6. Save.

     ![Save the MineBlock Script](./ScreenCaps/script_mineblock_file_save.png "Save the MineBlock Script")

  9. Go back to Unity and save the scene and project.

     ![Save Scene](./ScreenCaps/scene_save_cropped.png "Save Scene")
     ![Save Project](./ScreenCaps/project_save_cropped.png "Save Project")

  7. Play the game.

     ![Run the Game](./ScreenCaps/game_running.png "Run the Game")

     If you have audio on your computer, you should now hear the familiar sound
     of a dirt block breaking when you click on a block.

  8. Stop the game.

     ![Stop the Game](./ScreenCaps/game_stopped.png "Stop the Game")

<a name="pickupsound"></a>
[Back to TOC](#toc)
### Sound Effect for Picking Up Dropped Blocks

Challenge: *As an exercise, see if you can now add the sound effect for picking up dropped
blocks without looking at the following instructions.*

  1. In the `PickUp` script in Mono, add this line

           public AudioClip pickupSound;

     at the top of the `PickUp` class:

     ![PickUp Sound Varialbe in PickUp Class](./ScreenCaps/script_pickup_pickupsound_variable.png "PickUp Sound Varialbe in PickUp Class")

  2. Save.

     ![Save the PickUp Script](./ScreenCaps/script_mineblock_file_save.png "Save the PickUp Script")

  3. Back in Unity, select the `DroppedBlock` prefab and see the `Pickup Sound`
     field in the `PickUp (Script)` component in the `Inspector`.

     ![PickUp Sound Field in Script Component](./ScreenCaps/script_pickup_component_with_pickupsound_field.png "PickUp Sound Field in Script Component")

  4. Drag the `pop` asset into that field.

     ![Adding Pop Asset to PickUp Sound Field](./ScreenCaps/pop_sound_dragging.png "Adding Pop Asset to PickUp Sound Field")
     ![Pop Asset Added to PickUp Sound Field](./ScreenCaps/pop_sound_dropped.png "Pop Asset Added to PickUp Sound Field")

  5. Go back to Mono and add this line

           AudioSource.PlayClipAtPoint( pickupSound, transform.position);

     in the `OnTriggerEnter` function before the `Destroy` statement:

     ![PlayClip](./ScreenCaps/script_pickup_ontriggerenter_playclip.png "PlayClip")

  6. Save.

     ![Save PickUp Script](./ScreenCaps/script_mineblock_file_save.png "Save PickUp Script")

  9. Go back to Unity and save the scene and project.

     ![Save Scene](./ScreenCaps/scene_save_cropped.png "Save Scene")
     ![Save Project](./ScreenCaps/project_save_cropped.png "Save Project")

  7. Play the game.

     ![Run the Game](./ScreenCaps/game_running.png "Run the Game")

     After breaking a block to make it drop a dropped block, when
     you run your character into the dropped block you should
     hear the popping sound of the item being collected.

  8. Stop the game.

     ![Stop the Game](./ScreenCaps/game_stopped.png "Stop the Game")

<a name="volume"></a>
[Back to TOC](#toc)
### Balance the Volume of Sound Effects

The walking/stepping sound effects that come as part of the `FPSController` may
be too loud relative to the sound effects for breaking and picking up blocks.
Let's turn the `FPSController` sound effects down a little.

  1. Select the `FPSController` game object in the `Heirarchy View`.

     ![Select FPSController Game Object](./ScreenCaps/fpscontroller_selected3.png "Select FPSController Game Object")

  2. In the `Inspector View`, adjust the `Volume` slider in the `Audio Source` componenent.

     ![Adjust Volume](./ScreenCaps/fpscontroller_audiosource_volume.png "Adjust Volume")

     About half volume feels right to me, but adjust to suit yourself.

  3. Save the scene and project.

     ![Save Scene](./ScreenCaps/scene_save_cropped.png "Save Scene")
     ![Save Project](./ScreenCaps/project_save_cropped.png "Save Project")

  4. Play the game.

     ![Run the Game](./ScreenCaps/game_running.png "Run the Game")

  5. Stop the game.

     ![Stop the Game](./ScreenCaps/game_stopped.png "Stop the Game")

  6. If unsatisfied with the volume balance, go back to step 2, otherwise continue
     to the next section.

<a name="terrain"></a>
[Back to TOC](#toc)
## Terrain

Now that the basic breaking and collecting mechanics are in place, let's
generate an actual terrain rather than a scattering of hand-placed blocks.

  1. Create a new C# Script called `GenTerrain`.

     ![Create GenTerrain C# Script](./ScreenCaps/script_genterrain_new.png "Create GenTerrain C# Script")

  2. Select the `Plane` game object.

     ![Select Plane Game Object](./ScreenCaps/plane_select2.png "Select Plane Game Object")

  3. Add the `GenTerrain` script as a componenet on the `Plane` game object.

     ![Adding GenTerrain Script to Plane](./ScreenCaps/script_genterrain_adding.png "Adding GenTerrain Script to Plane")
     ![GenTerrain Script Added to Plane](./ScreenCaps/script_genterrain_added.png "GenTerrain Script Added to Plane")

  4. Double click the `GenTerrain` script to open it in Mono.

     ![Open the GenTerrain Script](./ScreenCaps/script_genterrain_initial.png "Open the GenTerrain Script")

  5. Add this line

           public GameObject block;

     at the top of the `GenTerrain` class just before the `Start` function.

     ![Add Block Variable to GenTerrain Class](./ScreenCaps/script_genterrain_block_variable.png "Add Block Variable to GenTerrain Class")

  6. Save.

     ![Save the GenTerrain Script](./ScreenCaps/script_mineblock_file_save.png "Save the GenTerrain Script")

  7. Go back to Unity and see the `Block` field in the `GenTerrain` component
     in the `Inspector` for the `Plane` game object.

     ![GenTerrain Block Field](./ScreenCaps/script_genterrain_block_field.png "GenTerrain Block Field")

  8. Drag the `Block` prefab into that field.

     ![Adding Block Prefab to Block Field](./ScreenCaps/script_genterrain_block_adding.png "Adding Block Prefab to Block Field")
     ![Block Prefab Added to Block Field](./ScreenCaps/script_genterrain_block_added.png "Block Prefab Added to Block Field")

  9. Back in Mono, add these lines

           int i, j, k;
           int nk;

           int n = 32;
           int h = 8;

           for( j=-n; j<=n; j++)
           {
               for( i=-n; i<=n; i++)
               {
                   nk = (int)( Mathf.Floor( h*( 1 + Mathf.Sin( 2*Mathf.PI*i/n) * Mathf.Sin( 2*Mathf.PI*j/n) )));
                   for( k=0; k<nk; k++)
                   {
                       Instantiate( block, new Vector3( i, k, j), Quaternion.identity);
                   }
               }
           }
  
     to the `Start` function in the `GenTerrain` class:

     ![GenTerrain Start Function Code](./ScreenCaps/script_genterrain_start_function.png "GenTerrain Start Function Code")

  9. Save.

     ![Save the Script](./ScreenCaps/script_mineblock_file_save.png "Save the Script")

  9. Back in Unity, select the `FPSController` game object

     ![Select FPSController](./ScreenCaps/fps_controller_selected4.png "Select FPSController")

     and adjust its `Position`

     ![Adjust FPSController Position](./ScreenCaps/fps_controller_position2.png "Adjust FPSController Position")

     so that the player starts in the middle of the world and up high.

  9. Delete the manually placed blocks.

     ![Deleting Manually Placed Blocks](./ScreenCaps/block_clones_deleting.png "Deleting Manually Placed Blocks")
     ![Manually Placed Blocks Deleted](./ScreenCaps/block_clones_deleted.png "Manually Placed Blocks Deleted")

  9. Save the scene and project.

     ![Save Scene](./ScreenCaps/scene_save_cropped.png "Save Scene")
     ![Save Project](./ScreenCaps/project_save_cropped.png "Save Project")

  9. Play the game.

     ![Run the Game](./ScreenCaps/game_running.png "Run the Game")

  9. Stop the game.

     ![Stop the Game](./ScreenCaps/game_stopped.png "Stop the Game")


<a name="optional"></a>
[Back to TOC](#toc)
## Optional Stuff

The following list of tasks can be done in any order and independently of the
others. They are listed roughly in order of how much time they should probably
take.

<a name="shadows"></a>
[Back to TOC](#toc)
### Turn Off Shadows

  1. If you wish, you may turn off shadows for the `Block` and/or `DroppedBlock` prefabs.

     ![](./ScreenCaps/shadows.png)

     In the `Mesh Renderer` component, you can toggle both whether the object casts
     shadows and whether the object receives shadows.

<a name="animatedrops"></a>
[Back to TOC](#toc)
### Animate Dropped Blocks

  1. Put this line

           transform.RotateAround( transform.position, Vector3.up, 100*Time.deltaTime);

     in the `Update` function of the `PickUp` class:

     ![](./ScreenCaps/script_pickup_rotate.png)

     The first argument `transform.position` specifies the center of the rotation.
     The second argument `Vector3.up` specifies the axis of rotation.
     The third argument, a multiple of `Time.deltaTime` specifies the speed of the rotation.
     Adjust that multiple `100` to suit.

<a name="blockmaterial"></a>
[Back to TOC](#toc)
### Add a Material to the Block Prefab

  1. Right click in the `Assets` folder and select to `Create` a `Material` asset.

     ![Create a Material](./ScreenCaps/blockmaterial_create.png "Create a Material")

     It will be named `New Material` by default.

     ![New Material](./ScreenCaps/blockmaterial_created.png "New Material")

     Rename it to `BlockMaterial`.

     ![Renamed to BlockMaterial](./ScreenCaps/blockmaterial_renamed.png "Renamed to BlockMaterial")

  1. Click the white color box toward the top of the `Inspector` for the `BlockMaterial`.

     ![Color Select Box](./ScreenCaps/blockmaterial_color_select.png "Color Select Box")

  1. Choose a color.

     ![Choose a Color](./ScreenCaps/blockmaterial_color_selected.png "Choose a Color")

  1. Close the `Color` selector.

     ![Close the Color Selector](./ScreenCaps/blockmaterial_color_selector_close.png "Close the Color Selector")

  1. Select the `Block` prefab in the `Assets` folder.

     ![Select the Block Prefab](./ScreenCaps/block_select.png "Select the Block Prefab")

  1. Click the little triangle to expand the `Materials` property of the `Mesh Renderer` component.

     ![Expand Mesh Renderer Materials](./ScreenCaps/block_meshrenderer_materials_expand.png "Expand Mesh Renderer Materials")

     See the `Element 0` field.

     ![See the Element 0 Field](./ScreenCaps/block_material_field.png "See the Element 0 Field")

  1. Drag the `BlockMaterial` asset into that field

     ![Dropping the BlockMaterial Asset into the Element 0 Field](./ScreenCaps/blockmaterial_dropping.png "Dropping the BlockMaterial Asset into the Element 0 Field")
     ![BlockMaterial Dropped in the Element 0 Field](./ScreenCaps/blockmaterial_dropped.png "BlockMaterial Dropped in the Element 0 Field")

  9. Save the scene and project.

     ![Save Scene](./ScreenCaps/scene_save_cropped.png "Save Scene")
     ![Save Project](./ScreenCaps/project_save_cropped.png "Save Project")

  9. Play the game.

     ![Run the Game](./ScreenCaps/game_running.png "Run the Game")

     The blocks should now appear in whatever color you selected for the material.

  9. Stop the game.

     ![Stop the Game](./ScreenCaps/game_stopped.png "Stop the Game")

<a name="dropmaterial"></a>
[Back to TOC](#toc)
### Add a Material to the DroppedBlock Prefab

**Exercise:** *Complete this task on your own. Make the game play the `pop.wav` sound when the player picks up a dropped block.*

<a name="pickupcounter"></a>
[Back to TOC](#toc)
### Score Counter / Inventory

  1. `Create | UI | Text`

     ![Create a UI Text Object](./ScreenCaps/ui_text_create.png "Create a UI Text Object")

     Create a `UI` `Text` game object in the `Hiearchy View`.
     It will appear as a child of a `Canvas` object which get automatically
     created for this purpose.

     ![Select the UI Text Object](./ScreenCaps/ui_text_selected.png "Select the UI Text Object")

     There is also an `EventSystem` game object that is created automatically
     at this point which we will ignore for now.

  2. Set an `Anchor Preset`.

     ![Select the Anchor Preset menu](./ScreenCaps/ui_text_anchor_presets_select.png)

     Select the `Anchor Preset` menu in the `Inspector` for the `Text` game object.

     ![Anchor Preset Menu](./ScreenCaps/ui_text_anchor_presets.png)

     Hold down the `Alt` key. See how the annotations change to signify
     position.

     ![Anchor Preset Menu with Alk Key Down](./ScreenCaps/ui_text_anchor_presets_alt.png "Anchor Preset Menu with Alk Key Down")

     Select a desired position. I propose the bottom middle since that is where
     the Minecraft hotbar is displayed.

     ![Anchor Preset Selected](./ScreenCaps/ui_text_anchor_presets_alt_selected.png)

  3. Change the contents of the `Text` field from `New Text` to `0`.

     ![Changing The Default Text](./ScreenCaps/ui_text_changing.png "Changing The Default Text")

     ![Default Text Changed](./ScreenCaps/ui_text_changed.png "Default Text Changed")
     
  4. Increase the font size a bit:

     ![Increase Font Size](./ScreenCaps/ui_text_font_size_24.png)

  5. Center the text by clicking the center `Alignment` button in the `Paragraph` section.

     ![Center the Text](./ScreenCaps/ui_text_center.png "Center the Text")

  6. Go to Mono and select the `PickUp` script tab.

     ![Select Pickup Script Tab](./ScreenCaps/script_pickup_select_tab.png "Select Pickup Script Tab")

  7. Add this `using` directive

           using UnityEngine.UI;

     at the top of the file:

     ![Using UnityEngine.UI](./ScreenCaps/script_pickup_using_ui.png "Using UnityEngine.UI")

     This will allow us to access the `Text` component of the `Text` game object.

  8. Add this private static variable declaration

           private static int numCollected = 0;

     and this private variable declaration

           private Text numCollectedText;

     at the beginning of the `PickUp` class:

     ![Num Collected Vars in PickUp Script](./ScreenCaps/script_pickup_numcollected_vars.png "Num Collected Vars in PickUp Script")

  9. Put this line

           numCollectedText = GameObject.Find("Text").GetComponent<Text>();

     in the Start function:

     ![Code to Find Text Object](./ScreenCaps/script_pickup_find_text_object.png "Code to Find Text Object")

  9. Finally, put these lines

           numCollected++;
           numCollectedText.text = numCollected.ToString();

     in the `OnTriggerEnter` function:

     ![Lines to Update Num Collected](./ScreenCaps/script_pickup_numcollected_update.png "Lines to Update Num Collected")

  9. Save.

     ![Save the Script](./ScreenCaps/script_mineblock_file_save.png "Save the Script")

  9. Go back to Unity and save the scene and project.

     ![Save Scene](./ScreenCaps/scene_save_cropped.png "Save Scene")
     ![Save Project](./ScreenCaps/project_save_cropped.png "Save Project")

  9. Play the game.

     ![Run the Game](./ScreenCaps/game_running.png "Run the Game")

     See the counter increment whenever you pick up a dropped block.

  9. Stop the game.

     ![Stop the Game](./ScreenCaps/game_stopped.png "Stop the Game")



<a name="bettermouselock"></a>
[Back to TOC](#toc)
### More Elaborate Mouse Lock Mechanism

We will replace the cursor pointer with crosshairs and allow for relocking after unlocking.

<a name="crosshairs"></a>
[Back to TOC](#toc)
#### Replace Cursor Pointer with Crosshairs

This task involves first making an image of crosshairs.
The following instructions are for [GIMP](http://www.gimp.org/),
the GNU Image Manipulation Program, which is
a free image editing application similar in functionality to Photoshop.
Feel free to produce the image in whatever image editing application you prefer
or even just find an image of crosshairs online.
(The image file format can be `PNG` or `JPG`. Maybe it can be other formats,
too, but I'm not sure.)

  1. Run GIMP and create a new image.

     ![New GIMP Image](./ScreenCaps/gimp_new.png "New GIMP Image")

     Adjust the size to something fairly small and probably square is best.
     For the tutorial, we'll do a 16&times;16 image.

     ![Size the New Image](./ScreenCaps/gimp_new_image_size.png "Size the New Image")

     Click `Okay` to create the new image.

     ![Click Okay](./ScreenCaps/gimp_new_okay.png "Click Okay")

     In the zoom dropdown menu select 800%.

     ![Zoom](./ScreenCaps/gimp_zoom.png "Zoom")

     That way we can edit the image pixels easily.

     ![Zoomed](./ScreenCaps/gimp_zoomed.png "Zoomed")

  2. Select the `Pencil Tool` from the `Toolbox` window.

     ![Select Pencil Tool](./ScreenCaps/gimp_pencil.png "Select Pencil Tool")

     Make sure that under `Tool Options` the `Mode` is `Normal` and the `Brush` is `1. Pixel`
     and the `Size` is `1.00`.

  3. Draw horizontal and vertical lines for crosshairs.

     ![Draw Lines](./ScreenCaps/gimp_crosshairs.png "Draw Lines")

     Maybe decorate them a bit.

     ![Decorate](./ScreenCaps/gimp_crosshairs_decorated.png "Decorate")

     Feel free to draw your crosshairs however you like. They don't have to look the same as this.

  4. Make the white background of the crosshairs transparent.

     ![Make Background Transparent](./ScreenCaps/gimp_color_to_alpha_select.png "Make Background Transparent")

     Select `Color To Alpha...` from the `Colors` menu.

     ![Click Okay](./ScreenCaps/gimp_color_to_alpha_okay.png "Click Okay")

     It should default to white as the color to convert to `Alpha`, i.e., make transparent,
     so just click `Okay`.

     ![Transparent](./ScreenCaps/gimp_alpha.png "Transparent")

  4. Export the image to a `PNG` file.

     ![Export](./ScreenCaps/gimp_export.png "Export")

     Expand the `Select File Type` menu.

     ![Expand File Type Menu](./ScreenCaps/gimp_file_type_expand.png "Expand File Type Menu")

     Expanded, it will show a list of file types to select from:

     ![Expanded](./ScreenCaps/gimp_file_type_expanded.png "Expanded")

     Select `PNG image`.

     ![Select PNG](./ScreenCaps/gimp_select_png.png "Select PNG")

     Now name the file `crosshairs.png.bytes`.

     ![Name the File](./ScreenCaps/gimp_export_name.png "Name the File")

     Select the `Assets` folder of your project to save it in and then click the `Export` button.

     A `PNG` file with a `.bytes` extension on the file name is very unusual!
     Unity wants it that way, but GIMP is skeptical.
     You will need to confirm that you do want to go with that unusual name.

     ![Confirm Name](./ScreenCaps/gimp_confirm_name.png "Confirm Name")

     You will be presented with another dialog window containing various options.

     ![Export Options](./ScreenCaps/gimp_export_details.png "Export Options")

     Just click the `Export` button to accept the defaults.

  5. Go to Unity and notice the new `crosshairs.png` asset in the `Assets` folder.

     ![New Crosshairs Asset](./ScreenCaps/crosshairs_new.png "New Crosshairs Asset")

  6. Go to the `MouseLock` script in Mono and add these lines

           public TextAsset crossHairsRaw;
           private Texture2D crossHairs;

     at the top of the `MouseLock` class:

     ![MouseLock Texture Variables](./ScreenCaps/script_mouselock_texture_variables.png "Mouselock Texture Variables")

  7. Put these lines

           crossHairs = new Texture2D(16,16);
           crossHairs.LoadImage(crossHairsRaw.bytes);
           Cursor.SetCursor( crossHairs, new Vector2(8,8), CursorMode.Auto);

     in the `Start` function of the `MouseLock` class after the line that sets the cursor lock state:

     ![MouseLock Load Image](./ScreenCaps/script_mouselock_load_image.png "MouseLock Load Image")

     If you created a crosshairs image that is bigger than 16&times;16, you'll need to adjust the numbers
     for the size of the `Texture2D` object and the `Vector2` argument in the `SetCursor` function call.
     The `Vector2` object specifies which point inside the image should be used as the cursor point.
     For a crosshairs shaped cursor it makes sense for it to be in the middle of the cursor image.

  8. Put this line

           Cursor.SetCursor( null, Vector2.zero, CursorMode.Auto);

     inside the `if` statement of the `Update` function after the line that
     unlocks the cursor:

     ![MouseLock Reset Cursor](./ScreenCaps/script_mouselock_reset_cursor.png "MouseLock Reset Cursor")

     That sets the cursor back to the default.
     `Vector2.zero` means coordinates `(0,0)` which are at the top left corner of the cursor image
     which corresponds to the tip of the point of the default cursor.

  9. Save.

     ![Save the Script](./ScreenCaps/script_mineblock_file_save.png "Save the Script")

  9. Now go back to Unity and select the `FPSController` in the `Hierarchy View`.

     ![Select FPSController](./ScreenCaps/fps_controller_selected5.png "Select FPSController")

     Scroll down in the `Inspector View` for the `FPSController` and notice the `Cross Hairs Raw` field in the
     `Mouse Lock (Script)` component.

  9. Drag the `crosshairs.png` asset into that `Cross Hairs Raw` field of the `Mouse Lock (Script)` component.

     ![Adding Crosshairs to Script Field](./ScreenCaps/crosshairs_adding.png "Adding Crosshairs to Script Field")
     ![Crosshairs Added](./ScreenCaps/crosshairs_added.png "Crosshairs Added")


  9. Save the scene and project.

     ![Save Scene](./ScreenCaps/scene_save_cropped.png "Save Scene")
     ![Save Project](./ScreenCaps/project_save_cropped.png "Save Project")

  9. Play the game.

     ![Run the Game](./ScreenCaps/game_running.png "Run the Game")

     The cursor should change to the crosshairs shape.

  9. Stop the game.

     ![Stop the Game](./ScreenCaps/game_stopped.png "Stop the Game")

     You might have to stop and restart the game in order to get it to work. Also, when running the game inside
     the unity editor, the cursor many not change back from the crosshairs cursor when you press `ESC`, or at
     least not until you move the cursor outside of the `Game View`.

<a name="relock"></a>
[Back to TOC](#toc)
#### Mechanism to Relock Cursor After Unlocking

  1. Mouse click to lock cursor. Add `else if` clause

           else if( Input.GetMouseButtonDown(0))
           {
             Cursor.lockState = CursorLockMode.Locked;
             Cursor.SetCursor( crossHairs, new Vector2(8,8), CursorMode.Auto);
           }

     after `if` statement in the `Update` function:

     ![](./ScreenCaps/script_mouselock_relock.png)

     As usual, this might not work flawlessly when running the game in the Unity editor.
     Try doing a `File | Build & Run`.

<a name="focus"></a>
[Back to TOC](#toc)
### Outline Blocks on Focus

We will use the Unity GL graphics library.

  1. Create a new C# script.

     ![Create Script](./ScreenCaps/script_wireframe_create.png "Create Script")

  2. Call it `WireFrame`.

     ![Name it WireFrame](./ScreenCaps/script_wireframe_named.png "Name it WireFrame")

  3. Attach it to the `FirstPersonCharacter` game object. The GL functions are typically called from a script
     attached to the camera, and our camera is in the `FirstPersonCharacter`.
     (See the [Unity GL documentation](http://docs.unity3d.com/ScriptReference/GL.html) for more information)

     ![Select FPSController](./ScreenCaps/fpscontroller_selected4.png "Select FPSController")
     ![Attach WireFrame to FPSController](./ScreenCaps/script_wireframe_attached.png "Attach WireFrame to FPSController")

  4. Double-click the `WireFrame` script asset to open it in Mono and add the
     following lines

           public Material wireMaterial;
           public GameObject targetBlock;

     at the top of the class:

     ![WireFrame Variable Declarations](./ScreenCaps/script_wireframe_variable_declarations.png "WireFrame Variable Declarations")

     The `wireMaterial` object will be used for draw lines with GL.
     The `targetBlock` object will be the block which lines are to be drawn around.

  5. Save.

     ![Save the Script](./ScreenCaps/script_mineblock_file_save.png "Save the Script")

  6. Go back to Unity and create a new Material asset.

     ![New Material](./ScreenCaps/wirematerial_create.png "New Material")

     Name it `WireMaterial`.

     ![Name it WireMaterial](./ScreenCaps/wirematerial_named.png "Name it WireMaterial")

     Change it to black.

     ![Change Material Color to Black](./ScreenCaps/wirematerial_change_to_black.png "Change Material Color to Black")

  7. Select the `FirstPersonCharacter` object and drag the `WireMaterial` asset
     into the corresponding field of the `WireFrame` script.

     ![Attach WireMaterial to WireFrame Script](./ScreenCaps/wirematerial_attached.png "Attach WireMaterial to WireFrame Script")

  8. With the `FirstPersonCharacter` still selected, drag the `Block` prefab
     into the `Target Block` field of the `WireFrame` script.
    
     ![Attach Block Prefab to WireFrame Script](./ScreenCaps/script_wireframe_block_attached.png "Attach Block Prefab to WireFrame Script")

     Note that this is just temporary. In later steps, we will code the `targetBlock` to be
     assigned dynamically at run time based on which block the player is looking at.

  9. Open the `MineBlock` script in Mono and add the following line

           public GameObject fpsController;
  
     at the top of the class:

     ![MineBlock Variable Declaration](./ScreenCaps/script_mineblock_variable_declaration_fpscontroller.png "MineBlock Variable Declaration")

  9. Add this line

           fpsController = GameObject.Find("FirstPersonCharacter");

     to the `Start` function:

     ![MineBlock Find FPSController](./ScreenCaps/script_mineblock_find_fps.png "MineBlock Find FPSController")

  9. Add functions `OnMouseEnter` and `OnMouseExit`

           void OnMouseEnter()
           {
           }

           void OnMouseExit()
           {
           }

     at the bottom of the class after the `OnMouseDown` function:

     ![MineBlock OnMouseEnter and OnMouseExit](./ScreenCaps/script_mineblock_onmouseenter_onmouseexit.png "MineBlock OnMouseEnter and OnMouseExit")

  9. Add this line

           fpsController.GetComponent<WireFrame>().targetBlock = gameObject;

     to the `OnMouseEnter` function:

     ![Set TargetBlock](./ScreenCaps/script_mineblock_set_targetblock.png "Set TargetBlock")

     This assigns the `Block` game object that the player is pointing at to
     become the `targetBlock` in the `WireFrame` script. Now we need to code
     the `WireFrame` script to actually draw a wireframe around that block.
     (There is a loose end to the mechanism in `MineBlock` that we will take care
     of later.  If the player looks away from a block but not at another block,
     the last block the player was looking at will remain highlighted with a
     wireframe. But let's not worry about that until the `WireFrame` script
     is actually drawing something.)

  9. Back in the `WireFrame` script add this function

           void OnPostRender()
           {
           }

     at the end of the class:

     ![WireFrame OnPostRender](./ScreenCaps/script_wireframe_onpostrender.png "WireFrame OnPostRender")

  9. Add these lines

           if( targetBlock)
           {
               GL.PushMatrix();
               wireMaterial.SetPass(0);
               GL.Begin(GL.LINES);
               //
               // Left to right lines
               // TODO
               //
               // Up and down lines
               // TODO
               //
               // Front to back lines
               // TODO
               //
               GL.End();
               GL.PopMatrix();
           }

  
     to the `OnPostRender` function:

     ![WireFrame GL Framework](./ScreenCaps/script_wireframe_gl_framework.png "WireFrame GL Framework")

     There are three sets of four lines that need to be drawn around the cube.
     There is one set of four edges on a cube for each of the three directions
     in 3D space.

  9. The way a GL line works is by specifying the starting point and ending point of the line
     with two consecutive calls to `GL.Vertex`.

     The four lines in the right to left direction can be specified relative to
     the `targetBlock.transform.position` like this:

           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.forward + 0.51f*Vector3.up);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.forward + 0.51f*Vector3.up);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.back + 0.51f*Vector3.up);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.back + 0.51f*Vector3.up);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.forward + 0.51f*Vector3.down);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.forward + 0.51f*Vector3.down);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.back + 0.51f*Vector3.down);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.back + 0.51f*Vector3.down);

     The factor of `0.51` is to make the lines hover a slight bit out from the
     actual edges of the cube (just like in Minecraft, as you may have noticed).

     The four lines going up and down can be specified like this:

           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.forward + 0.51f*Vector3.up);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.forward + 0.51f*Vector3.down);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.back + 0.51f*Vector3.up);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.back + 0.51f*Vector3.down);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.forward + 0.51f*Vector3.up);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.forward + 0.51f*Vector3.down);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.back + 0.51f*Vector3.up);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.back + 0.51f*Vector3.down);

     And the four lines along the front to back edges of the cube can be specified like this:

           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.forward + 0.51f*Vector3.up);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.back + 0.51f*Vector3.up);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.forward + 0.51f*Vector3.down);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.back + 0.51f*Vector3.down);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.forward + 0.51f*Vector3.up);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.back + 0.51f*Vector3.up);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.forward + 0.51f*Vector3.down);
           GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.back + 0.51f*Vector3.down);

     Replacing each respective `TODO` in the `OnPostRender` function with the above lines of code results in this:

     ![WireFrame Lines](./ScreenCaps/script_wireframe_lines.png "WireFrame Lines")

     The `if` statement checks to be sure `targetBlock` exists before
     attempting to wire frame it. This prevents Unity from becoming confused by
     `targetBlock.transform` after the player clicks and breaks the block that
     they are looking at. It doesn't make sense to access the transform of a
     game object that no longer exists.

  9. Finally, let's tie up the loose end mentioned above. Currently, if the player moves the cursor off of
     a block and into the sky or plane or something other than another block, that last block that the player
     was looking at remains highlighted with a wire frame.

     Add this line

           public bool drawWireFrame;

     to the top of the `MineBlock` class:

     ![MineBlock DrawWireFrame Variable Declaration](./ScreenCaps/script_mineblock_drawwireframe_variable_declaration.png "MineBlock DrawWireFrame Variable Declaration")

  9. Add this line

           drawWireFrame = false;

     to the `Start` function:

     ![Init DrawWireFrame Variable](./ScreenCaps/script_mineblock_drawwireframe_init.png "Init DrawWireFrame Variable")

  9. Set `drawWireFrame` to `true` in `OnMouseEnter` and set it to `false` in `OnMouseExit`.

     ![DrawWireFrame Toggle](./ScreenCaps/script_mineblock_drawwireframe_toggle.png "DrawWireFrame Toggle")

  9. Now, in the `WireFrame` script, augment the condition in the `if` statement as follows:

           if( targetBlock && targetBlock.GetComponent<MineBlock>().drawWireFrame)

     ![DrawWireFrame Condition](./ScreenCaps/script_wireframe_if_drawwireframe.png "DrawWireFrame Condition")

<a name="texturemapping"></a>
[Back to TOC](#toc)
### Texture Map the Blocks

  1. TODO

<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
<br/> <br/> <br/> <br/>
