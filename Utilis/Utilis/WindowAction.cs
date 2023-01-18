using System.Drawing;
using System.Diagnostics;
using System;

namespace Utilis
{
    public class WindowAction
    {
        /// <summary>
        /// 指定プロセスをウィンドウのサイズ、位置指定して開く
        /// </summary>
        /// <param name="proc">プロセス</param>
        /// <param name="winPosotion">始点座標</param>
        /// <param name="winWidth">ウィンドウの幅</param>
        /// <param name="winHeight">ウィンドウの高さ</param>
       public static void OpenProcess(Process proc, Point winPosotion, int winWidth, int winHeight)
        {
            //プロセススタート
            proc.Start();

            //待機状態まで待つ
            proc.WaitForInputIdle();

            //プロセスを移動させる
            NativeMethods.MoveWindow(proc.MainWindowHandle, winPosotion.X, winPosotion.Y, winWidth,winHeight, 1);
        }

        /// <summary>
        /// 指定ウィンドウを移動とサイズ変更させる
        /// </summary>
        /// <param name="hwnd">ウィンドウハンドル</param>
        /// <param name="winPosotion">始点座標</param>
        /// <param name="winWidth">ウィンドウの幅</param>
        /// <param name="winHeight">ウィンドウの高さ</param>
        public static void MoveWPorcWindow(IntPtr hwnd, Point winPosotion, int winWidth, int winHeight)
        {
            //プロセスを移動させる
            NativeMethods.MoveWindow(hwnd, winPosotion.X, winPosotion.Y, winWidth, winHeight, 1);
        }

        /// <summary>
        /// 指定プロセスをアクティウィンドウに変更
        /// </summary>
        /// <param name="proc">プロセス</param>
        public static void SetProcActiveWindow(Process proc)
        {
            NativeMethods.SetForegroundWindow(proc.MainWindowHandle);
        }

        /// <summary>
        /// 指定プロセスを場所、サイズを指定してアクティブウィンドウに変更
        /// </summary>
        /// <param name="proc">プロセス</param>
        /// <param name="winPosotion">始点座標</param>
        /// <param name="winWidth">ウィンドウの幅</param>
        /// <param name="winHeight">ウィンドウの高さ</param>
        public static void SetProcActiveWindow(Process proc, Point winPosotion, int winWidth, int winHeight)
        {
            NativeMethods.SetForegroundWindow(proc.MainWindowHandle);

            //待機状態まで待つ
            proc.WaitForInputIdle();

            //プロセスを移動させる
            NativeMethods.MoveWindow(proc.MainWindowHandle, winPosotion.X, winPosotion.Y, winWidth, winHeight, 1);
        }
    }
}
