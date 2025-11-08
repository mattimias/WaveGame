using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WaveGame.Data;

public class HexTile(Texture2D texture, TileCoord coords)
{
    public int Height = 0; // Used for rendering + movement cost
    public TileCoord Coordinates = coords; // Axial coordinates;
    
    public bool Discovered = false;
    public VisibilityState Visibility = VisibilityState.Hidden;

    public TerrainType Terrain = TerrainType.Grass;
    public TileContent Content = TileContent.Empty;

    public bool IsLavaSource = false;
    public int LavaHeight = 0;

    public Texture2D Texture = texture;
    public Color Color = Color.White;
    public Vector2 Origin = new(texture.Width / 2, texture.Height / 2);
    public Vector2 Position = GetPosition(texture, coords);

    private static Vector2 GetPosition(Texture2D tex, TileCoord cds)
    {
        var x = 0.5f * MathF.Sqrt(3) * (cds.Q + cds.R / 2);
        var y = 1.5f * cds.R;

        return new(
                x * tex.Height + (cds.R % 2 * tex.Width / 2), // No idea why this works honestly
                y * 0.5f * tex.Height);
        
        // return new(
        //     x * tex.Width, y * 0.75f * tex.Height
        // );
    }

    public void Draw(SpriteBatch spriteBatch, Rectangle clientBounds) // Update position according to window
    {
        var newPos = new Vector2(Position.X + clientBounds.Width * 0.5f, Position.Y + clientBounds.Height * 0.5f);
        spriteBatch.Draw(Texture, newPos, null, Color, 0f, Origin, 1f, SpriteEffects.None, 1f);
    }
}