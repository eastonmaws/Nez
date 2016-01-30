﻿using System;
using Nez.Sprites;
using Nez.Textures;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Nez
{
	public class TiledSprite : Sprite
	{
		public new int width
		{
			get { return _sourceRect.Width; }
			set { _sourceRect.Width = value; }
		}

		public new int height
		{
			get { return _sourceRect.Height; }
			set { _sourceRect.Height = value; }
		}

		/// <summary>
		/// we keep a copy of the sourceRect so that we dont change the Subtexture in case it is used elsewhere
		/// </summary>
		Rectangle _sourceRect;


		public TiledSprite( Subtexture subtexture ) : base( subtexture )
		{
			renderState = new RenderState();
			renderState.samplerState = SamplerState.PointWrap;
			_sourceRect = subtexture.sourceRect;
		}


		public TiledSprite( Texture2D texture ) : this( new Subtexture( texture ) )
		{}


		public override void render( Graphics graphics, Camera camera )
		{
			if( isVisibleFromCamera( camera ) )
				graphics.spriteBatch.Draw( subtexture, entity.transform.position + _localPosition, _sourceRect, color, entity.transform.rotation, origin, entity.transform.scale, spriteEffects, _layerDepth );
		}

	}
}

