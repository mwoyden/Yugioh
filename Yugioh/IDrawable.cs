using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Yugioh
{
    /// <summary>
    /// Interface that tells you if something is able to be drawn/rendered to the screen.
    /// </summary>
    interface IDrawable
    {
        void Draw(SpriteBatch spriteBatch);
    }
}
