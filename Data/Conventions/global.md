## Database ##



### Bảng `AppConfigs` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| id                       | integer         | primary key      |                  | ID AppConfigs                    |
| key                      | varchar(32)     | not null         |                  | Tên các trang điều hướng         |
| value                    | varchar(64)     | not null         |                  | Mô tả của key - title            |



### Bảng `Carts` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| id                       | integer         | primary key      |                  | ID của giỏ hàng                  |
| productId                | integer         | foreign key      |                  | ID của sản phẩm                  |
| quantity                 | integer         |                  |                  | Số lượng sản phẩm                |
| price                    | decimal         |                  |                  | Tổng tiền                        |
| userId                   | integer         | foreign key      |                  | ID của user                      |
| created                  | DateTime        |                  | DateTime.UtcNow  | Ngày tạo giỏ hàng                |



### Bảng `Categories` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| id                       | integer         | primary key      |                  | ID loại sản phẩm                 |
| sortOrder                | integer         |                  |                  |                                  |
| isPublic                 | boolean         | not null         | True             | Hiển thị sản phẩm                |
| status                   | varchar(32)     |                  | active           | Trạng thái                       |
| parentId                 | integer         |                  |                  | ID của category cha              |
| productInCategories      | integer         | foreign key      |                  | ID của sản phẩm thuộc category   |



### Bảng `CategoryTranslations` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| id                       | integer         | primary key      |                  | ID loại sản phẩm - bản dịch      |
| categoryId               | integer         | foreign key      |                  | ID của loại sản phẩm             |
| name                     | varchar(32)     | not null         |                  | Tên loại sản phẩm                |
| brief                    | varchar(32)     |                  |                  | Mô tả ngắn                       |
| title                    | varchar(64)     |                  |                  | Tiêu đề loại sản phẩm            |
| languageId               | integer         | foreign key      |                  | ID ngôn ngữ                      |
| seoAlias                 | varchar(32)     | not null         |                  | Slug                             |



### Bảng `Contacts` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| id                       | integer         | primary key      |                  | ID của liên hệ                   |
| name                     | varchar(32)     | not null         |                  | Tên người gửi liên hệ            |
| email                    | varchar(32)     | not null         |                  | Email của người gửi liên hệ      |
| phone                    | varchar(32)     | not null         |                  | SDT của người gửi liên hệ        |
| message                  | varchar(256)    | not null         |                  | Nội dung liên hệ                 |
| status                   | varchar(32)     | Status           | Status.pending   | Trạng thái                       |



### Bảng `Languages` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| id                       | integer         | primary key      |                  | ID của ngôn ngữ                  |
| name                     | varchar(32)     | not null         |                  | Tên ngôn ngữ                     |
| isDefault                | boolean         | not null         |                  | Chọn mặc định                    |




### Bảng `Orders` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| id                       | integer         | primary key      |                  | ID của đơn hàng                  |
| created                  | DateTime        |                  | DateTime.UtcNow  | Ngày tạo                         |
| userId                   | integer         | foreign key      |                  | ID người đặt                     |
| shippingName             | varchar(32)     | not null         |                  | Tên người đặt                    |
| shippingAddress          | varchar(64)     | not null         |                  | Địa chỉ                          |
| shippingEmail            | varchar(32)     |                  |                  | Email                            |
| shippingPhone            | varchar(32)     | not null         |                  | Số điện thoại                    |
| status                   | varchar(32)     | OrderStatus      | inProgress       | Trạng thái                       |



### Bảng `OrderLines` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| orderId                  | integer         | pk, fk           |                  | ID của đơn hàng                  |
| productId                | integer         | pk, fk           |                  | ID của sản phẩm                  |
| quantity                 | integer         |                  |                  | Số lượng                         |
| price                    | decimal         | not null         |                  | Giá tiền                         |



### Bảng `Products` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| id                       | integer         | primary key      |                  | ID của sản phẩm                  |
| price                    | decimal         | not null         | 0                | Giá của sản phẩm                 |
| originalPrice            | decimal         | not null         | 0                | Giá gốc của sản phẩm             |
| stock                    | integer         | not null         | 0                | Kho                              |
| viewCount                | integer         | not null         | 0                | Số lượt xem của sản phẩm         |
| created                  | datetime        |                  | DateTime.UtcNow  | Thời gian tạo sản phẩm           |
| seoAlias                 | varchar(32)     |                  |                  | Tên sản phẩm                     |
| productInCategories      | integer         | foreign key      |                  | ID của categories                |
| orderLines               | integer         | foreign key      |                  | ID của chi tiết sản phẩm         |
| carts                    | integer         | foreign key      |                  | ID giỏ hàng                      |



### Bảng `ProductInCategories` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| productId                | integer         | pk, fk           |                  | ID của sản phẩm                  |
| categoryId               | integer         | pk, fk           |                  | ID của loại sản phẩm             |



### Bảng `ProductTranslations` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| id                       | integer         | primary key      |                  | ID sản phẩm - bản dịch           |
| productId                | integer         | foreign key      |                  | ID sản phẩm                      |
| name                     | varchar(32)     | not null         |                  | Tên sản phẩm                     |
| brief                    | varchar(64)     |                  |                  | Mô tả ngắn                       |
| title                    | varchar(64)     |                  |                  | Tiêu đề                          |
| languageId               | integer         | foreign key      | 1                | ID ngôn ngữ                      |
| seoAlias                 | varchar(32)     | not null         |                  | Slug                             |



### Bảng `Promotions` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| id                       | integer         | primary key      |                  | ID khuyến mãi                    |
| name                     | varchar(32)     | not null         |                  | Tên khuyến mãi                   |
| startTime                | DateTime        |                  |                  | Thời gian bắt đầu                |
| endTime                  | DateTime        |                  |                  | Thời gian kết thúc               |
| applyForAll              | boolean         |                  | false            | Áp dụng tất cả                   |
| discountPercent          | integer         | null             |                  | Phần trăm khuyến mãi             |
| discountAmount           | decimal         |                  |                  | Số tiền khuyến mãi               |
| productIds               | varchar(32)     |                  |                  | IDs sản phẩm                     |
| productCategoryIds       | varchar(32)     |                  |                  | IDs loại sản phẩm                |
| status                   | varchar(32)     |                  | Status.active    | Trạng thái                       |



### Bảng `Transactions` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| id                       | integer         | primary key      |                  | ID giao dịch                     |
| created                  | DateTime        |                  |                  | Ngày giao dịch                   |
| externalTransactionId    | varchar(32)     |                  |                  | ?????                            |
| amount                   | decimal         |                  |                  | Số tiền giao dịch                |
| fee                      | decimal         |                  |                  | Phí giao dịch                    |
| result                   | varchar(32)     |                  |                  | Kết quả giao dịch                |
| message                  | varchar(32)     |                  |                  | Thông báo                        |
| status                   | varchar(32)     |                  |                  | Trạng thái                       |
| provider                 | varchar(32)     |                  |                  | Nhà cung cấp                     |



