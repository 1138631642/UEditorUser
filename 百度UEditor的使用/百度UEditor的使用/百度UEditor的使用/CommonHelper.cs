using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace 百度UEditor的使用
{
    public static class CommonHelper
    {
        #region MD5功能快
        //将一个字符串变成MD5格式
        public static string CalcMD5(this string str)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            return CalcMD5(bytes);
        }
        //将一个字节数组转化为MD5格式
        public static string CalcMD5(byte[] bytes)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(bytes);
                string result = "";
                for (int i = 0; i < computeBytes.Length; i++)
                {
                    result += computeBytes[i].ToString("X").Length == 1 ? "0" + computeBytes[i].ToString("X") : computeBytes[i].ToString("X");
                }
                return result;
            }
        }
        //将一个流转化为MD5
        public static string CalcMD5(Stream stream)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(stream);
                string result = "";
                for (int i = 0; i < computeBytes.Length; i++)
                {
                    result += computeBytes[i].ToString("X").Length == 1 ? "0" + computeBytes[i].ToString("X") : computeBytes[i].ToString("X");
                }
                return result;
            }
        }
        #endregion

        #region 随机验证码功能块
        public static string CreateVerifyCode(int len)
        {
            //定义随机验证码选取的范围数值
            char[] data = { 'a', 'c', 'd', 'e', 'f', 'g', 'k', 'm', 'p', 'r', 's', 't', 'w', 'x', 'y', '3', '4', '5', '7', '8' };
            Random r = new Random();
            //定义一个StringBuilder来存储生成的随机数
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                int index = r.Next(0, data.Length);
                sb.Append(data[index]);
            }
            return sb.ToString();
        }
        #endregion
    }
}