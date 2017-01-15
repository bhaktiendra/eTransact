IF NOT EXISTS(SELECT * FROM master.sys.databases WHERE name='PandawaTransaction')
BEGIN
	CREATE DATABASE PandawaTransaction
END;