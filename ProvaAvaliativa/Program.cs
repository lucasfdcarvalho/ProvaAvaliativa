using System;
using ProvaAvaliativa;


RelatorioPedido relatorio = new RelatorioPedido();

// Primeiro pedido: Lucas comprando 3 bicicletas com desconto por quantidade
Cliente cliente1 = new Cliente(25, "Lucas", "example@gmail.com", "22424432412");
Produto produto1 = new Produto(21, "Bicicleta", 500.5, "Veículo");
IDescontoStrategy descontoQtd = new DescontoPorQuantidade(2, 0.30);
IPedidoFactory pedidoFactory1 = new PedidoFactory();
Pedido pedido1 = pedidoFactory1.CriarPedido(10, cliente1, descontoQtd);
pedido1.AdicionarItem(produto1, 3);
relatorio.AdicionarPedido(pedido1);

// Segundo pedido: João comprando 1 notebook com desconto por categoria
Cliente cliente2 = new Cliente(23, "João", "example2@gmail.com", "12345678901");
Produto produto2 = new Produto(34, "Notebook", 2000.0, "Eletrônico");
IDescontoStrategy descontoCat = new DescontoPorCategoria("Eletrônico", 0.4);
IPedidoFactory pedidoFactory2 = new PedidoFactory();
Pedido pedido2 = pedidoFactory2.CriarPedido(11, cliente2, descontoCat);
pedido2.AdicionarItem(produto2, 1);
relatorio.AdicionarPedido(pedido2);

// Exibe relatório de todos os pedidos
relatorio.GerarRelatorio();