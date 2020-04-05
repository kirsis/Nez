using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Nez
{
	public static class Screen
	{
		static internal GraphicsDeviceManager _graphicsManager;
		static internal float _displayScale;
		static int _requestedWidth;
		static int _requestedHeight;
		private static int _requestedPreferredWidth;
		private static int _requestedPreferredHeight;

		internal static void Initialize(GraphicsDeviceManager graphicsManager, int width, int height, float displayScale) {
			_graphicsManager = graphicsManager;
			_requestedWidth = width;//_graphicsManager.GraphicsDevice.PresentationParameters.BackBufferWidth;
			_requestedHeight = height;//_graphicsManager.GraphicsDevice.PresentationParameters.BackBufferHeight;
			_displayScale = displayScale;
	}

		/// <summary>
		/// Logical width of the Screen
		/// </summary>
		/// <value>The width.</value>
		public static int LogicalWidth
		{
			get => _requestedWidth;
			set
			{
				_requestedWidth = value;
				_graphicsManager.GraphicsDevice.PresentationParameters.BackBufferWidth = (int)(value * _displayScale);
			}
		}

		/// <summary>
		/// Logical width of the Screen
		/// </summary>
		/// <value>The height.</value>
		public static int LogicalHeight
		{
			get => _requestedHeight;
			set
			{
				_requestedHeight = value;
				_graphicsManager.GraphicsDevice.PresentationParameters.BackBufferHeight = (int)(value * _displayScale);
			}
		}

		/// <summary>
		/// Height of the GraphicsDevice back buffer
		/// </summary>
		/// <value>The width.</value>
		public static int RenderWidth
		{
			get => _graphicsManager.GraphicsDevice.PresentationParameters.BackBufferWidth;
			set
			{
				_requestedWidth = (int)(value / _displayScale);
				_graphicsManager.GraphicsDevice.PresentationParameters.BackBufferWidth = value;
			}
		}

		/// <summary>
		/// Height of the GraphicsDevice back buffer
		/// </summary>
		/// <value>The height.</value>
		public static int RenderHeight
		{
			get => _graphicsManager.GraphicsDevice.PresentationParameters.BackBufferHeight;
			set
			{
				_requestedHeight = (int)(value / _displayScale);
				_graphicsManager.GraphicsDevice.PresentationParameters.BackBufferHeight = value;
			}
		}

		/// <summary>
		/// gets the Screen's size as a Vector2
		/// </summary>
		/// <value>The screen size.</value>
		public static Vector2 Size => new Vector2(Width, Height);

		/// <summary>
		/// gets the Screen's center.null Note that this is the center of the backbuffer! If you are rendering to a smaller RenderTarget
		/// you will need to scale this value appropriately.
		/// </summary>
		/// <value>The center.</value>
		public static Vector2 RenderCenter => new Vector2(RenderWidth / 2, RenderHeight / 2);

		public static int PreferredBackBufferWidth
		{
			get => _requestedPreferredWidth;
			set
			{
				_requestedPreferredWidth = value;
				_graphicsManager.PreferredBackBufferWidth = (int)(value * _displayScale);
			}
		}

		public static int PreferredBackBufferHeight
		{
			get => _requestedPreferredHeight;
			set
			{
				_requestedPreferredHeight = value;
				_graphicsManager.PreferredBackBufferHeight = (int)(value * _displayScale);
			}
		}

		public static int LogicalMonitorWidth => GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

		public static int LogicalMonitorHeight => GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

		public static SurfaceFormat BackBufferFormat =>
			_graphicsManager.GraphicsDevice.PresentationParameters.BackBufferFormat;

		public static SurfaceFormat PreferredBackBufferFormat
		{
			get => _graphicsManager.PreferredBackBufferFormat;
			set => _graphicsManager.PreferredBackBufferFormat = value;
		}

		public static bool SynchronizeWithVerticalRetrace
		{
			get => _graphicsManager.SynchronizeWithVerticalRetrace;
			set => _graphicsManager.SynchronizeWithVerticalRetrace = value;
		}

		// defaults to Depth24Stencil8
		public static DepthFormat PreferredDepthStencilFormat
		{
			get => _graphicsManager.PreferredDepthStencilFormat;
			set => _graphicsManager.PreferredDepthStencilFormat = value;
		}

		public static bool IsFullscreen
		{
			get => _graphicsManager.IsFullScreen;
			set => _graphicsManager.IsFullScreen = value;
		}

		public static DisplayOrientation SupportedOrientations
		{
			get => _graphicsManager.SupportedOrientations;
			set => _graphicsManager.SupportedOrientations = value;
		}

		public static void ApplyChanges() => _graphicsManager.ApplyChanges();

		/// <summary>
		/// sets the preferredBackBuffer then applies the changes
		/// </summary>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		public static void SetSize(int width, int height)
		{
			PreferredBackBufferWidth = width;
			PreferredBackBufferHeight = height;
			ApplyChanges();
		}
	}
}