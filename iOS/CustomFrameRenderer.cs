//
//  CustomFrameRenderer.cs
//
//  Author:
//       Wagner Rodrigo <wagner2303@gmail.com>
//
//  Copyright (c) 2017 
//
using System;
using System.Drawing;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Frame), typeof(FormsSample.iOS.CustomFrameRenderer))]
namespace FormsSample.iOS {
	public class CustomFrameRenderer : FrameRenderer{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e) {
			base.OnElementChanged(e);

			if (e.NewElement != null && e.OldElement == null) {
				if (this.Layer.Sublayers != null && this.Layer.Sublayers.Length > 0) {
					var subLayer = this.Layer.Sublayers[0];
					subLayer.CornerRadius = 2.0f;
					subLayer.MasksToBounds = true;
				}
			}

			// Shadow
			this.Layer.CornerRadius = 2.0f;
			this.Layer.ShadowColor = UIColor.DarkGray.CGColor;
			this.Layer.ShadowOpacity = 0.5f;
			this.Layer.ShadowRadius = 2.0f;
			this.Layer.ShadowOffset = new SizeF(0, 1);
		}
	}
}
