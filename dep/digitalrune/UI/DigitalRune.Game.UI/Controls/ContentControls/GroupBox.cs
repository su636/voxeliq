﻿using System.ComponentModel;


namespace DigitalRune.Game.UI.Controls
{
  /// <summary>
  /// Represents a control that creates a container that has a border and a header for other user 
  /// interface (UI) content.
  /// </summary>
  public class GroupBox : ContentControl
  {
    // A group box draws a text block with the title and the renderer draws a border.
    // A group box does not have a special functionality.

    //--------------------------------------------------------------
    #region Fields
    //--------------------------------------------------------------

    private TextBlock _titleTextBlock;
    #endregion


    //--------------------------------------------------------------
    #region Properties & Events
    //--------------------------------------------------------------
    #endregion


    //--------------------------------------------------------------
    #region Game Object Properties & Events
    //--------------------------------------------------------------

    /// <summary> 
    /// The ID of the <see cref="TitleTextBlockStyle"/> game object property.
    /// </summary>
    [Browsable(false)]
    public static readonly int TitleTextBlockStylePropertyId = CreateProperty(
      typeof(GroupBox), "TitleTextBlockStyle", GamePropertyCategories.Style, null, "TitleTextBlock", 
      UIPropertyOptions.AffectsRender);

    /// <summary>
    /// Gets or sets the style that is applied to the <see cref="Title"/>. 
    /// This is a game object property.
    /// </summary>
    /// <value>
    /// The style that is applied to the <see cref="Title"/>. Can be <see langword="null"/> or an 
    /// empty string to hide the title.
    /// </value>
    public string TitleTextBlockStyle
    {
      get { return GetValue<string>(TitleTextBlockStylePropertyId); }
      set { SetValue(TitleTextBlockStylePropertyId, value); }
    }


    /// <summary> 
    /// The ID of the <see cref="Title"/> game object property.
    /// </summary>
    [Browsable(false)]
    public static readonly int TitlePropertyId = CreateProperty(
      typeof(GroupBox), "Title", GamePropertyCategories.Common, null, "Unnamed", 
      UIPropertyOptions.AffectsRender);

    /// <summary>
    /// Gets or sets the title. 
    /// This is a game object property.
    /// </summary>
    /// <value>The title.</value>
    public string Title
    {
      get { return GetValue<string>(TitlePropertyId); }
      set { SetValue(TitlePropertyId, value); }
    }
    #endregion


    //--------------------------------------------------------------
    #region Creation & Cleanup
    //--------------------------------------------------------------

    /// <summary>
    /// Initializes a new instance of the <see cref="GroupBox"/> class.
    /// </summary>
    public GroupBox()
    {
      Style = "GroupBox";
    }
    #endregion


    //--------------------------------------------------------------
    #region Methods
    //--------------------------------------------------------------

    /// <inheritdoc/>
    protected override void OnLoad()
    {
      base.OnLoad();

      // Create TextBlock for title
      var titleTextBlockStyle = TitleTextBlockStyle;
      if (!string.IsNullOrEmpty(titleTextBlockStyle))   // No title if no style is specified.
      {
        _titleTextBlock = new TextBlock
        {
          Name = "GroupBoxTitle",
          Style = titleTextBlockStyle,
          Text = Title,
        };
        VisualChildren.Add(_titleTextBlock);

        // Connect Title with TextBlock.Text.
        var title = Properties.Get<string>(TitlePropertyId);
        var text = _titleTextBlock.Properties.Get<string>(TextBlock.TextPropertyId);
        title.Changed += text.Change;
      }
    }


    /// <inheritdoc/>
    protected override void OnUnload()
    {
      if (_titleTextBlock != null)
      {
        // Unconnect Title and TextBlock.Text.
        var title = Properties.Get<string>(TitlePropertyId);
        var text = _titleTextBlock.Properties.Get<string>(TextBlock.TextPropertyId);
        title.Changed -= text.Change;

        VisualChildren.Remove(_titleTextBlock);
        _titleTextBlock = null;
      }

      base.OnUnload();
    }
    #endregion
  }
}
