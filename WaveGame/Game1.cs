using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using WaveGame.World;
using WaveGame.Rendering;
using WaveGame.Input;

namespace WaveGame;

public class Game1 : Core
{
    public HexMap GameMap;
    public HexRenderer HexRenderer;
    public Vector2 ScreenCentre;
    public Player Player;
    public InputManager InputManager;
    public Vector2 HexDims;

    public Game1() : base("WaveGame", 1280, 720, false)
    {
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
        var emptyHex = Content.Load<Texture2D>("img/empty hex");
        HexDims = new Vector2(emptyHex.Width, emptyHex.Height);
        GameMap = new EmptyHexMap(emptyHex, 5, 5);
        HexRenderer = new HexRenderer(GameMap);

        var playerSprite = Content.Load<Texture2D>("img/playersprite");
        Player = new Player(playerSprite, new Data.TileCoord(0, 0));
        InputManager = new InputManager(Mouse.GetState().Position.ToVector2(), Player);
    }

    protected override void LoadContent()
    {
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        ScreenCentre = new Vector2(Window.ClientBounds.Width * 0.5f, Window.ClientBounds.Height * 0.5f);
        base.Update(gameTime);
        InputManager.Update(GameMap.HexTiles, ScreenCentre, HexDims);
        HexRenderer.Update(ScreenCentre, Player.Stamina > 0);
        
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
        SpriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack); // Higher layerDepth is drawn first
        HexRenderer.Draw(SpriteBatch, ScreenCentre);
        Player.Draw(SpriteBatch, ScreenCentre);
        Console.WriteLine((Player.Location, Player.Stamina));
        SpriteBatch.End();
    }
}
