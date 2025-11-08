using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using WaveGame.Base;
using WaveGame.Rendering;

namespace WaveGame;

public class Game1 : Core
{
    public Game1() : base("WaveGame", 1280, 720, false)
    {
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
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

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        var emptyHex = Content.Load<Texture2D>("img/empty hex");
        var hexMap = new EmptyHexMap(emptyHex, 5, 5);
        var hexRenderer = new HexRenderer(hexMap);

        SpriteBatch.Begin();
        hexRenderer.Draw(SpriteBatch, Window.ClientBounds);
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
