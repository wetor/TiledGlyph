using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TiledGlyph.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var gSettings = new GlobalSettingsJson();
            if (args.Length != 3)
            {
                System.Console.WriteLine("第一个参数请指定设定文件的Json");
                System.Console.WriteLine("第二个参数请指定UTF8格式保存的字体文字txt");
                System.Console.WriteLine("第三个参数请指定输出图片文件名");
                File.WriteAllText("SettingTmp.json", JsonConvert.SerializeObject(gSettings, Formatting.Indented));
                return;
            }
            string pathJson = args[0];
            string pathFontString = args[1];
            string fontstring = "";
            if (File.Exists(pathJson))
            {
                gSettings = JsonConvert.DeserializeObject<GlobalSettingsJson>(File.ReadAllText(pathJson));
                GlobalSettings.iFontHeight = gSettings.iFontHeight;
                GlobalSettings.iTileHeight = gSettings.iTileHeight;
                GlobalSettings.iTileWidth = gSettings.iTileWidth;
                GlobalSettings.iImageHeight = gSettings.iImageHeight;
                GlobalSettings.iImageWidth = gSettings.iImageWidth;
                GlobalSettings.iGRenderMode = 0;//gSettings.iGRenderMode;
                GlobalSettings.iImageCount = gSettings.iImageCount;
                GlobalSettings.cBgColor = gSettings.cBgColor;
                GlobalSettings.cPenColor = gSettings.cPenColor;
                GlobalSettings.cShadowColor = gSettings.cShadowColor;
                GlobalSettings.fTextStrings = gSettings.fTextStrings;
                GlobalSettings.fFontName = gSettings.fFontName;
                GlobalSettings.bUseUnlimitHeight = gSettings.bUseUnlimitHeight;
                GlobalSettings.bOptmizeAlpha = gSettings.bOptmizeAlpha;
                GlobalSettings.globalSaveFmt = gSettings.globalSaveFmt;


                GlobalSettings.relativePositionX = gSettings.relativePositionX;
                GlobalSettings.relativePositionY = gSettings.relativePositionY;
                GlobalSettings.iFontBold = gSettings.iFontBold;

                GlobalSettings.iFontOutline = gSettings.iFontOutline;
                GlobalSettings.bUseOutlineEffect = gSettings.bUseOutlineEffect;

                GlobalSettings.iFontSizeStartIndex = gSettings.iFontSizeStartIndex;
                GlobalSettings.iFontSizeEndIndex = gSettings.iFontSizeEndIndex;
                GlobalSettings.relativePositionX2 = gSettings.relativePositionX2;
                GlobalSettings.relativePositionY2 = gSettings.relativePositionY2;
                GlobalSettings.iFontHeight2 = gSettings.iFontHeight2;
            }
            else
            {
                File.WriteAllText("SettingTmp.json", JsonConvert.SerializeObject(gSettings, Formatting.Indented));
                System.Console.WriteLine("第一个参数请指定设定文件的Json");
                return;
            }
            if (File.Exists(pathFontString))
            {
                fontstring = File.ReadAllText(pathFontString, Encoding.UTF8);
            }
            else
            {
                System.Console.WriteLine("第二个参数请指定UTF8格式保存的字体文字");
                return;
            }
            var bmdrawer = new BMDrawer();
            var tmpBmp = bmdrawer.test_draw(fontstring);
            var dest = new Bitmap(tmpBmp.Width, tmpBmp.Height);
            if (GlobalSettings.bOptmizeAlpha == true)
            {
                System.Drawing.Color pixel;
                for (int x = 0; x < tmpBmp.Width; x++)
                for (int y = 0; y < tmpBmp.Height; y++)
                {
                    pixel = tmpBmp.GetPixel(x, y);
                    int r, g, b, a, Result = 0;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    a = pixel.A;
                    Result = Math.Max(Math.Max(r * a / 255, g * a / 255), b * a / 255);
                    dest.SetPixel(x, y, System.Drawing.Color.FromArgb(Result, 255, 255, 255));

                }
            }
            else
            {
                dest = tmpBmp;
            }
            dest.Save(args[2]);
            dest.Dispose();
            tmpBmp.Dispose();
            System.Console.WriteLine("完成渲染:"+args[2]);
        }
    }
}
