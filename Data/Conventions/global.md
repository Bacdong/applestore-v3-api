## Database ##


### Bảng `Categories` ###

| Tên cột                  | Kiểu dữ liệu    | Thuộc tính       | Giá trị mặc định | Mô tả                            |
| ------------------------ | --------------- | ---------------- | ---------------- | -------------------------------- |
| id                       | integer         | primary key      |                  | ID loại sản phẩm                 |
| sortOrder                | integer         |                  |                  |                                  |
| isPublic                 | boolean         | not null         | True             | Hiển thị sản phẩm                |
| status                   | varchar(32)     |                  | active           | Trạng thái                       |
| parentId                 | integer         |                  |                  | ID của category cha              |
| productInCategories      | integer         | foreign key      |                  | ID của sản phẩm thuộc category   |



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