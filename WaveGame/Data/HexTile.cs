using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WaveGame.Base;

namespace WaveGame.Data;

public class HexTile(Texture2D texture, TileCoord coords, int height = 0)
{
    public int Height = height; // Used for rendering + movement cost
    public TileCoord Coordinates = coords; // Axial coordinates;
    public int MovementCost = 1 + height;
    
    public bool Discovered = false;
    public VisibilityState Visibility = VisibilityState.Hidden;

    public TerrainType Terrain = TerrainType.Grass;
    public TileContent Content = TileContent.Empty;

    public bool IsLavaSource = false;
    public int LavaHeight = 0;

    public Texture2D Texture = texture;
    public Color Color = Color.White;
    public Vector2 Origin = new(texture.Width / 2, texture.Height / 2);
    public Vector2 Position = Functions.GetHexPosition(texture, coords);

    public void Draw(SpriteBatch spriteBatch, Vector2 screenCentre) // Update position according to window
    {
        var newPos = Position + screenCentre;
        spriteBatch.Draw(Texture, newPos, null, Color, 0f, Origin, 1f, SpriteEffects.None, 0f);
    }
}