--
-- PostgreSQL database dump
--

-- Dumped from database version 17.1
-- Dumped by pg_dump version 17.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: publishing; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA publishing;


ALTER SCHEMA publishing OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: authors; Type: TABLE; Schema: publishing; Owner: postgres
--

CREATE TABLE publishing.authors (
    authorid integer NOT NULL,
    firstname text,
    lastname text,
    contactdetails text
);


ALTER TABLE publishing.authors OWNER TO postgres;

--
-- Name: TABLE authors; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON TABLE publishing.authors IS 'Таблица, хранящая информацию об авторах (может быть физическое лицо или организация)';


--
-- Name: COLUMN authors.authorid; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.authors.authorid IS 'Уникальный идентификатор автора';


--
-- Name: COLUMN authors.firstname; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.authors.firstname IS 'Имя автора';


--
-- Name: COLUMN authors.lastname; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.authors.lastname IS 'Фамилия автора';


--
-- Name: COLUMN authors.contactdetails; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.authors.contactdetails IS 'Контактные данные автора (электронная почта, телефон и т.д.)';


--
-- Name: authors_authorid_seq; Type: SEQUENCE; Schema: publishing; Owner: postgres
--

CREATE SEQUENCE publishing.authors_authorid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE publishing.authors_authorid_seq OWNER TO postgres;

--
-- Name: authors_authorid_seq; Type: SEQUENCE OWNED BY; Schema: publishing; Owner: postgres
--

ALTER SEQUENCE publishing.authors_authorid_seq OWNED BY publishing.authors.authorid;


--
-- Name: customers; Type: TABLE; Schema: publishing; Owner: postgres
--

CREATE TABLE publishing.customers (
    customerid integer NOT NULL,
    name text,
    type text,
    contactdetails text,
    representativeid integer
);


ALTER TABLE publishing.customers OWNER TO postgres;

--
-- Name: TABLE customers; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON TABLE publishing.customers IS 'Таблица, хранящая информацию о заказчиках (физическое лицо или организация)';


--
-- Name: COLUMN customers.customerid; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.customers.customerid IS 'Уникальный идентификатор заказчика';


--
-- Name: COLUMN customers.name; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.customers.name IS 'Имя заказчика (может быть физическое лицо или организация)';


--
-- Name: COLUMN customers.type; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.customers.type IS 'Тип заказчика: "Частное лицо" или "Организация"';


--
-- Name: COLUMN customers.contactdetails; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.customers.contactdetails IS 'Контактные данные заказчика (электронная почта, телефон и т.д.)';


--
-- Name: COLUMN customers.representativeid; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.customers.representativeid IS 'Если заказчик является организацией, это поле ссылается на представителя организации (если применимо)';


--
-- Name: customers_customerid_seq; Type: SEQUENCE; Schema: publishing; Owner: postgres
--

CREATE SEQUENCE publishing.customers_customerid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE publishing.customers_customerid_seq OWNER TO postgres;

--
-- Name: customers_customerid_seq; Type: SEQUENCE OWNED BY; Schema: publishing; Owner: postgres
--

ALTER SEQUENCE publishing.customers_customerid_seq OWNED BY publishing.customers.customerid;


--
-- Name: images; Type: TABLE; Schema: publishing; Owner: postgres
--

CREATE TABLE publishing.images (
    imageid integer NOT NULL,
    publicationid integer,
    imagetype text,
    imagepath text
);


ALTER TABLE publishing.images OWNER TO postgres;

--
-- Name: TABLE images; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON TABLE publishing.images IS 'Таблица, хранящая информацию о изображениях, связанных с публикациями (например, обложки книг)';


--
-- Name: COLUMN images.imageid; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.images.imageid IS 'Уникальный идентификатор изображения';


--
-- Name: COLUMN images.publicationid; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.images.publicationid IS 'Ссылка на публикацию, с которой связано изображение';


--
-- Name: COLUMN images.imagetype; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.images.imagetype IS 'Тип изображения (например, обложка, иллюстрация)';


--
-- Name: COLUMN images.imagepath; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.images.imagepath IS 'Путь к изображению (локальный путь или URL)';


--
-- Name: images_imageid_seq; Type: SEQUENCE; Schema: publishing; Owner: postgres
--

CREATE SEQUENCE publishing.images_imageid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE publishing.images_imageid_seq OWNER TO postgres;

--
-- Name: images_imageid_seq; Type: SEQUENCE OWNED BY; Schema: publishing; Owner: postgres
--

ALTER SEQUENCE publishing.images_imageid_seq OWNED BY publishing.images.imageid;


--
-- Name: orders; Type: TABLE; Schema: publishing; Owner: postgres
--

CREATE TABLE publishing.orders (
    orderid integer NOT NULL,
    customerid integer,
    producttypeid integer,
    quantity integer,
    orderdate date,
    status text
);


ALTER TABLE publishing.orders OWNER TO postgres;

--
-- Name: TABLE orders; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON TABLE publishing.orders IS 'Таблица, хранящая информацию о заказах клиентов';


--
-- Name: COLUMN orders.orderid; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.orders.orderid IS 'Уникальный идентификатор заказа';


--
-- Name: COLUMN orders.customerid; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.orders.customerid IS 'Ссылка на заказчика, который сделал заказ';


--
-- Name: COLUMN orders.producttypeid; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.orders.producttypeid IS 'Ссылка на тип продукции, заказанной клиентом';


--
-- Name: COLUMN orders.quantity; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.orders.quantity IS 'Количество заказанных единиц продукции';


--
-- Name: COLUMN orders.orderdate; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.orders.orderdate IS 'Дата размещения заказа';


--
-- Name: COLUMN orders.status; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.orders.status IS 'Текущий статус заказа (например, "В процессе", "Напечатано")';


--
-- Name: orders_orderid_seq; Type: SEQUENCE; Schema: publishing; Owner: postgres
--

CREATE SEQUENCE publishing.orders_orderid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE publishing.orders_orderid_seq OWNER TO postgres;

--
-- Name: orders_orderid_seq; Type: SEQUENCE OWNED BY; Schema: publishing; Owner: postgres
--

ALTER SEQUENCE publishing.orders_orderid_seq OWNED BY publishing.orders.orderid;


--
-- Name: producttypes; Type: TABLE; Schema: publishing; Owner: postgres
--

CREATE TABLE publishing.producttypes (
    producttypeid integer NOT NULL,
    name text,
    subtype text,
    price numeric(10,2)
);


ALTER TABLE publishing.producttypes OWNER TO postgres;

--
-- Name: TABLE producttypes; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON TABLE publishing.producttypes IS 'Таблица, хранящая различные типы продукции (например, книга, брошюра и т.д.)';


--
-- Name: COLUMN producttypes.producttypeid; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.producttypes.producttypeid IS 'Уникальный идентификатор типа продукции';


--
-- Name: COLUMN producttypes.name; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.producttypes.name IS 'Название типа продукции (например, книга, брошюра)';


--
-- Name: COLUMN producttypes.subtype; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.producttypes.subtype IS 'Подтип продукции (например, роман, журнал и т.д.)';


--
-- Name: COLUMN producttypes.price; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.producttypes.price IS 'Цена продукции';


--
-- Name: producttypes_producttypeid_seq; Type: SEQUENCE; Schema: publishing; Owner: postgres
--

CREATE SEQUENCE publishing.producttypes_producttypeid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE publishing.producttypes_producttypeid_seq OWNER TO postgres;

--
-- Name: producttypes_producttypeid_seq; Type: SEQUENCE OWNED BY; Schema: publishing; Owner: postgres
--

ALTER SEQUENCE publishing.producttypes_producttypeid_seq OWNED BY publishing.producttypes.producttypeid;


--
-- Name: publications; Type: TABLE; Schema: publishing; Owner: postgres
--

CREATE TABLE publishing.publications (
    publicationid integer NOT NULL,
    title text,
    authorid integer,
    volume integer,
    printrun integer,
    orderid integer
);


ALTER TABLE publishing.publications OWNER TO postgres;

--
-- Name: TABLE publications; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON TABLE publishing.publications IS 'Таблица, хранящая информацию о публикациях (например, книги, брошюры)';


--
-- Name: COLUMN publications.publicationid; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.publications.publicationid IS 'Уникальный идентификатор публикации';


--
-- Name: COLUMN publications.title; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.publications.title IS 'Название публикации';


--
-- Name: COLUMN publications.authorid; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.publications.authorid IS 'Ссылка на автора публикации';


--
-- Name: COLUMN publications.volume; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.publications.volume IS 'Объем публикации в печатных листах';


--
-- Name: COLUMN publications.printrun; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.publications.printrun IS 'Тираж публикации (количество копий)';


--
-- Name: COLUMN publications.orderid; Type: COMMENT; Schema: publishing; Owner: postgres
--

COMMENT ON COLUMN publishing.publications.orderid IS 'Ссылка на заказ, в рамках которого была сделана публикация';


--
-- Name: publications_publicationid_seq; Type: SEQUENCE; Schema: publishing; Owner: postgres
--

CREATE SEQUENCE publishing.publications_publicationid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE publishing.publications_publicationid_seq OWNER TO postgres;

--
-- Name: publications_publicationid_seq; Type: SEQUENCE OWNED BY; Schema: publishing; Owner: postgres
--

ALTER SEQUENCE publishing.publications_publicationid_seq OWNED BY publishing.publications.publicationid;


--
-- Name: authors authorid; Type: DEFAULT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.authors ALTER COLUMN authorid SET DEFAULT nextval('publishing.authors_authorid_seq'::regclass);


--
-- Name: customers customerid; Type: DEFAULT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.customers ALTER COLUMN customerid SET DEFAULT nextval('publishing.customers_customerid_seq'::regclass);


--
-- Name: images imageid; Type: DEFAULT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.images ALTER COLUMN imageid SET DEFAULT nextval('publishing.images_imageid_seq'::regclass);


--
-- Name: orders orderid; Type: DEFAULT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.orders ALTER COLUMN orderid SET DEFAULT nextval('publishing.orders_orderid_seq'::regclass);


--
-- Name: producttypes producttypeid; Type: DEFAULT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.producttypes ALTER COLUMN producttypeid SET DEFAULT nextval('publishing.producttypes_producttypeid_seq'::regclass);


--
-- Name: publications publicationid; Type: DEFAULT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.publications ALTER COLUMN publicationid SET DEFAULT nextval('publishing.publications_publicationid_seq'::regclass);


--
-- Data for Name: authors; Type: TABLE DATA; Schema: publishing; Owner: postgres
--

COPY publishing.authors (authorid, firstname, lastname, contactdetails) FROM stdin;
1	Иван	Иванов	ivanov@authors.ru
2	Алексей	Петров	petrov@techbooks.ru
3	Мария	Петрова	petrova@newmedia.ru
\.


--
-- Data for Name: customers; Type: TABLE DATA; Schema: publishing; Owner: postgres
--

COPY publishing.customers (customerid, name, type, contactdetails, representativeid) FROM stdin;
1	Иванов Иван Иванович	Частное лицо	ivanov@mail.ru, +7 900 000 0000	\N
2	ООО "Технографика"	Организация	techno@mail.ru, +7 495 000 0000	\N
3	Петрова Мария Ивановна	Частное лицо	petrova@mail.ru, +7 900 111 1111	\N
\.


--
-- Data for Name: images; Type: TABLE DATA; Schema: publishing; Owner: postgres
--

COPY publishing.images (imageid, publicationid, imagetype, imagepath) FROM stdin;
1	1	Обложка	/images/books/ivanov_cover.jpg
2	2	Обложка	/images/books/techbook_cover.jpg
3	3	Обложка	/images/books/petrova_cover.jpg
\.


--
-- Data for Name: orders; Type: TABLE DATA; Schema: publishing; Owner: postgres
--

COPY publishing.orders (orderid, customerid, producttypeid, quantity, orderdate, status) FROM stdin;
1	1	1	500	2024-11-01	В процессе
2	2	2	2000	2024-11-02	Напечатано
3	3	3	1000	2024-11-03	В процессе
\.


--
-- Data for Name: producttypes; Type: TABLE DATA; Schema: publishing; Owner: postgres
--

COPY publishing.producttypes (producttypeid, name, subtype, price) FROM stdin;
1	Книга	Роман	500.00
2	Брошюра	Рекламная	200.00
3	Рекламный проспект	Информационный	150.00
\.


--
-- Data for Name: publications; Type: TABLE DATA; Schema: publishing; Owner: postgres
--

COPY publishing.publications (publicationid, title, authorid, volume, printrun, orderid) FROM stdin;
1	Как стать программистом	1	300	500	1
2	Графика и технологии	2	150	2000	2
3	Реклама в XXI веке	3	50	1000	3
\.


--
-- Name: authors_authorid_seq; Type: SEQUENCE SET; Schema: publishing; Owner: postgres
--

SELECT pg_catalog.setval('publishing.authors_authorid_seq', 1, false);


--
-- Name: customers_customerid_seq; Type: SEQUENCE SET; Schema: publishing; Owner: postgres
--

SELECT pg_catalog.setval('publishing.customers_customerid_seq', 1, false);


--
-- Name: images_imageid_seq; Type: SEQUENCE SET; Schema: publishing; Owner: postgres
--

SELECT pg_catalog.setval('publishing.images_imageid_seq', 1, false);


--
-- Name: orders_orderid_seq; Type: SEQUENCE SET; Schema: publishing; Owner: postgres
--

SELECT pg_catalog.setval('publishing.orders_orderid_seq', 1, false);


--
-- Name: producttypes_producttypeid_seq; Type: SEQUENCE SET; Schema: publishing; Owner: postgres
--

SELECT pg_catalog.setval('publishing.producttypes_producttypeid_seq', 1, false);


--
-- Name: publications_publicationid_seq; Type: SEQUENCE SET; Schema: publishing; Owner: postgres
--

SELECT pg_catalog.setval('publishing.publications_publicationid_seq', 1, false);


--
-- Name: authors authors_pkey; Type: CONSTRAINT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.authors
    ADD CONSTRAINT authors_pkey PRIMARY KEY (authorid);


--
-- Name: customers customers_pkey; Type: CONSTRAINT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.customers
    ADD CONSTRAINT customers_pkey PRIMARY KEY (customerid);


--
-- Name: images images_pkey; Type: CONSTRAINT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.images
    ADD CONSTRAINT images_pkey PRIMARY KEY (imageid);


--
-- Name: orders orders_pkey; Type: CONSTRAINT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.orders
    ADD CONSTRAINT orders_pkey PRIMARY KEY (orderid);


--
-- Name: producttypes producttypes_pkey; Type: CONSTRAINT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.producttypes
    ADD CONSTRAINT producttypes_pkey PRIMARY KEY (producttypeid);


--
-- Name: publications publications_pkey; Type: CONSTRAINT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.publications
    ADD CONSTRAINT publications_pkey PRIMARY KEY (publicationid);


--
-- Name: images images_publicationid_fkey; Type: FK CONSTRAINT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.images
    ADD CONSTRAINT images_publicationid_fkey FOREIGN KEY (publicationid) REFERENCES publishing.publications(publicationid);


--
-- Name: orders orders_customerid_fkey; Type: FK CONSTRAINT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.orders
    ADD CONSTRAINT orders_customerid_fkey FOREIGN KEY (customerid) REFERENCES publishing.customers(customerid);


--
-- Name: orders orders_producttypeid_fkey; Type: FK CONSTRAINT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.orders
    ADD CONSTRAINT orders_producttypeid_fkey FOREIGN KEY (producttypeid) REFERENCES publishing.producttypes(producttypeid);


--
-- Name: publications publications_authorid_fkey; Type: FK CONSTRAINT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.publications
    ADD CONSTRAINT publications_authorid_fkey FOREIGN KEY (authorid) REFERENCES publishing.authors(authorid);


--
-- Name: publications publications_orderid_fkey; Type: FK CONSTRAINT; Schema: publishing; Owner: postgres
--

ALTER TABLE ONLY publishing.publications
    ADD CONSTRAINT publications_orderid_fkey FOREIGN KEY (orderid) REFERENCES publishing.orders(orderid);


--
-- PostgreSQL database dump complete
--

