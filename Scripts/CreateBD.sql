Create database ApiDDD

create table Cliente (
		Id int primary key identity (1,1),
		Nome varchar(255) not null,
		Sobrenome varchar(255) not null,
		Email varchar(255) not null,
		DataCadastro datetime not null,
		IsActive bit not null

)

create table Produto (
		Id int primary key identity (1,1),
		Nome varchar(255) not null,
		Valor Decimal(5,2) not null,
		Quantidade Int not null,
		IsDisponivel bit not null
)