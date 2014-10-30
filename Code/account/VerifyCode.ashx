<%@ WebHandler Language="C#" Class="VerifyCode" %>


using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Drawing;
using System.Web.SessionState;

public class VerifyCode : IHttpHandler, IRequiresSessionState
{
    private string CreateCheckCodeString()
    { //定义用于验证码的字符数组
        char[] AllCheckCodeArray ={'2','3','4','5','6','7','8',
            'A','B','C','D','E','F','G','H','J','K','L','M','N','P','Q','R','S','T','U','V','W',
            'X','Y','a','b','c','d','e','f','g','h','i','j','k','m','n','p','q',
            'r','s','t','u','v','w','x','y'};
        //定义验证码字符串
        string randomcode = "";
        Random rd = new Random();
        //生成5位验证码字符串
        for (int i = 0; i < 5; i++)
            randomcode += AllCheckCodeArray[rd.Next(AllCheckCodeArray.Length)];
        return randomcode;
    }
    public Color getColor()
    {
        // 自定义随机颜色数组
        Color[] colors = { Color.Red,Color.LightSalmon, Color.LightSeaGreen, Color.Magenta,
                Color.MediumSeaGreen, Color.SeaGreen, Color.Teal, Color.Tomato, Color.Coral,
                Color.CornflowerBlue, Color.DarkGreen, Color.DarkSalmon, Color.ForestGreen,
                Color.Goldenrod, Color.Gray, Color.Green,Color.Blue,Color.BlueViolet };
        Random rand = new Random();
        Color cl = colors[rand.Next(0, colors.Length)];
        return cl;
    }
    public string getFonts()
    {
        //自定义字体数组
        string[] fonts = { "宋体", "sans-serif" };
        Random rand = new Random();
        string font = fonts[rand.Next(0, fonts.Length)];
        return font;
    }

    public void ProcessRequest(HttpContext context)
    {
        //定义图片的宽度
        int ImageWidth = 100;
        //定义图片高度
        int ImageHeigh = 32;
        //定义字体，用于绘制文字
        Font font = new Font(getFonts(), 18, FontStyle.Bold);
        //定义画笔，用于绘制文字
        Color colors = getColor();
        Brush brush = new SolidBrush(colors);
        //定义钢笔，用于绘制干扰线
        Pen pen = new Pen(getColor(), 0);//这里也可以直接获得一个现有的color对象如：Color.Gold.我是为了美观所以定义和下面一样
        //创建一个图像
        Bitmap BitImage = new Bitmap(ImageWidth, ImageHeigh);
        //从图像获取一个绘画面
        Graphics graphics = Graphics.FromImage(BitImage);
        //清除整个绘图画面并用颜色填充
        graphics.Clear(ColorTranslator.FromHtml("#f7f7f7"));//这里从HTML代码获取color对象
        //定义文字的绘制矩形区域
        RectangleF rect = new RectangleF(5, 2, ImageWidth, ImageHeigh);
        //定义一个随机数对象，用于绘制干扰线
        Random rand = new Random();
        //生成两条横向的干扰线
        for (int i = 0; i < 2; i++)
        {
            //定义起点
            Point p1 = new Point(0, rand.Next(ImageHeigh));
            //定义终点
            Point p2 = new Point(ImageWidth, rand.Next(ImageHeigh));
            //绘制直线
            graphics.DrawLine(pen, p1, p2);
        }
        //生成两条纵向的干扰线
        for (int i = 0; i < 2; i++)
        {
            //定义起点
            Point p1 = new Point(rand.Next(ImageWidth), 0);
            //定义终点
            Point p2 = new Point(rand.Next(ImageWidth), ImageHeigh);
            //绘制直线
            graphics.DrawLine(pen, p1, p2);
        }
        //绘制验证码文字
        string checkCode = CreateCheckCodeString();
        graphics.DrawString(checkCode, font, brush, rect);
        //保存图片为gif格式
        BitImage.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
        //释放对象
        graphics.Dispose();
        BitImage.Dispose();
        //context.Session["CheckCode"] = checkCode;//使用cookie存储验证码 
        string[,] array = new string[1, 2];
        array[0, 0] = "CheckCode";
        array[0, 1] = checkCode;
        new Commom.SetCookie().CreateCookie("verifycode", 0, 0, 10, 0, array);
        context.Response.Write(checkCode);
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
} 