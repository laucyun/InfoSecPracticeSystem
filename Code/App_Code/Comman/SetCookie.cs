using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Model;

namespace Commom
{
    public class SetCookie
    {
        /// 创建Cookie
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <param name="d">Cookie时间中的天数</param>
        /// <param name="h">Cookie时间中的时</param>
        /// <param name="m">Cookie时间中的分</param>
        /// <param name="s">Cookie时间中的秒</param>
        /// <param name="array">数据 二维数组(定义方法：string[,] array = new string[3,2])</param>
        public void CreateCookie(string cookieName, int d, int h, int m, int s, string[,] array)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            TimeSpan ts = new TimeSpan(d, h, m, s);//天 时 分 秒
            DateTime dt = DateTime.Now;
            cookie.Expires = dt.Add(ts);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                cookie[array[i, 0]] = array[i, 1];
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        }



        /// <summary>
        /// 判断是否在线
        /// </summary>
        /// <returns></returns>
        public string WhetherOnline()
        {
            string userid = null;
            HttpCookie cookies = HttpContext.Current.Request.Cookies["ISAccountCookie"];
            if (cookies != null)
            {
                string uname = cookies["username"].ToString();
                string upwd = cookies["userpwd"].ToString();
                string isAutoLogin = cookies["isAutoLogin"].ToString();
                int uright = int.Parse(cookies["uright"].ToString());
                string uid = cookies["uid"].ToString();
                yonghuModel yhm = new yonghuDAL().GetModelByUsername(uname);

                #region 验证是否该用户 作用：防止黑客通过Cookie入侵
                string uid2 = new MD5Encrypt().GetMD5(yhm.nvc_username + yhm.nc_uid);
                if (uid == uid2 && uright == yhm.int_right)
                {
                    #region 验证密码
                    string pwd2 = new MD5Encrypt().GetMD5(upwd + yhm.nvc_username);
                    if (pwd2 == yhm.nvc_pwd)
                    {
                        userid = yhm.nc_uid;
                    }
                    else
                    {
                        HttpContext.Current.Response.Write("<script>javascript:alert('请登录！原因：您的密码已过期。');top.location.replace('../account/login.aspx');</script>");
                    }
                    #endregion
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>javascript:alert('请登录！原因：您未登录。');top.location.replace('../account/login.aspx');</script>");
                }
                #endregion
            }
            else
            {
                HttpContext.Current.Response.Write("<script>javascript:alert('请登录！原因：您未登录。');top.location.replace('../account/login.aspx');</script>");
            }
            return userid;
        }

    }
}