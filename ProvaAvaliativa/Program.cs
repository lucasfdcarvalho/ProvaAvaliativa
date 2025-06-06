using System;
using ProvaAvaliativa;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Configurando e construindo o container de injeção com os serviços
IHost host = Host.CreateDefaultBuilder(args).ConfigureServices((context, service) =>
{
    // Registra um logger que será compartilhado como singleton(única)
    service.AddSingleton<ILogger, ConsoleLogger>();
    // Registra a fábrica de pedidos que injeta o ILogger no Pedido
    service.AddSingleton<IPedidoFactory, PedidoFactory>();
    // Registra o gerador de relatórios que injeta o ILogger
    service.AddSingleton<IRelatorioPedido, RelatorioPedido>();
}).Build();

// Iniciando os serviços resolvidos pelo container
ILogger logger = host.Services.GetRequiredService<ILogger>();
IPedidoFactory pedidoFactory = host.Services.GetRequiredService<IPedidoFactory>();
IRelatorioPedido relatorio = host.Services.GetRequiredService<IRelatorioPedido>();

// Criando o primeiro cliente e produto
Cliente cliente1 = new Cliente(25, "Lucas", "example@gmail.com", "22424432412");
Produto produto1 = new Produto(21, "Bicicleta", 500.5, "Veículo");
IDescontoStrategy descontoQtd = new DescontoPorQuantidade(2, 0.30);

Pedido pedido1 = pedidoFactory.CriarPedido(10, cliente1, descontoQtd);
pedido1.AdicionarItem(produto1, 3);

relatorio.AdicionarPedido(pedido1);

// Criando o segundo cliente e produto
Cliente cliente2 = new Cliente(23, "João", "example2@gmail.com", "12345678901");
Produto produto2 = new Produto(34, "Notebook", 2000.0, "Eletrônico");
IDescontoStrategy descontoCat = new DescontoPorCategoria("Eletrônico", 0.4);

Pedido pedido2 = pedidoFactory.CriarPedido(11, cliente2, descontoCat);
pedido2.AdicionarItem(produto2, 1);

relatorio.AdicionarPedido(pedido2);

// Gerando e exibindo o relatório final de todos os pedidos adicionados
relatorio.GerarRelatorio();
