//1、初始化迁移记录 Init 自定义
Add-Migration Init

//2、将当前 Init 的迁移记录更新到数据库
update-database Init 

//多个数据上下文需要制定上下文名称 
-c Context上下文名称