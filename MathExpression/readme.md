To execute the SPs in the database, you can use the following command:

**SP to show the result of a math expression by ID**  
DECLARE @Result DECIMAL(18, 2);
EXEC dbo.EvaluateMathExpressionSP 1, @Result OUTPUT; 
SELECT @Result AS Result;
 
**SP to list all the math expressions with their values**  
EXEC dbo.ListMathExpressionsWithValues;