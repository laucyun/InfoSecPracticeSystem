using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Commom
{
    public class dateConversion
    {
        public DataSet getTihaoData(DataSet ds)
        {
            DataSet newds = new DataSet();
            DataTable dt = new DataTable();
            //为dt中增加列
            for (int i = 1; i <= 25; i++)
            {
                dt.Columns.Add("tihao" + i, typeof(string));//ID
                dt.Columns.Add("timuId" + i, typeof(string));//操作者
            }

            int totalNum = ds.Tables[0].Rows.Count;//总记录数
            int newRowsNum = 0;//新行数
            if ((totalNum % 25) > 0)
            {
                newRowsNum = (totalNum / 25) + 1;
            }
            else
            {
                newRowsNum = totalNum / 25;
            }

            for (int m = 0; m < newRowsNum; m++)
            {
                DataRow dr = dt.NewRow();//增加行
                if (m == newRowsNum - 1)
                {
                    for (int n = 25 * m; n < totalNum; n++)
                    {
                        int nid = (n % 25) + 1;
                        dr["tihao" + nid] = n + 1;
                        dr["timuId" + nid] = ds.Tables[0].Rows[n]["nc_qid"].ToString();
                    }
                }
                if (m < newRowsNum - 1)
                {
                    for (int n = 25 * m; n < 25 * (m + 1); n++)
                    {
                        int nid = (n % 25) + 1;
                        dr["tihao" + nid] = n + 1;
                        dr["timuId" + nid] = ds.Tables[0].Rows[n]["nc_qid"].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            newds.Tables.Add(dt);
            return newds;
        }




    }
}