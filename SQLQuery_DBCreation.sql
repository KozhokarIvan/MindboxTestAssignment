CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name NVARCHAR(50)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name NVARCHAR(50)
);

CREATE TABLE product_category (
    product_id INT,
    category_id INT,
    PRIMARY KEY (product_id, category_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

INSERT INTO categories (category_id, category_name) VALUES (1, N'Electronics');
INSERT INTO categories (category_id, category_name) VALUES (2, N'Clothing');
INSERT INTO categories (category_id, category_name) VALUES (3, N'Books');
INSERT INTO categories (category_id, category_name) VALUES (4, N'No products');
INSERT INTO categories (category_id, category_name) VALUES (5, N'Science');

INSERT INTO products (product_id, product_name) VALUES (1, N'Laptop');
INSERT INTO products (product_id, product_name) VALUES (2, N'T-shirt');
INSERT INTO products (product_id, product_name) VALUES (3, N'Smartphone');
INSERT INTO products (product_id, product_name) VALUES (4, N'Jeans');
INSERT INTO products (product_id, product_name) VALUES (5, N'Book 1');
INSERT INTO products (product_id, product_name) VALUES (6, N'Book 2');
INSERT INTO products (product_id, product_name) VALUES (7, N'No category');

INSERT INTO product_category (product_id, category_id) VALUES (1, 1);
INSERT INTO product_category (product_id, category_id) VALUES (2, 2);
INSERT INTO product_category (product_id, category_id) VALUES (3, 1);
INSERT INTO product_category (product_id, category_id) VALUES (4, 2);
INSERT INTO product_category (product_id, category_id) VALUES (5, 3);
INSERT INTO product_category (product_id, category_id) VALUES (6, 3);
INSERT INTO product_category (product_id, category_id) VALUES (6, 5);