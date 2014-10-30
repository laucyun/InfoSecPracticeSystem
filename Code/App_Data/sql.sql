
insert into [InformationSecurity].[dbo].[options] 
select * from Sheet1$



update Sheet1$ set bit_isright='false' where bit_isright='0'


select * from Sheet1$ where nvc_opcontent=NULL