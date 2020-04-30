using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Centipede {
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
            screen = new Point(470, 550);
            ApplyResolutionSettings();

            // TODO: use this.Content to load your game content here
        }

    }
}
