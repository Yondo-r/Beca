create table Cliente
	(
		IdCliente smallint identity,
		Nome varchar(40) not null,
		Telefone varchar(10) null,
		Email varchar(40) null,
		primary key (IdCliente));

create table Produto
	(
		Id smallint identity,
		Nome varchar(40) not null,
		Preco money not null,
		Quantidade varchar(40) null,
		primary key (Id));

create table Pedido
	(
		Id smallint identity,
		IdCliente smallint not null References Cliente(IdCliente),
		IdProduto smallint not null References Produto(Id),
		Quantidade int
		primary key (Id));

		select * from Cliente;
		select * from Produto;
		select * from Pedido;

		select distinct Cliente.NomeCliente, Produto.NomeProduto, Pedido.Quantidade
		from Cliente, Produto, Pedido
		where Cliente.IdCliente = Pedido.IdCliente 
		and Produto.Id = Pedido.IdProduto;

		exec sp_rename 'Cliente.[Nome]', 'NomeCliente', 'column';
		exec sp_rename 'Produto.[Nome]', 'NomeProduto', 'column';

		drop table Produto;

		alter table Pedido add dataPedido datetime default getdate();

		alter table Pedido add StatusPagamento Bit;

		update Pedido set StatusPagamento = 0 where StatusPagamento is null;

		update Pedido set StatusPagamento = 1 where Id = @Id;

		select distinct Cliente.NomeCliente, Produto.NomeProduto, Pedido.Quantidade 
		from Cliente, Produto, Pedido 
		where Cliente.IdCliente = Pedido.IdCliente and Produto.Id = Pedido.IdProduto;

		alter table Pedido drop column StatusPagamento;

		select distinct Cliente.NomeCliente, Produto.Preco, Produto.NomeProduto, Pedido.Quantidade, dataPedido, Pedido.Id from Cliente, Produto, Pedido where Cliente.IdCliente = Pedido.IdCliente and Produto.Id = Pedido.IdProduto and Pedido.StatusPagamento = 0
		delete Pedido where dataPedido is null

		delete Pedido where Id=@Id



		delete Produto where Id = 7;