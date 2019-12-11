## 各种数据库连接字符串
```
　　<!--SQL Server-->
　　<!--<add key="SQLString" value="Database=MyData;Data Source=NICKYAN-PC;User Id=sa;Password=123123;"/>
　　<add key="DataDAL" value="RedGlovePermission.SQLServerDAL" />-->
 
　　<!--My SQL-->
　　<add key="SqlString" value="host=192.168.0.222;userid=root;password=123456;database=hr_db"/>    
　　<add key="DataDAL" value="RedGlovePermission.MySqlDAL" />
 
　　<!--Oracle-->
　　<add key="SqlString" value="Data Source=NICKYAN-PC;User Id=PB_DB_USER;Password=123123;Integrated Security=no"/>    
　　<add key="DataDAL" value="RedGlovePermission.OracleDAL" />
 
　　<!--OleDB-->
　　<add key="SQLString" value="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=RedGlovePermission.Web\DB\MyData.mdb;Persist Security Info=False"/>
　　<add key="DataDAL" value="RedGlovePermission.OleDBDAL" />
 
```
