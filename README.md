
---

# 👑 King’s Nightmare

**King’s Nightmare** là một tựa game hành động – phiêu lưu 2D, nơi người chơi hóa thân thành một vị vua bị mắc kẹt trong những cơn ác mộng thời thơ ấu. Liệu ông có đủ dũng cảm để đối mặt với nỗi sợ sâu kín nhất của mình và thoát khỏi vòng lặp ám ảnh này?

---

## 📖 Cốt truyện

Khi còn nhỏ, trong một lần đi dạo chơi trong rừng, nhà vua đã bị một đàn lợn hung dữ đuổi theo và tấn công. Dù ông may mắn thoát nạn, ký ức kinh hoàng ấy đã in sâu trong tâm trí.

Nhiều năm trôi qua, tưởng chừng mọi chuyện đã bị lãng quên… nhưng gần đây, nhà vua liên tục chìm vào những cơn ác mộng đáng sợ. Trong giấc mơ, những chú lợn năm xưa trở nên hiểm ác và đáng sợ hơn bao giờ hết.

Để thoát khỏi cơn ác mộng, nhà vua buộc phải chiến đấu với chúng, vượt qua từng giấc mơ và tìm lối thoát trước khi nỗi sợ nuốt chửng lấy ông.

---

## 🎮 Gameplay

* Mỗi **màn chơi** tương ứng với **một giấc mơ**
* Người chơi phải:

  * Tiêu diệt **toàn bộ lợn trong màn**
  * Tìm **cánh cửa thoát hiểm** để thoát khỏi giấc mơ
* Độ khó tăng dần qua từng màn

---

## 🕹️ Cách chơi (Controls)

| Phím      | Chức năng                  |
| --------- | -------------------------- |
| **A / D** | Di chuyển sang trái / phải |
| **W / S** | Leo lên / xuống thang      |
| **Space** | Nhảy                       |
| **J**     | Tấn công                   |
| **E**     | Tương tác với cửa          |

---

## ⬇️ Cách tải & cài đặt

1. Tải game tại link Google Drive bên dưới
 
   👉 **Link tải:**
   [https://drive.google.com/drive/folders/1TnfBdmnUpgJSuRs3KglulZazf9NTuOLA?usp=sharing](https://drive.google.com/drive/folders/1TnfBdmnUpgJSuRs3KglulZazf9NTuOLA?usp=sharing)

2. Giải nén file vừa tải về

3. Chạy file **.exe** để bắt đầu chơi game

> ⚠️ Lưu ý: Nếu Windows cảnh báo bảo mật, hãy chọn **More info → Run anyway**

---

## 🛠️ Cách build & chạy game (Unity Project)

### 📌 Yêu cầu môi trường

* **Unity:** `2022.3.35f1`
* **IDE:** Visual Studio / VS Code (khuyến nghị Visual Studio để debug tốt hơn)
* **.NET:** theo phiên bản Unity cài đặt (Unity sẽ tự kèm Runtime cần thiết)
* **Git:** để clone project
* (Tuỳ chọn) **Unity Hub:** để quản lý version và mở project đúng phiên bản

---

### 🧩 Clone project từ GitHub

```bash
git clone https://github.com/LDCin/King-s-Nightmare.git
cd NightmareDream
```

---

### 🏃‍♂️ Chạy game từ Unity Editor

1. Mở **Unity Hub**
2. Chọn **Add** (hoặc **Open**) → trỏ đến thư mục `NightmareDream`
3. Đảm bảo project mở bằng **Unity 600.3.2f1** (đúng version)
4. Đợi Unity import packages và assets lần đầu (có thể hơi lâu)
5. Mở scene chính:

   * Vào **Project window → Assets/Scenes** (hoặc thư mục Scenes của project)
   * Mở scene **MainMenu** hoặc scene khởi đầu (tuỳ project bạn đặt)
6. Nhấn **Play** để chạy game trong Editor

> ✅ Tip: Nếu vào Play mà không thấy UI/nhân vật, khả năng bạn đang mở nhầm scene hoặc scene boot chưa được set đúng.

---

### 📦 Build bản Release (Windows / Mac / Linux / Mobile)

#### 1) Chuẩn bị scenes chính

1. Vào **File → Build Settings**
2. Ở mục **Scenes In Build**:

   * Bấm **Add Open Scenes** để thêm scene đang mở
   * Sắp xếp scene theo thứ tự (khuyến nghị):

     1. `MainMenu` (index 0)
     2. `Level1`, `Level2`, ...
     3. Các scene phụ nếu có (Tutorial, Credits, v.v.)

> ⚠️ Nếu scene không nằm trong **Scenes In Build** thì build xong sẽ không load được scene đó.

#### 2) Chọn nền tảng build

* Trong **Build Settings → Platform**, chọn 1 trong các nền tảng:

  * **PC, Mac & Linux Standalone**
  * **iOS**
  * **Android**
* Bấm **Switch Platform** (nếu Unity yêu cầu)

#### 3) Build

1. Chọn:

   * **Build** (xuất bản build thường)
   * hoặc **Build And Run** (build xong chạy luôn)
2. Chọn nơi lưu output build
3. Sau khi build xong:
   
   * Chạy file `.exe`
---

### 🧯 Các lỗi thường gặp khi clone về chạy

* **Mở sai version Unity** → dễ lỗi package / compile
* **Thiếu scene khởi đầu trong Scenes In Build** → vào game bị màn hình đen
* **Missing Input settings** → kiểm tra Project Settings nếu game dùng Input System

---

## 💻 Cấu hình đề xuất

* **Hệ điều hành:** Windows 10 / 11
* **RAM:** 4GB trở lên
* **Dung lượng trống:** ~78MB
* **Bàn phím:** Bắt buộc (không hỗ trợ tay cầm)

---

## 🛠️ Công nghệ sử dụng

* Engine: **Unity**
* Ngôn ngữ: **C#**
---

## 📌 Ghi chú

* Game mang tính chất giải trí và trải nghiệm cốt truyện
* Mọi góp ý hoặc báo lỗi đều rất được hoan nghênh

---

## 👑 Thông điệp

> *“Đôi khi, kẻ thù đáng sợ nhất không nằm ngoài kia… mà nằm sâu trong chính tâm trí của chúng ta.”*

Chúc bạn chơi game vui vẻ và thoát khỏi **King’s Nightmare**! 🎮🔥

---
