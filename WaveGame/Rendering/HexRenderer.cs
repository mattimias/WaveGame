
using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WaveGame.Base;
using WaveGame.Data;

namespace WaveGame.Rendering;
public class HexRenderer(HexMap hexMap)
{
    public HexMap HexMap = hexMap;

    public void Draw(SpriteBatch spriteBatch, Rectangle clientBounds)
    {
        foreach (HexTile hexTile in HexMap.HexTiles)
        {
            hexTile.Draw(spriteBatch, clientBounds);
        }
    }
}
