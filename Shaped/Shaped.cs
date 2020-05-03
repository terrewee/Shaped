using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shaped {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Shaped : GameEnvironment {
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(800, 600);
            ApplyResolutionSettings();

            // TODO: use this.Content to load your game content here
            gameStateManager.AddGameState("Title", new GameStates.TitleState());
            gameStateManager.AddGameState("Playing", new GameStates.PlayingState());
            gameStateManager.AddGameState("GameOver", new GameStates.GameOverState());
            gameStateManager.SwitchTo("Title");
        }

    }
}
