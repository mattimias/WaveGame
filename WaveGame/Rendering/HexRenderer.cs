
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WaveGame.World;
using WaveGame.Data;

namespace WaveGame.Rendering;
public class HexRenderer(HexMap hexMap)
{
    public HexMap HexMap = hexMap;

    public void Update(Vector2 screenCentre, bool playerCanMove)
    {
        HexMap.Update(screenCentre, playerCanMove);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 screenCentre)
    {
        foreach (HexTile hexTile in HexMap.HexTiles)
        {
            hexTile.Draw(spriteBatch, screenCentre);
        }
    }
}
