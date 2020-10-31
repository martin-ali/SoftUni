CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
    DECLARE @wordIsComprised BIT = 1
    DECLARE @index INT = 1;

    WHILE @index <= LEN(@word)
    BEGIN
        DECLARE @character CHAR = substring(@word, @index, 1)
        DECLARE @characterIndex INT = CHARINDEX(@character, @setOfLetters);

        IF @characterIndex <= 0 BEGIN
            SET @wordIsComprised = 0;
            BREAK;
        END

        SET @index += 1
    END

    RETURN @wordIsComprised
END