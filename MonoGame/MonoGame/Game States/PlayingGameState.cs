﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class PlayingGameState : IGameState 
    {
        Game1 game;

        public PlayingGameState(Game1 game)
        {
            this.game = game;
            game.background = Color.Black;
            game.keyboard = new KeyboardController(game.level.player, game);
        }

        public void Update(GameTime gameTime)
        {
            game.keyboard.Update();
            game.level.Update(gameTime);
            game.camera.LookAt(game.level.player.position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
