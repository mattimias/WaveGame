using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WaveGame.Data;
using WaveGame.World;

namespace WaveGame.Input;

public class InputManager(Vector2 initMousePosition, Player player)
{
    public Vector2 MousePosition = initMousePosition;
    public TileCoord PlayerLocation;

    public void Update(List<HexTile> hexTiles, Vector2 screenCentre, Vector2 hexDims)
    {
        // Update MousePosition
        MousePosition = Mouse.GetState().Position.ToVector2() - screenCentre;
        // Check if left click.
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        { // Try to update player position.
            HexTile selected = null;
            var minD = float.MaxValue;

            foreach (HexTile tile in hexTiles)
            {
                // Check Player is not already on tile.
                var d = Vector2.Distance(MousePosition, tile.Position);
                // This distance must be within the bounds of the hexagon.
                if (d <= tile.Texture.Height && d <= tile.Texture.Width && d < minD)
                {
                    minD = d;
                    selected = tile;
                }
            }

            // Try to move only if a tile is selected and it is not the same tile the player is on.
            if (selected != null && selected.Coordinates != player.Location)
            {
                if (player.Stamina >= selected.MovementCost)
                {
                    PlayerLocation = selected.Coordinates;
                    player.UpdateAfterMoving(PlayerLocation, player.Stamina - selected.MovementCost, hexDims);
                }
            }


        }
        
    }
}