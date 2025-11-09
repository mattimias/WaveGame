using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WaveGame.Data;

namespace WaveGame.Base;

public class Functions
{
    public static Vector2 GetHexPosition(Texture2D tex, TileCoord cds)
    {
        var x = 0.5f * MathF.Sqrt(3) * (cds.Q + cds.R / 2);
        var y = 1.5f * cds.R;

        return new(
                x * tex.Height + (cds.R % 2 * tex.Width / 2), // No idea why this works honestly
                y * 0.5f * tex.Height);
    }

    public static Vector2 GetPositionInHex(TileCoord cds, Vector2 hexDims)
    {
        var x = 0.5f * MathF.Sqrt(3) * (cds.Q + cds.R / 2);
        var y = 1.5f * cds.R;
        var width = hexDims.X;
        var height = hexDims.Y;

        return new(
                x * height + (cds.R % 2 * width / 2), // Relies on centering within hex so
                y * 0.5f * height);
    }
}