CREATE procedure [dbo].[GetTransCategoriesByDept]
(
	@year int,
	@deptid int = null,
	@fundcategory varchar(10) = null,
	@staffid int = null
)
as
begin
	select C.Category as [Category], isnull(F.Amount, 0) as [Amount]
	from (
		values (1), (2), (3), (4), (5), 
				(6), (7), (8), (9), (10), (11), (12)
	) [MonthList](Months)
	Left Join (
		select case when @fundcategory is null then FundCategory else FundCodeName end as [Category]
		from Transactions, Funding_Sources
		where (@deptid is null or DeptID = @deptid) and Transactions.FundMasterID = Funding_Sources.FundMasterID and 
			(@fundcategory is null or FundCategory like '%' + @fundcategory + '%') and
			(@staffid is null or StaffID = @staffid) and datepart(year, TransDate) = @year
		group by case when @fundcategory is null then FundCategory else FundCodeName end
	) C on C.Category is not null
	Left Join (
		select datepart(month, TransDate) as [Month],case when @fundcategory is null then FundCategory else FundCodeName end as [Category], 
			Sum(TransAmount) as [Amount]
		from Transactions, Funding_Sources
		where (@deptid is null or DeptID = @deptid) and Transactions.FundMasterID = Funding_Sources.FundMasterID and 
			(@fundcategory is null or FundCategory like '%' + @fundcategory + '%') and
			(@staffid is null or StaffID = @staffid) and datepart(year, TransDate) = @year
		group by case when @fundcategory is null then FundCategory else FundCodeName end, datepart(month, TransDate)
	) F on F.[Month] = [Months] and F.Category = C.Category 
	order by Months
end