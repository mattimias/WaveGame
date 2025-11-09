namespace WaveGame.Data;

public class TileCoord(int q, int r)
{
    public int Q = q;
    public int R = r;

    public override string ToString()
    {
        return $"({Q}, {R})";
    }
}

// pointy top hexagons
// +q is ↗
// +r is ↓
// +s is ↖
// q + r + s = 0; e.g. going straight right means q+1, s-1, so (0,0) -> (1,0)
// going northwest means s+1, r-1, so (0,0) -> (0,-1)