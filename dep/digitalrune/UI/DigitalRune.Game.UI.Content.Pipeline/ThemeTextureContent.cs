﻿using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;


namespace DigitalRune.Game.UI.Content.Pipeline
{
  /// <summary>
  /// Represents a texture of the UI theme.
  /// </summary>
  public class ThemeTextureContent : INamedObject
  {
    /// <summary>
    /// Gets or sets the name of the texture.
    /// </summary>
    /// <value>The name of the texture.</value>
    public string Name { get; set; }


    /// <summary>
    /// Gets or sets a value indicating whether this texture is the default texture.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if this texture is the default texture; otherwise, 
    /// <see langword="false"/>.
    /// </value>
    public bool IsDefault { get; set; }


    /// <summary>
    /// Gets or sets the texture.
    /// </summary>
    /// <value>The texture.</value>
    public ExternalReference<TextureContent> Texture { get; set; }
  }
}
