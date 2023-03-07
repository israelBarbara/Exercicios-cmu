-- d) Liste o nome e o estoque de todos os produtos, no dia 31/12/2022 (Dica: Use "LEFT JOIN").


SELECT P.Nome, T.QUANTIDADE AS ESTOQUE FROM PRODUTO P
LEFT JOIN Transacao T ON T.IdProduto = P.IdProduto
WHERE CONVERT(VARCHAR(10), T.DATA, 103) = '31/12/2022'

--OBSERVACAO: No Insert original não possui nenhuma Data '2022-12-31', portanto vai retornar vazio 

-- INSIRA SEU SQL AQUI ⬆⬆⬆