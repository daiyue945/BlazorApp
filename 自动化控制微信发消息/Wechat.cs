using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetAutoGUI;
namespace 自动化控制微信发消息
{
    public class Wechat
    {
        public void DOWechat()
        {
            Window? win = GUI.Application.FindWindowByTitle("微信");
            if (win == null)
            {
                //如果微信窗口没打开，则在整个屏幕搜索微信图标，桌面不能有微信图标，否则会打不开
                Rectangle? rectWXIcon = GUI.Screenshot.LocateOnScreen("WechatIcon.png");
                if (rectWXIcon == null)
                {
                    Console.WriteLine("微信托盘图标未找到！");
                    return;
                }
                //如果在右下角托盘图表中找到了就点击微信图标，直接用X轴会导致鼠标焦点偏移点击托盘，X+5是直接点击微信
                GUI.Mouse.Click(rectWXIcon.X+5, rectWXIcon.Y);
                win = GUI.Application.WaitForWindowByTitle("微信");//等待微信窗口出现
            }
            else
            {
                //激活应用
                win.Activate();
            }
            win.WaitAndClick("Search.png",0.6);
            GUI.Keyboard.Write("文件传输助手");
            Thread.Sleep(1000);
            GUI.Keyboard.Press(VirtualKeyCode.RETURN);
            Thread.Sleep(1000);
            GUI.Keyboard.Write($"现在时间:{DateTime.Now}");
            GUI.Keyboard.Press(VirtualKeyCode.RETURN);

            Thread.Sleep(1000);

            win.WaitAndClick("Search.png", 0.6);
            GUI.Keyboard.Write("吴敏");
            Thread.Sleep(1000);
            GUI.Keyboard.Press(VirtualKeyCode.RETURN);
            Thread.Sleep(1000);
            GUI.Keyboard.Write($"忽略，忽略，测试测试，现在时间:{DateTime.Now}");
            GUI.Keyboard.Press(VirtualKeyCode.RETURN);
            //等待窗口中指定内容出现，然后点击
            //win.WaitAndClick("smile.png");
            //模拟键盘输入，要控制鼠标焦点在想输入的框里面
            //GUI.Keyboard.Write("你好");
            //模拟键盘输入，输入文字每个间隔一秒
            //GUI.Keyboard.Write("你好,你今天要去哪里?",1);
            //按键
            //GUI.Keyboard.KeyDown(VirtualKeyCode.VK_H);
            //GUI.Keyboard.KeyDown(VirtualKeyCode.INSERT);
            //GUI.Keyboard.HotKey(VirtualKeyCode.CONTROL,VirtualKeyCode.VK_V);//组合按键
            //GUI.Keyboard.KeyDown(VirtualKeyCode.RETURN);//Enter键
        }
    }
}
