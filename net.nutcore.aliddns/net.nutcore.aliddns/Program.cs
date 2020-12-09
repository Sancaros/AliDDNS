using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace net.nutcore.aliddns
{
    static class Program
    {
        //static bool checkUpdate; //用于检测是否自动升级
        static System.Threading.Mutex _mutex; //定义为类变量，而非局部变量，用于检测线程
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //设定是否可以打开新进程的判断参数
            bool isNew;

            //获取程序集Guid作为唯一标识
            Attribute guid_attr = Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(GuidAttribute));
            string guid = ((GuidAttribute)guid_attr).Value; //此时guid对当前登录用户生效，当声明为Global时，对所有用户有效
            _mutex = new System.Threading.Mutex(true, guid, out isNew);
            if ( isNew ) //没有重复进程时
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form_main());
            }
            else
            {
                MessageBox.Show("本程序已经在运行中！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //_mutex.ReleaseMutex();
        }
    }
}
