SELECT products.product_name AS [Product], categories.category_name AS [Category]
FROM dbo.products
LEFT JOIN dbo.product_category ON dbo.products.product_id = dbo.product_category.product_id
LEFT JOIN dbo.categories ON dbo.product_category.category_id = dbo.categories.category_id;
