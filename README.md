
# CXPerium .NET SDK Dökümantasyonu

Bu dökümantasyon, CXPerium .NET SDK'sını kullanarak WhatsApp üzerinde özel chatbotlar oluşturmak isteyen geliştiriciler için hazırlanmıştır. Adım adım ilerleyerek kurulum, konfigürasyon ve geliştirme sürecini kapsar.

---

## 1. Adım: **app.cxperium.com Üzerinde İlgili Konfigürasyonu Yapmak**

### 1.1 Hesap Oluşturma veya Oturum Açma

1. [app.cxperium.com](https://app.cxperium.com) adresine gidin.
2. Hesabınız yoksa "Kaydıt Ol" seçeneğine tıklayarak bir hesap oluşturun:
   - Ad Soyad
   - E-posta adresi
   - Şifre bilgilerini doldurun.
   - Aktivasyon e-postasını onaylamayı unutmayın.
3. Hesabınız varsa "Giriş Yap" seçeneğiyle oturum açın.

---

## 2. Adım: **Örnek Projeyi GitHub'dan İndirmek**

### 2.1 GitHub Projesine Erişim

1. Web tarayıcısından [https://github.com/qsoft-git/CXPerium.Bot.Sample.git](https://github.com/qsoft-git/CXPerium.Bot.Sample.git) adresine gidin.
2. Proje sayfasında açıklamaları inceleyebilirsiniz.

### 2.2 Projeyi İndirme

1. **Code** butonuna tıklayın.
2. Şu iki seçenekten birini kullanarak projeyi indirin:
   - **Download ZIP:** Projeyi ZIP formatında bilgisayarınıza indirin.
   - **Clone with HTTPS:** Git yüklü ise terminal veya Git Bash üzerinde şu komutu çalıştırın:
     ```bash
     git clone https://github.com/qsoft-git/CXPerium.Bot.Sample.git
     ```

### 2.2.1 NuGet Paketini Eklemek

1. Projeyi bilgisayarınıza indirdikten sonra, CXPerium'un özel NuGet paketini projeye eklemeniz gerekmektedir.
2. Eklenecek paket: **CXPerium.Controller**
3. Eğer bu paketi CXPerium özel NuGet paketinde göremiyorsanız, aşağıdaki adımları izleyin:
   - Visual Studio'da **Tools -> NuGet Package Manager -> Package Manager Settings** menüsüne gidin.
   - **Package Sources** sekmesine tıklayın.
   - **Add** butonuna basarak yeni bir kaynak ekleyin:
     - **Name:** CXPerium
     - **Source:** [https://nuget.cxperium.com/v3/index.json](https://nuget.cxperium.com/v3/index.json)
   - **OK** butonuna basarak ayarları kaydedin.
4. Şimdi, **CXPerium.Controller** paketini projenize NuGet Package Manager üzerinden ekleyebilirsiniz.

### 2.3 Projenin Yapısı ve Varsayılan Ayarlar

- Projeyi indirdikten sonra bir geliştirme ortamı (Visual Studio gibi) kullanarak açın.
- Varsayılan olarak, proje **http://localhost:3978** portunda çalışır. Bu portu değiştirmek isterseniz, proje içerisindeki **launchSettings.json** dosyasını düzenleyebilirsiniz.

### 2.4 Reverse Proxy Kurulumu

- CXPerium'un verdiği sandbox numarasından WhatsApp'a mesaj gönderildiğinde, bu mesajın geliştiricinin bilgisayarındaki **http://localhost:3978** adresine ulaşması için bir **reverse proxy** kullanılması gerekir.
- Reverse proxy aracı olarak **ngrok** kullanılır.

#### Ngrok ile Kurulum

1. Ngrok uygulamasını indirip kurun. ([https://ngrok.com/](https://ngrok.com/))
2. Terminalde şu komutu çalıştırın:
   ```bash
   ngrok http 3978 --host-header="localhost:3978"
   ```
3. Ngrok size bir public URL verecektir (örneğin: **https://xxxxx.ngrok.io**). Bu URL’yi not edin.

---

## 3. Adım: **Ngrok URL'sini Projeye Eklemek**

1. İndirdiğiniz proje dosyalarının içinde **appsettings-dev.json** dosyasını bulun.
2. Dosyayı bir metin düzenleyicide açın (ör. Visual Studio Code, Notepad++).
3. Dosyada yer alan **BotUrl** alanını, ngrok tarafından sağlanan URL ile güncelleyin. Örneğin:
   ```json
   "BotUrl": "https://xxxxx.ngrok.io"
   ```
4. Dosyayı kaydedin.

---

## 4. Adım: **CXPerium Platformunda Geliştirici Ayarlarını Yapılandırmak**

### 4.1 Hook Adresini Projeye Eklemek

1. Daha önce indirdiğiniz proje dosyalarının içinde **appsettings-dev.json** dosyasını bulun.
2. Dosyayı bir metin düzenleyicide açın.
3. Dosyada yer alan **HookUrl** alanını, CXPerium Developer Settings ekranında aldığınız **https://hook** ile başlayan adres ile güncelleyin. Örneğin:
   ```json
   "HookUrl": "https://hook.example.com"
   ```
4. Dosyayı kaydedin.

### 4.2 API Key Oluşturma

1. CXPerium hesabınıza giriş yaptıktan sonra menüye giderek **Ayarlar** seçeneğine tıklayın.
2. **API Integration** sekmesini açın.
3. Ekrandaki **Regenerate** butonuna tıklayarak bir API Key oluşturun.
   - Bu işlem size yeni bir **API Key** verecektir.
4. Oluşturulan API Key’i güvenli bir yere kaydedin.
5. Bu **API Key**’i indirdiğiniz proje dosyasındaki **appsettings-dev.json** dosyasındaki **ApiKey** alanına ekleyin. Örneğin:
   ```json
   "ApiKey": "your_generated_api_key_here"
   ```
6. Dosyayı kaydedin.

---

## 5. Adım: **Test Etme**

1. Projeyi çalıştırdıktan sonra CXPerium'un sağladığı sandbox numarasını kullanarak WhatsApp üzerinden test edebilirsiniz.
   - Sandbox numarası: **+908503094552**
2. WhatsApp'tan bu numaraya "Merhaba" mesajını gönderin.
   - Chatbot size "**Hello World**" şeklinde yanıt verecektir.

Bu adımları tamamladıktan sonra chatbotunuzun çalıştığını doğrulayabilirsiniz.

**Tebrikler!** Artık CXPerium tabanlı chatbotunuz başarıyla çalışıyor.
