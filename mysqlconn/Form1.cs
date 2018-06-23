using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace mysqlconn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region  建立MySql数据库连接
        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回MySqlConnection对象</returns>
        public MySqlConnection getmysqlcon()
        {
            string M_str_sqlcon = "server=85.10.205.173:3306;user id=mengydz;password=Yangyes211;database=mengydz"; //根据自己的设置
            MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
            return myCon;
        }
        #endregion

        #region  执行MySqlCommand命令
        /// <summary>
        /// 执行MySqlCommand
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        public void getmysqlcom(string M_str_sqlstr)
        {
            MySqlConnection mysqlcon = this.getmysqlcon();
            mysqlcon.Open();
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);
            mysqlcom.ExecuteNonQuery();
            mysqlcom.Dispose();
            mysqlcon.Close();
            mysqlcon.Dispose();
        }
        #endregion

        #region  创建MySqlDataReader对象
        /// <summary>
        /// 创建一个MySqlDataReader对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <returns>返回MySqlDataReader对象</returns>
        public MySqlDataReader getmysqlread(string M_str_sqlstr)
        {
            MySqlConnection mysqlcon = this.getmysqlcon();
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);
            mysqlcon.Open();
            MySqlDataReader mysqlread = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            return mysqlread;
        }
        #endregion

        private void btn_conn_Click(object sender, EventArgs e)
        {
            string constructorString = "server=db4free.net;User Id=mengydz;password=Yangyes211;Database=mengydz";
            MySqlConnection myConnnect = new MySqlConnection(constructorString);
            myConnnect.Open();
            MySqlCommand myCmd = new MySqlCommand("insert into mupdate(value) values('优化了启动响应，增加了拍照，解决了一些已知问题')", myConnnect);
            if (myCmd.ExecuteNonQuery() > 0)
            {
                //MessageBox.Show("sucess");
            }
            myCmd.Dispose();
            myConnnect.Close();
        }

        private void btn_seach_Click(object sender, EventArgs e)
        {
            string constructorString = "server=db4free.net;User Id=mengydz;password=Yangyes211;Database=mengydz";
            MySqlConnection myConnnect = new MySqlConnection(constructorString);
            myConnnect.Open();
            MySqlCommand myCmd = new MySqlCommand("SELECT value FROM `mupdate`", myConnnect);
            MySqlDataReader reader = null;
            reader = myCmd.ExecuteReader();
            while (reader.Read())
            {
                MessageBox.Show(reader[0].ToString());
            }

            myCmd.Dispose();
            myConnnect.Close();
        }

    }
}
