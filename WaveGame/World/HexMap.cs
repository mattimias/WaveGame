using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WaveGame.Data;

namespace WaveGame.World;

public abstract class HexMap
{
    public Dictionary<TileCoord, HexTile> TileDict; // stores coords -> hextiles
    public (int length, int breadth) MapDim; // map dimensions
    public List<HexTile> HexTiles; // All hex tiles for easy access
    public readonly Texture2D DefaultHex;

    protected HexMap(Texture2D defaultHex, int length = 1, int breadth = 1)
    // Strip of hexagons, goes from bottom right to bottom left
    // origin is in middle
    {
        if (breadth < 1)
        {
            throw new ArgumentException("breadth must be greater than or equal to 1");
        }
        if (breadth % 2 == 0)
        {
            throw new ArgumentException("breadth must be odd");
        }
        if (length < 1)
        {
            throw new ArgumentException("length must be greater than or equal to 1");
        }
        if (length < breadth)
        {
            throw new ArgumentException("length must be greater than or equal to breadth");
        }

        TileDict = [];
        MapDim = (length, breadth);
        DefaultHex = defaultHex;
    }

    public void Update(Vector2 screenCentre, bool playerCanMove)
    {
        var MousePosition = Mouse.GetState().Position.ToVector2() - screenCentre;
        float minD = float.MaxValue;
        HexTile selected = null;

        foreach (HexTile tile in HexTiles)
        {
            tile.Color = Color.White;

            var d = Vector2.Distance(MousePosition, tile.Position);
            if (d < minD)
            {
                minD = d;
                selected = tile;
            }
        }

        if (minD < Math.Max(selected.Origin.Y, selected.Origin.X))
        {
            if (playerCanMove) selected.Color = Color.White;
            else selected.Color = Color.Red;
        }
        
    }

    public void AddTile(int q, int r, Texture2D hexTexture)
    {
        var coords = new TileCoord(q, r);
        TileDict[coords] = new HexTile(hexTexture, coords);
    }
}

// 

public sealed class EmptyHexMap : HexMap // Empty Hex Map only
{
    public EmptyHexMap(Texture2D defaultHex, int length = 1, int breadth = 1) : base(defaultHex, length, breadth)
    {
        var start = (breadth - 1) / 2;

        for (var q = 0; q < length; q++)
        {
            AddTile(q, -q, DefaultHex);
        }

        for (var s = 1; s <= start; s++)
        {
            for (var q = 0; q < length - s; q++)
            {
                AddTile(q, -q - s, DefaultHex);
            }

            for (var q = s; q < length; q++)
            {
                AddTile(q, -q + s, DefaultHex);
            }
        }

        HexTiles = [.. TileDict.Values];
    }
    // s: from 0 to start, q starts at 0 to length - s, r = -q -s
    // s: from -1 to -start, q starts at -s to -length + 1, r = -q -s
}

