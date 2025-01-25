using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mathExpression.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Criar a stored procedure EvaluateMathExpressionSP
            migrationBuilder.Sql(@"
            -- Stored Procedure para avaliar uma expressão matemática.
            -- Esta procedure substitui as referências a sensores pelos seus valores correspondentes
            -- e retorna o resultado da avaliação da expressão.
            CREATE PROCEDURE dbo.EvaluateMathExpressionSP
                @ExpressionId INT,
                @Result DECIMAL(18, 2) OUTPUT
            AS
            BEGIN
                DECLARE @Expression NVARCHAR(MAX);
    
                -- Obter a expressão
                SELECT @Expression = Expression
                FROM MathExpressions
                WHERE Id = @ExpressionId;

                -- Se a expressão não for encontrada, retornar NULL
                IF @Expression IS NULL
                BEGIN
                    SET @Result = NULL;
                    RETURN;
                END

                -- Substituir S1, S2, etc. pelos valores dos sensores
                DECLARE @SensorValue NVARCHAR(MAX);
    
                -- Loop para substituir os sensores na expressão
                DECLARE @SensorId INT;
    
                -- Obter os IDs dos sensores associados à expressão
                DECLARE SensorCursor CURSOR FOR 
                    SELECT SensorId 
                    FROM MathExpressionSensors 
                    WHERE MathExpressionId = @ExpressionId;

                OPEN SensorCursor;
                FETCH NEXT FROM SensorCursor INTO @SensorId;

                WHILE @@FETCH_STATUS = 0
                BEGIN
                    -- Obter o valor do sensor correspondente
                    SELECT @SensorValue = CAST(Value AS NVARCHAR)
                    FROM Sensors 
                    WHERE Id = @SensorId;

                    -- Substituir na expressão
                    SET @Expression = REPLACE(@Expression, 'S' + CAST(@SensorId AS NVARCHAR), @SensorValue);

                    FETCH NEXT FROM SensorCursor INTO @SensorId;
                END

                CLOSE SensorCursor;
                DEALLOCATE SensorCursor;

                -- Avaliar a expressão usando sp_executesql
                DECLARE @Sql NVARCHAR(MAX) = N'SET @Result = ' + @Expression;
    
                EXEC sp_executesql @Sql, N'@Result DECIMAL(18,2) OUTPUT', @Result OUTPUT;
            END;
        ");

            // Criar a stored procedure ListMathExpressionsWithValues
            migrationBuilder.Sql(@"
            -- Stored Procedure para listar todas as expressões matemáticas com seus resultados.
            -- Esta procedure itera por todas as expressões armazenadas e retorna uma lista com os IDs,
            -- expressões e resultados calculados usando a stored procedure EvaluateMathExpressionSP.
            CREATE PROCEDURE dbo.ListMathExpressionsWithValues
            AS
            BEGIN
                SET NOCOUNT ON;

                DECLARE @ExpressionId INT;
                DECLARE @Result DECIMAL(18, 2);
                DECLARE @Expression NVARCHAR(MAX);

                -- Cria uma tabela temporária para armazenar os resultados
                CREATE TABLE #Results (
                    ExpressionId INT,
                    Expression NVARCHAR(MAX),
                    Result DECIMAL(18, 2)
                );

                -- Cursor para iterar sobre todas as expressões
                DECLARE ExpressionCursor CURSOR FOR 
                    SELECT Id, Expression 
                    FROM MathExpressions;

                OPEN ExpressionCursor;
                FETCH NEXT FROM ExpressionCursor INTO @ExpressionId, @Expression;

                WHILE @@FETCH_STATUS = 0
                BEGIN
                    -- Chama o procedimento para avaliar a expressão
                    EXEC dbo.EvaluateMathExpressionSP @ExpressionId, @Result OUTPUT;

                    -- Insere o resultado na tabela temporária
                    INSERT INTO #Results (ExpressionId, Expression, Result)
                    VALUES (@ExpressionId, @Expression, @Result);

                    FETCH NEXT FROM ExpressionCursor INTO @ExpressionId, @Expression;
                END

                CLOSE ExpressionCursor;
                DEALLOCATE ExpressionCursor;

                -- Seleciona os resultados finais
                SELECT * FROM #Results;

                -- Limpa a tabela temporária
                DROP TABLE #Results;
            END;
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover as stored procedures se necessário.
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.EvaluateMathExpressionSP;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.ListMathExpressionsWithValues;");
        }
    }
}
