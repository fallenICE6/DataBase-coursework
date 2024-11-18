# Книжное издательство
Курсовая работа по предмету: "Системы управления базами данных"
## Исходные данные к работе
 - Издательство — предприятие, занимающееся выпуском разнообразной печатной продукции. 
Издательство заключает договор с заказчиком (клиентом) на выполнение заказа. Заказчиком 
может выступать частное лицо или организация. Частное лицо может быть автором издания 
(или одним из авторов, если их несколько) или представителем автора. Организация для 
контактов с издательством также имеет своего представителя.

 - Заказ может быть книгой, брошюрой, рекламным проспектом, буклетом, бюллетенем для 
голосования или каким-либо другим видом издательской продукции.  Типы продукции могут 
иметь подтипы. Цена зависит от типа продукции, бумаги, цветности, количества листов и т.п. 
Подготовленные издательством материалы заказчика печатаются в типографии издательства.  
Продукция может быть напечатана на бумаге различных типов.           
 
 - Информацию о работе издательства можно сгруппировать следующим образом: сведения о 
заказчиках; сведения о заказах; сведения об изданиях (код издания, автор и название, объем в 
печатных листах, тираж, номер заказа  и т.д); сведения об авторах.             
 
 - В БД предусмотреть хранение изображений (минимум в одном поле) в соответствии с 
тематикой курсовой работы.                                                                                                                     
 
 - В БД должны быть реализованы хранимые процедуры и/или триггеры.          
      
- в БД должно быть занесено суммарно не менее 50 записей

## Описание проекта
Проект "Издательство" представляет собой систему для хранения и обработки информации об изданиях, заказах и заказчиках в рамках издательской деятельности. В данном проекте рассматриваются различные аспекты работы издательства: от заключения договоров с клиентами до печати продукции на различных типах бумаги. Система будет хранить информацию о заказах, заказчиках (частных лицах и организациях), типах продукции, авторах и других связанных данных.
## Основные компоненты системы
### <ins>Заказчики (Customers):</ins>

***Заказчики могут быть частными лицами или организациями. У каждого заказчика будет информация о контактных данных, представителях, а также о связи с конкретными авторами (если это необходимо).
Для организации возможно хранение данных о представителе, который контактирует с издательством.***
### <ins>Типы продукции (ProductTypes):</ins>

***В системе предусмотрены различные типы продукции, такие как книги, брошюры, рекламные проспекты и т. д. У каждого типа продукции могут быть подтипы, определяющие более узкие классификации.
Цена продукции зависит от типа, бумаги, цветности, количества листов и других характеристик, которые могут изменяться в зависимости от типа заказа.***
### <ins>Заказы (Orders):</ins>

***Каждый заказ включает информацию о заказчике, типе продукции, объеме (например, количество страниц), тиражах, а также возможных дополнительных требованиях.
Каждый заказ привязан к конкретному клиенту и может содержать несколько изданий.***
### <ins>Издания (Publications):</ins>

***Для каждого издания будет храниться информация о его названии, авторе (или нескольких авторах), объеме (в печатных листах), тиражах, а также другой информации, связанной с публикацией.
Издание может быть связано с несколькими заказами, и в систему можно будет заносить информацию о печатных материалах, изображения (например, обложка книги) и других характеристиках.***
### <ins>Авторы (Authors):</ins>

***Каждый автор может быть частным лицом, представляющим себя, или же организация, выступающая как автор. Информация о каждом авторе будет включать их имя, фамилию, контактные данные и может включать несколько изданий.***
### <ins>Типы бумаги и другие материалы:</ins>

***В системе будет храниться информация о различных типах бумаги и других материалах, которые могут быть использованы для печати продукции. Эти данные важны для расчета стоимости и других характеристик заказа.***
### <ins>Триггеры и хранимые процедуры:</ins>

***В БД будут реализованы хранимые процедуры для автоматического расчета стоимости заказа, вывода информации по заказам и производственным этапам.
Триггеры будут отслеживать важные изменения в базе данных, такие как обновление данных заказов или изменений статуса издания.***
## Описание ключевых сущностей базы данных:
### <ins>Заказчики (Customers):</ins>
- CustomerID (Уникальный идентификатор заказчика)
- Name (Имя заказчика)
- Type (Тип заказчика: частное лицо или организация)
- ContactDetails (Контактная информация)
- RepresentativeID (Связь с представителем заказчика, если это организация)
### <ins>Типы продукции (ProductTypes):</ins>
- ProductTypeID (Идентификатор типа продукции)
- Name (Название типа продукции, например, книга, брошюра)
- Subtype (Подтипы, если они есть)
- Price (Цена)
### <ins>Заказы (Orders):</ins>
- OrderID (Идентификатор заказа)
- CustomerID (Идентификатор заказчика)
- ProductTypeID (Идентификатор типа продукции)
- Quantity (Количество продукции)
- OrderDate (Дата заказа)
- Status (Статус заказа)
### <ins>Издания (Publications):</ins>
- PublicationID (Идентификатор издания)
- Title (Название издания)
- AuthorID (Идентификатор автора)
- Volume (Объем издания в печатных листах)
- PrintRun (Тираж)
- OrderID (Идентификатор заказа, в рамках которого сделан выпуск)
### <ins>Авторы (Authors):</ins>
- AuthorID (Идентификатор автора)
- FirstName (Имя)
- LastName (Фамилия)
- ContactDetails (Контактная информация)
### <ins>Изображения (Images):</ins>
- ImageID (Идентификатор изображения)
- ImageType (Тип изображения, например, обложка)
- ImagePath (Путь к изображению в файловой системе или URL)
## Техническая реализация:
- **Для реализации базы данных будет использована СУБД PostgreSQL.**
- **Система будет включать таблицы для хранения данных о заказах, заказчиках, авторах и типах продукции.**
- **Хранимые процедуры и триггеры будут использоваться для обработки данных:**
  - <ins>Хранимая процедура для расчета стоимости заказа:</ins> Эта процедура будет вызываться при добавлении нового заказа и рассчитывать стоимость на основе типа продукции, материалов и других параметров.
  - <ins>Триггер для автоматического обновления статуса заказа:</ins> При изменении статуса заказа триггер будет автоматически обновлять информацию в других связанных таблицах, например, в таблице изданий.
- **Для загрузки и хранения изображений будет использоваться тип данных BLOB (Binary Large Object).**
  
*Проект должен включать не менее 50 записей в базе данных, что обеспечит достаточную полноту для демонстрации работы системы.*

**Проект "Издательство" поможет эффективно управлять информацией о заказах, продуктах, заказчиках и авторах, а также позволит отслеживать весь процесс издательской деятельности от начала до завершения.**
