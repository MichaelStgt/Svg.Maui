﻿#nullable enable
using System.IO;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;
using Svg.Maui;

var name = "__tiger";
var path = @$"..\..\Svg.Skia\externals\SVG\Tests\W3CTestSuite\svg\{name}.svg";
var stream = File.OpenRead(path);
var drawable = SvgDrawable.CreateFromStream(stream);
if (drawable?.Picture is null)
{
    return;
}

using var bmp = SkiaGraphicsService.Instance.CreateBitmapExportContext((int)drawable.Picture.Width, (int)drawable.Picture.Height);
var dirtyRect = new RectangleF(0, 0, drawable.Picture.Width, drawable.Picture.Height);

drawable.Draw(bmp.Canvas, dirtyRect);

bmp.WriteToFile(name + ".png");
