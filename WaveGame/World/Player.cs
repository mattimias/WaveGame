
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WaveGame.Base;
using WaveGame.Data;

namespace WaveGame.World;

public class Player(Texture2D playerSprite, TileCoord location)
{
    public TileCoord Location = location;
    public int Stamina = 10;
    public Vector2 Origin = new(playerSprite.Width / 2, playerSprite.Height / 2);
    public Vector2 Position = Functions.GetHexPosition(playerSprite, location);

    public Texture2D PlayerSprite = playerSprite;

    public void UpdateAfterMoving(TileCoord newLocation, int newStamina, Vector2 hexDims)
    {
        Location = newLocation;
        Stamina = newStamina;
        Position = Functions.GetPositionInHex(Location, hexDims);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 screenCentre)
    {
        var newPos = Position + screenCentre;
        spriteBatch.Draw(PlayerSprite, newPos, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 1f);
    }
}