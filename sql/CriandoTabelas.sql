BEGIN
BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"__EFMigrationsHistory" (
    "MigrationId" NVARCHAR2(150) NOT NULL,
    "ProductVersion" NVARCHAR2(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
)';
END;
EXCEPTION
WHEN OTHERS THEN
    IF(SQLCODE != -942)THEN
        RAISE;
    END IF;
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"Fornecedor" (
    "ID" RAW(16) NOT NULL,
    "Nome" varchar(200) NOT NULL,
    "Documento" varchar(14) NOT NULL,
    "TipoFornecedor" NUMBER(10) NOT NULL,
    "Ativo" NUMBER(1) NOT NULL,
    CONSTRAINT "PK_Fornecedor" PRIMARY KEY ("ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"Endereco" (
    "ID" RAW(16) NOT NULL,
    "FornecedorId" RAW(16) NOT NULL,
    "Logradouro" varchar(200) NOT NULL,
    "Numero" varchar(50) NOT NULL,
    "Complemento" varchar(250) NOT NULL,
    "Cep" varchar(8) NOT NULL,
    "Bairro" varchar(100) NOT NULL,
    "Cidade" varchar(100) NOT NULL,
    "Estado" varchar(100) NOT NULL,
    CONSTRAINT "PK_Endereco" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_Endereco_Fornecedor_FornecedorId" FOREIGN KEY ("FornecedorId") REFERENCES "Fornecedor" ("ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"Produtos" (
    "ID" RAW(16) NOT NULL,
    "FornecedorId" RAW(16) NOT NULL,
    "Nome" varchar(200) NOT NULL,
    "Descricao" varchar(100) NOT NULL,
    "Imagem" varchar(100) NOT NULL,
    "Valor" DECIMAL(18, 2) NOT NULL,
    "DataCadastro" TIMESTAMP(7) NOT NULL,
    "Ativo" NUMBER(1) NOT NULL,
    CONSTRAINT "PK_Produtos" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_Produtos_Fornecedor_FornecedorId" FOREIGN KEY ("FornecedorId") REFERENCES "Fornecedor" ("ID")
)';
END;
/

CREATE UNIQUE INDEX "IX_Endereco_FornecedorId" ON "Endereco" ("FornecedorId")
/

CREATE INDEX "IX_Produtos_FornecedorId" ON "Produtos" ("FornecedorId")
/

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES (N'20190808193339_Initial', N'2.2.6-servicing-10079')
/

