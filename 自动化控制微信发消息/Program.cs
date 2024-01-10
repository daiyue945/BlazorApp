using NetAutoGUI;
namespace 自动化控制微信发消息
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //查找窗口是否正在运行
            ////系统自带的应用程序名称不需要写路径，如果是后面自己安装的应用则需要加上路径
            //if(GUI.Application.IsApplicationRunning("notepad.exe"))
            //{
            //    Console.WriteLine("已启动运行");
            //}
            //else
            //{
            //    GUI.Application.LaunchApplication("notepad.exe");
            //}

            //根据窗口标题查找窗口
            //如果没找到就是null，找到了就指向实际窗口
            //Window? w = GUI.Application.FindWindowByTitle("微信");
            //if (w!=null)
            //{
            //    Console.WriteLine("没找到微信");
            //}
            //else
            //{
            //    Console.WriteLine("找到微信");
            //}

            //根据窗口标题模糊匹配查找窗口
            //Window? w2 = GUI.Application.FindWindowLikeTitle("记事本");
            //if (w2 != null)
            //{
            //    Console.WriteLine("没找到记事本");
            //}
            //else
            //{
            //    Console.WriteLine("找到记事本");
            //}


            // GUI.Application.KillProcesses("execl");//结束所有记事本进程
            // GUI.Application.LaunchApplication("C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\EXCEL.EXE");//启动记事本
            // //设定在1秒内等待窗口出现，找不着报错，
            // Window? w3=GUI.Application.WaitForWindowByTitle("Execl",1);
            //// Window? w3 = GUI.Application.FindWindowLikeTitle("Execl");
            // if (w3 != null)
            // {
            //     Console.WriteLine("没找到Execl");
            // }
            // else
            // {
            //     Console.WriteLine("找到Execl");
            // }

            //查找记事本窗口
            //Window win = GUI.Application.WaitForWindowLikeTitle("*记事本");
            ////win.Id//PInvoke，Win32 扩展句柄，可进行其他操作
            //win.Activate();//激活
            //win.Maximize();//最大化
            //常规Win32程序，指定菜单定向操作
            //win.GetMainMenu().编辑.粘贴();
            //win.GetMainMenu().编辑.时间日期();
            //win.GetMainMenu().格式.自动换行();
            //win.GetMainMenu().格式.字体();
            //for (int y = 50; y <= 300; y++)
            //{
            //    win.MoveMouseTo(50, y);//移动鼠标
            //    Thread.Sleep(10);
            //}

            //win.MoveMouseTo(100, 150);
            //win.DoubleClick(100,150);//双击选中
            //win.Click(button:MouseButtonType.Right);//点击右键
            Wechat w = new Wechat();
            w.DOWechat();
        }
    }
}