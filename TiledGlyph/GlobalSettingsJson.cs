using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace TiledGlyph
{
    public class GlobalSettingsJson
    {
        public int iFontHeight = 20;
        public int iTileHeight = 24;
        public int iTileWidth = 24;
        public int iImageHeight = 512;
        public int iImageWidth = 512;
        public int iGRenderMode = 0;
        public int iImageCount = 1;
        public Color cBgColor = Color.Transparent;
        public Color cPenColor = Color.White;
        public Color cShadowColor = Color.Gray;
        public string fTextStrings = "";
        public string fFontName = "Font/NotoSansCJKsc-Regular.otf";
        public bool bUseUnlimitHeight = false;
        public bool bOptmizeAlpha = false;
        public ImageFormat globalSaveFmt = ImageFormat.Png;


        public int relativePositionX = 0;
        public int relativePositionY = 0;
        public float iFontBold = (float)0;
        public int iFontOutline = 2;
        public bool bUseOutlineEffect = false;


        public  int iFontHeight2 = 20;
        public  int iFontSizeStartIndex = 0;
        public  int iFontSizeEndIndex = 5;
        public  int relativePositionX2 = 0;
        public  int relativePositionY2 = 0;
    }
}
