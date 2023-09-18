CREATE TABLE test1 (
ID int,
productName text,
price money,
)

INSERT INTO test1 VALUES(1, 'chicken soup', 12.20)

SELECT * FROM test1

SELECT * FROM sysobjects WHERE name='test1'

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Stack')
CREATE TABLE Stack (
                stack_id int NOT NULL IDENTITY PRIMARY KEY,
                name nvarchar(50) NOT NULL)