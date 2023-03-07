-- e) Liste o nome, o estoque mínimo e o estoque atual de todos os produtos, cujo estoque atual está abaixo do estoque mínimo (Dica: Use "HAVING").


SELECT P.Idproduto,P.Nome, P.EstoqueMinimo,
isnull(SUM(T.Quantidade),0) AS EstoqueAtual
FROM PRODUTO P
LEFT JOIN Transacao T ON T.IdProduto = P.IdProduto
GROUP BY P.IdProduto,P.EstoqueMinimo,P.Nome
HAVING isnull(SUM(T.Quantidade),0) < P.EstoqueMinimo


-- INSIRA SEU SQL AQUI ⬆⬆⬆