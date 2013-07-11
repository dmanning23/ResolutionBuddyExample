using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using ResolutionBuddy;
using BasicPrimitiveBuddy;

namespace ResolutionBuddyExample
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Texture2D _texture;
		BasicPrimitive titlesafe;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Resolution.Init(ref graphics);
			titlesafe = new BasicPrimitive(graphics.GraphicsDevice);
			Content.RootDirectory = "Content";

			// Change Virtual Resolution 
			//Resolution.SetVirtualResolution(320, 240);
			//Resolution.SetVirtualResolution(640, 480);
			Resolution.SetDesiredResolution(1024, 768);
			//Resolution.SetResolution(320, 240, false);
			Resolution.SetScreenResolution(1280, 720, true);
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			//_texture = Content.Load<Texture2D>("alley_320x240");
			//_texture = Content.Load<Texture2D>("alley_640x480");
			_texture = Content.Load<Texture2D>("alley_1024x768");
			//_texture = Content.Load<Texture2D>("Braid_screenshot8");
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
				Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
			{
				Exit();
			}
			// TODO: Add your update logic here	
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			Resolution.BeginDraw();
		
			spriteBatch.Begin(SpriteSortMode.Immediate, 
			                  BlendState.AlphaBlend, 
			                  null, null, null, null,
			                  Resolution.TransformationMatrix());

			spriteBatch.Draw(_texture, Vector2.Zero, Color.White);

			titlesafe.Rectangle(Resolution.TitleSafeArea, Color.Red, spriteBatch);

			spriteBatch.End();
            
			base.Draw(gameTime);
		}
	}
}

