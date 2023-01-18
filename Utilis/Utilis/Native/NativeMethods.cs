using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Utilis
{
    /// <summary>
    /// Win32Api関数宣言クラス
    /// </summary>
    internal class NativeMethods
    {
        ///-------------------------
        ///定数宣言部
        ///-------------------------

        
        /// <summary>
        /// コピー元の四角形をコピー先の四角形に直接コピーします
        /// 定数
        /// </summary>
        public const int SRCCOPY = 13369376;
        /// <summary>
        /// ウィンドウの見た目通りのRectを取得
        /// 定数
        /// </summary>
        public const int DWMWA_EXTENDED_FRAME_BOUNDS = 9;


        ///-------------------------
        ///関数宣言部
        ///-------------------------

        /// <summary>
        /// 指定されたウィンドウのクライアント領域または画面全体のデバイス コンテキスト (DC) へのハンドルを取得します
        /// </summary>
        /// <param name="hwnd">DC を取得するウィンドウへのハンドル</param>
        /// <returns>戻り値は、指定されたウィンドウのクライアント領域の DC へのハンドル</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        /// <summary>
        /// 指定したソース デバイス コンテキストからターゲット デバイス コンテキストへの
        /// ピクセルの四角形に対応するカラー データのビット ブロック転送を実行します
        /// </summary>
        /// <param name="hDestDC">ターゲットデバイスコンテキストのハンドル</param>
        /// <param name="x">コピー先四角形の左上 x 座標</param>
        /// <param name="y">コピー先四角形の左上 y 座標</param>
        /// <param name="nWidth">ソースと宛先の四角形の幅</param>
        /// <param name="nHeight">ソースと宛先の四角形の高さ</param>
        /// <param name="hSrcDC">ソース デバイス コンテキストへのハンドル</param>
        /// <param name="xSrc">ソース四角形の左上隅の x 座標</param>
        /// <param name="ySrc">ソース四角形の左上隅の y 座標</param>
        /// <param name="dwRop">ラスター演算コード</param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern int BitBlt(
            IntPtr hDestDC,
            int x, 
            int y, 
            int nWidth, 
            int nHeight,
            IntPtr hSrcDC, 
            int xSrc, 
            int ySrc, 
            int dwRop);

        /// <summary>
        /// デバイス コンテキスト (DC) を解放する
        /// </summary>
        /// <param name="hwnd">DC が解放されるウィンドウのハンドル</param>
        /// <param name="hdc">開放する DC へのハンドル</param>
        /// <returns>解放時 1 : 失敗時 0</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

        /// <summary>
        /// オブジェクトのレイアウトの制御
        /// Sequential　オブジェクトのメンバーは、アンマネージ メモリにエクスポートするときに表示される順番に従ってレイアウトされます
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left; public int top; public int right; public int bottom;
        }

        /// <summary>
        /// イトル バー、メニュー、スクロール バーなど、ウィンドウ全体のデバイス コンテキスト (DC) を取得します
        /// </summary>
        /// <param name="hwnd">取得するデバイス コンテキストを持つウィンドウへのハンドル</param>
        /// <returns>戻り値は、指定されたウィンドウのデバイス コンテキストへのハンドル</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);

        /// <summary>
        /// フォアグラウンド ウィンドウ (ユーザーが現在作業しているウィンドウ) へのハンドルを取得します
        /// </summary>
        /// <returns>戻り値は、前景ウィンドウへのハンドル</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// 指定したウィンドウの外接する四角形のサイズを取得します
        /// </summary>
        /// <param name="hwnd">ウィンドウへのハンドル</param>
        /// <param name="lpRect">ウィンドウの左上隅と右下隅の画面座標を受け取る RECT 構造体へのポインター</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        /// <summary>
        /// ウィンドウに適用された指定されたデスクトップ ウィンドウ マネージャー (DWM) 属性の現在の値を取得します
        /// </summary>
        /// <param name="hwnd">属性値の取得元となるウィンドウへのハンドル</param>
        /// <param name="dwAttribute">DWMWINDOWATTRIBUTE 列挙体の値として指定された、取得する値を示すフラグ</param>
        /// <param name="pvAttribute">属性の現在の値を受け取る値へのポインター</param>
        /// <param name="cbAttribute">pvAttribute パラメーターを介して受信される属性値のサイズ</param>
        /// <returns>関数が成功した場合は、S_OK を返します</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, out RECT pvAttribute, int cbAttribute);

        /// <summary>
        /// 指定したウィンドウの位置と寸法を変更します。 最上位レベルのウィンドウの場合、位置と寸法は画面の左上隅を基準とします。 
        /// 子ウィンドウの場合、親ウィンドウのクライアント領域の左上隅を基準とします。
        /// </summary>
        /// <param name="hwnd">ウィンドウハンドル</param>
        /// <param name="x">ウィンドウ左上頂点の x 座標</param>
        /// <param name="y">ウィンドウ左上頂点の y 座標</param>
        /// <param name="nWidth">ウィンドウの新しい幅</param>
        /// <param name="nHeight">ウィンドウの新しい高さ</param>
        /// <param name="bRepaint">ウィンドウを再描画するかどうか Bool型 </param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int MoveWindow(
            IntPtr hwnd, 
            int x, 
            int y,
            int nWidth, 
            int nHeight, 
            int bRepaint);

        /// <summary>
        /// 指定したウィンドウを作成したスレッドをフォアグラウンドに移動し、ウィンドウをアクティブにします
        /// </summary>
        /// <param name="hWnd">ウィンドウハンドル</param>
        /// <returns>移動失敗時 0 : 移動成功時 0 以外</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
