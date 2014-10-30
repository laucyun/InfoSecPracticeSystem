江西省信息安全大赛
------------------

比赛形式：
  * 网络预选赛：各参赛队伍在规定时间内登录指定的网站，以在线答题方式进行，比赛题型分为判断题、单选题和多选题。
  * 现场技能赛：以网络对抗、网络通关竞赛形式进行，采取包括攻防、对抗、突破内容的实战演练题目，可能涉及到注入、缓冲区溢出、嗅探、跨站、破解、加解密、信息隐藏等常用计算机对抗攻防手段。
 
本系统是整合往届网络预选赛的真题以及官方样题和题库，以在线答题方式进行，比赛题型分为判断题、单选题和多选题。并且随机编排答案顺序，将成为备赛选手的好系统。
 
本系统分为顺序练习、随机练习、模拟比赛、错题集等多个模块。请尽情的体验系统带给你的快乐吧~

环境
----

### 开发工具
  * Microsoft Visual Studio 2010
  * SQL Server 2008  
  * Adobe Dreamweaver

### 客户端
  * 各种浏览器
  
### 服务器端
  * SQL Server 2008
  * .NET 4.0
  * IIS 6.0
  * Windows Server 2008

环境配置
--------

### 数据库配置
  * 1、附加数据库到SQL Server 2008中，其目录为`.\Code\App_Data\InformationSecurity.mdf`。
  * 2、设置`InformationSecurity`数据库的用户名和密码。
  * 3、修改`.\Code\web.config`中`connectionStrings`属性，如下：

```C#
  <connectionStrings>
		<add name="ConnectionString" connectionString="Data Source=.;Initial Catalog=InformationSecurity;Persist Security Info=True;User ID=~~数据库用户名~~;Password=~~数据库密码~~" providerName="System.Data.SqlClient" />
	</connectionStrings>
```

### 部署网站
  * 1、控制面板 -> 程序和功能 -> 打开或关闭windows功能（左边） -> Internet信息服务。选中如下：
    ![安装IIS](https://github.com/liuker0x007/InfoSecPracticeSystem/blob/master/README/01.png)
  * 2、更改系统默认平台（默认是`.NET2.0`，要更改为`.NET4.0`）。
    ![更改系统默认平台](https://github.com/liuker0x007/InfoSecPracticeSystem/blob/master/README/02.png)
  * 3、控制面板 -> 管理工具 -> Internet信息服务（IIS）管理器 -> 添加网站（JX3Report）。默认端口号设为80。
    ![部署网站](https://github.com/liuker0x007/InfoSecPracticeSystem/blob/master/README/03.png)
  * 4、应用程序池 -> 添加应用程序池。
    ![修改应用程序池](https://github.com/liuker0x007/InfoSecPracticeSystem/blob/master/README/04.png)
    ![修改应用程序池](https://github.com/liuker0x007/InfoSecPracticeSystem/blob/master/README/05.png)
  * 5、点击“默认文档”，设置网站的默认文档。
    ![设置网站的默认文档](https://github.com/liuker0x007/InfoSecPracticeSystem/blob/master/README/06.png)
    ![设置网站的默认文档](https://github.com/liuker0x007/InfoSecPracticeSystem/blob/master/README/07.png)

### 域名配置
  * 把`.\Code\App_Code\Comman\settings.cs`中改成您的域名。

```C#
  string domain = "http://域名:端口号";   //eg.http://www.liuker.xyz，如果端口号是80则可以不用加端口号。
```

联系方式
--------

  * E-mail：lzq@liuker.xyz
  * QQ：2523417411
